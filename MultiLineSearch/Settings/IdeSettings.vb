Imports System
Imports Microsoft.VisualStudio.Shell.Interop
Imports Microsoft.VisualStudio.Shell


Namespace Settings

    ''' <summary>
    ''' This class provides read/write access to any VS IDE setting that is available in 
    ''' .vssettings file.
    ''' </summary>
    ''' <remarks>
    ''' Normally, we can get/set IDE properties only with DTE.Properties. But only a limited
    ''' set of all settings are available in DTE.
    ''' We can access all settings in registry. But it has one main drawback. They are written only 
    ''' when VS closes and they are read only at VS start. So we cannot get the current value during 
    ''' VS execution.
    ''' The third way is to export/import settings with 'Tools.ImportandExportSettings' command. This allows for
    ''' getting and setting the current values. But we cannot programmatically export just a part fo settings
    ''' (as it is possible with import/export wizard). So there will be always all settings exported, resulting in possibly
    ''' several MB XMl file. Moreover, some extensions (MZ-Tools) hook into 'Tools.ImportandExportSettings' command
    ''' and show some dialogs. This is intolerable.
    ''' So as the solution, it seems to be the best to use import/export functionality of packages. But use it directly
    ''' on particular packages and don't use files at all.
    ''' 
    ''' This class allows for fine import/export of settings based on package GUID and settings category GUID, as
    ''' saved in .vssettings file. The settings are stored in memory.
    ''' </remarks>
    Friend Class IdeSettings

        Private ReadOnly shellService As IVsShell


        Public Sub New()
            shellService = TryCast(Package.GetGlobalService(GetType(SVsShell)), IVsShell)
            If shellService Is Nothing Then
                Throw New Exception("The IVsShell interface (or SVsShell service) couldn't be retrieved.")
            End If
        End Sub


        ''' <summary>
        ''' Gets settings for specified package and for specified settings category.
        ''' </summary>
        ''' <param name="packageGuid">The package GUID as specified in .vssettings file in 
        ''' the 'Package' attribute of the 'Category' element.</param>
        ''' <param name="categoryGuid">The category GUID as specified in .vssettings file in 
        ''' the 'Category' attribute of the 'Category' element.</param>
        ''' <returns>All settings from the category. Nothing if a problem occurs.</returns>
        ''' <remarks></remarks>
        Public Function GetSettings(ByVal packageGuid As String, ByVal categoryGuid As String) As PackageMemorySettingsStore
            Try
                Dim pkgGuid As New Guid(packageGuid)
                Dim pkg As IVsPackage = Nothing
                shellService.IsPackageLoaded(pkgGuid, pkg)
                If pkg IsNot Nothing Then
                    ' VS 2005-2012
                    Dim pkgSettings As IVsUserSettings = TryCast(pkg, IVsUserSettings)
                    ' VS 2013
                    Dim pkgSettings2 As IVsUserSettings2 = TryCast(pkg, IVsUserSettings2)

                    If pkgSettings IsNot Nothing Then
                        Dim setWriter As New PackageMemorySettingsWriter
                        pkgSettings.ExportSettings(categoryGuid, setWriter)
                        Return setWriter.SettingsStore
                    ElseIf pkgSettings2 IsNot Nothing Then
                        Dim setWriter As New PackageMemorySettingsWriter
                        Dim catGuid As New Guid(categoryGuid)
                        pkgSettings2.ExportSettings(catGuid, setWriter, Nothing)
                        Return setWriter.SettingsStore
                    End If
                End If
            Catch ex As Exception
            End Try

            Return Nothing
        End Function


        ''' <summary>
        ''' Sets settings for specified package and for specified settings category.
        ''' </summary>
        ''' <param name="packageGuid">The package GUID as specified in .vssettings file in 
        ''' the 'Package' attribute of the 'Category' element.</param>
        ''' <param name="categoryGuid">The category GUID as specified in .vssettings file in 
        ''' the 'Category' attribute of the 'Category' element.</param>
        ''' <param name="settings">All settings from the category.</param>
        ''' <remarks></remarks>
        Public Sub SetSettings(ByVal packageGuid As String, ByVal categoryGuid As String, ByVal settings As PackageMemorySettingsStore)
            If settings Is Nothing Then
                Return
            End If

            Try
                Dim pkgGuid As New Guid(packageGuid)
                Dim pkg As IVsPackage = Nothing
                shellService.IsPackageLoaded(pkgGuid, pkg)
                If pkg IsNot Nothing Then
                    ' VS 2005-2012
                    Dim pkgSettings As IVsUserSettings = TryCast(pkg, IVsUserSettings)
                    ' VS 2013
                    Dim pkgSettings2 As IVsUserSettings2 = TryCast(pkg, IVsUserSettings2)

                    If pkgSettings IsNot Nothing Then
                        Dim setReader As New PackageMemorySettingsReader(settings)
                        Dim restartRequired As Integer = 0
                        pkgSettings.ImportSettings(categoryGuid, setReader, CUInt(__UserSettingsFlags.USF_None), restartRequired)
                    ElseIf pkgSettings2 IsNot Nothing Then
                        Dim setReader As New PackageMemorySettingsReader(settings)
                        Dim catGuid As New Guid(categoryGuid)
                        pkgSettings2.ImportSettings(catGuid, setReader, CUInt(__UserSettingsFlags.USF_None), Nothing)
                    End If
                End If
            Catch ex As Exception
            End Try
        End Sub


    End Class

End Namespace
