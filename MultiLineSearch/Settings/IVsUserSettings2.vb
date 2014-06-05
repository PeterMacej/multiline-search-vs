Imports System.Runtime.InteropServices
Imports Microsoft.VisualStudio.Shell.Interop
Imports Microsoft.VisualStudio.OLE.Interop


Namespace Settings

    ''' <summary>
    ''' Provides help with importing and exporting settings.
    ''' </summary>
    ''' <remarks>This interface is introduced in Microsoft.VisualStudio.Shell.Interop.12.0.dll
    ''' which cannot be referenced here. So define the interface manually.</remarks>
    <InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)> _
    <GuidAttribute("BCAACBEA-0763-491E-84E0-ED29DD8EBBA8")> _
    Public Interface IVsUserSettings2

        Sub ExportSettings( _
        <InAttribute()> <ComAliasName("OLE.REFGUID")> ByRef category As Guid, _
        <InAttribute()> ByVal settingsWriter As IVsSettingsWriter, _
        <InAttribute()> ByVal storageContainer As IVsSettingsStorageContainer _
        )


        Sub ImportSettings( _
        <InAttribute()> <ComAliasName("OLE.REFGUID")> ByRef category As Guid, _
        <InAttribute()> ByVal settingsReader As IVsSettingsReader, _
        <InAttribute()> <ComAliasName("VsShell.UserSettingsFlags")> ByVal flags As UInteger, _
        <InAttribute()> ByVal storageContainer As IVsSettingsStorageContainer _
        )


        'Sub ImportSettings( _
        '    ByRef category As Guid, _
        '    ByVal settingsReader As IVsSettingsReader, _
        '    ByVal flags As UInteger, _
        '    ByVal storageContainer As Object _
        ')


        'Sub ExportSettings( _
        '    ByRef category As Guid, _
        '    ByVal settingsWriter As IVsSettingsWriter, _
        '    ByVal storageContainer As Object _
        ')


    End Interface

End Namespace


''' <remarks>This interface is introduced in Microsoft.VisualStudio.Shell.Interop.12.0.dll
''' which cannot be referenced here. So define the interface manually.</remarks>
<Guid("0B578BCA-3358-441A-8EA5-9AE07182BEBB")> _
<InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)> _
Public Interface IVsSettingsStorageContainer
    Sub Clear()

    ' Parameter ppEnum is an "out" parameter, which is not supported in VisualBasic.
    Sub EnumKeys(<Out()> ByRef ppEnum As IEnumString)

    ' Parameter ppEnum is an "out" parameter, which is not supported in VisualBasic.
    Sub EnumSubkeys(<InAttribute()> <ComAliasName("OLE.LPCWSTR")> ByVal parentKeys As String(), <InAttribute()> ByVal parentKeyCount As Integer, <Out()> ByRef ppEnum As IEnumString)

    Function GetMultiKeyValue(<InAttribute()> <ComAliasName("OLE.LPCWSTR")> ByVal keys As String(), <InAttribute()> ByVal keyCount As Integer) As String

    Function GetValue(<InAttribute()> <ComAliasName("OLE.LPCWSTR")> ByVal key As String) As String

    Sub RemoveMultiKeyValue(<InAttribute()> <ComAliasName("OLE.LPCWSTR")> ByVal keys As String(), <InAttribute()> ByVal keyCount As Integer)

    Sub RemoveValue(<InAttribute()> <ComAliasName("OLE.LPCWSTR")> ByVal key As String)

    Sub SetMultiKeyValue(<InAttribute()> <ComAliasName("OLE.LPCWSTR")> ByVal keys As String(), <InAttribute()> <ComAliasName("OLE.DWORD")> ByVal keyCount As UInteger, <InAttribute()> <ComAliasName("OLE.LPCWSTR")> ByVal value As String)

    Sub SetValue(<InAttribute()> <ComAliasName("OLE.LPCWSTR")> ByVal key As String, <InAttribute()> <ComAliasName("OLE.LPCWSTR")> ByVal value As String)
End Interface
