Imports System
Imports EnvDTE
Imports EnvDTE80
Imports System.Diagnostics
Imports Microsoft.VisualStudio
Imports System.Xml
Imports System.Collections.Generic
Imports Microsoft.VisualStudio.Shell.Interop
Imports Microsoft.VisualStudio.Shell
Imports Microsoft.VisualBasic


''' <summary>
''' Performs multiline search and replace in the VS IDE.
''' </summary>
''' <remarks></remarks>
Friend Class MultilineSearchReplace
    Implements ISearchReplaceProvider


    Private dte As DTE2


    Public Sub New(ByVal dte As DTE2)
        If dte Is Nothing Then
            Throw New NullReferenceException()
        End If

        Me.dte = dte
    End Sub



    ''' <summary>
    ''' Execute search and replace operation.
    ''' </summary>
    ''' <param name="searchKind"></param>
    ''' <param name="findText">Plain text, can contain newlines.</param>
    ''' <param name="replaceText">Plain text, can contain newlines.</param>
    Public Sub ExecSearchReplace(ByVal searchKind As FindReplaceKind, ByVal findText As String, ByVal replaceText As String) Implements ISearchReplaceProvider.ExecSearchReplace
        If searchKind <> FindReplaceKind.none Then
            ' escape the texts to regex
            findText = ConvertFindWhatToRegEx(findText)
            replaceText = ConvertReplaceWithToRegEx(replaceText)

            ' temporarily disable Tools - Options -
            ' Environment - Documents - Initialize Find text from editor
            Dim oldFindInit As Boolean
            Try
                'vs 2005/2008
                Dim props As EnvDTE.Properties
                props = dte.Properties("Environment", "FindAndReplace")
                Dim prop As EnvDTE.Property = props.Item("InitializeFromEditor")
                oldFindInit = CBool(prop.Value)
                prop.Value = False
            Catch ex2 As Exception
            End Try

            ' dte.Find.PatternSyntax = vsFindPatternSyntax.vsFindPatternSyntaxRegExpr   ' no effect in VS 2013
            Select Case searchKind
                Case FindReplaceKind.find
                    SetRegexInFindDialog()
                Case FindReplaceKind.findInFiles
                    SetRegexInFindInFilesDialog()
                Case FindReplaceKind.replace
                    SetRegexInFindDialog()
                Case FindReplaceKind.replaceInFiles
                    SetRegexInFindInFilesDialog()
                Case Else
            End Select

            dte.Find.FindWhat = findText
            If replaceText.Length = 0 Then
                'If Replace text is empty, the Find dialog automatically
                'uses the last non-empty value from history. To prevent this,
                'we must pass some non-empty value which produces empty text.
                'The ninth regex tagged expression seems good for this as it is very
                'unlikely that user will add 9 tagged expressions in Find field in
                'original VS Find dialog after it is pre-filled with this macro.
                dte.Find.ReplaceWith = "\9"
            End If
            dte.Find.ReplaceWith = replaceText

            Select Case searchKind
                Case FindReplaceKind.find
                    dte.ExecuteCommand("Edit.Find")
                Case FindReplaceKind.findInFiles
                    dte.ExecuteCommand("Edit.FindinFiles")
                Case FindReplaceKind.replace
                    dte.ExecuteCommand("Edit.Replace")
                Case FindReplaceKind.replaceInFiles
                    dte.ExecuteCommand("Edit.ReplaceinFiles")
                Case Else
            End Select

            ' restore Tools - Options -
            ' Environment - Documents - Initialize Find text from editor
            Try
                'vs 2005/2008
                Dim props As EnvDTE.Properties
                props = dte.Properties("Environment", "FindAndReplace")
                Dim prop As EnvDTE.Property = props.Item("InitializeFromEditor")
                prop.Value = oldFindInit
            Catch ex2 As Exception
            End Try
        End If
    End Sub


    ''' <summary>
    ''' Turn's on the regex option in the Find/Replace dialog.
    ''' </summary>
    ''' <remarks>In VS 2005-2010?, it was enough to set 
    ''' Dte.Find.PatternSyntax = vsFindPatternSyntax.vsFindPatternSyntaxRegExpr
    ''' and the change was automatically reflected in Find and Find in Files dialogs.
    ''' But at least in VS 2013, this change is ignored in the dialogs. Nothing helps,
    ''' even Dte.Find.Execute doesn't apply the change.
    ''' This method accesses appropriate settings directly and sets the correct
    ''' values.
    ''' </remarks>
    Private Sub SetRegexInFindDialog()
        Try
            Dim settings As New IdeSettings

            ' Visual Studio Environment Package
            Dim pkgGuid As String = "{DA9FB551-C724-11d0-AE1F-00A0C90FFFC3}"
            ' category Environment_UnifiedFind
            Dim categoryGuid As String = "{DF00ADDF-C14C-4ffd-9325-634FD605850B}"

            Dim settingsStore As PackageMemorySettingsStore
            settingsStore = settings.GetSettings(pkgGuid, categoryGuid)
            If settingsStore IsNot Nothing Then
                ' set regex in Find and Find in Files dialogs
                Dim setting As PackageMemorySettingsStore.Setting = Nothing
                'All VS versions
                If settingsStore.Settings.TryGetValue("Options", setting) Then
                    setting.Value = setting.Value.ToString.Replace(" Plain ", " Regex ")
                End If
                ' VS 2005-2010
                If settingsStore.Settings.TryGetValue("Document Options", setting) Then
                    setting.Value = setting.Value.ToString.Replace(" Plain ", " Regex ")
                End If
                ' VS 2012-2013
                If settingsStore.Settings.TryGetValue("AdornmentOptions", setting) Then
                    setting.Value = setting.Value.ToString.Replace(" Plain ", " Regex ")
                End If

                settings.SetSettings(pkgGuid, categoryGuid, settingsStore)
            End If
        Catch ex As Exception
        End Try
    End Sub


    ''' <summary>
    ''' Turn's on the regex option in the Find/Replace in Files dialog.
    ''' </summary>
    ''' <remarks>In VS 2005-2010?, it was enough to set 
    ''' Dte.Find.PatternSyntax = vsFindPatternSyntax.vsFindPatternSyntaxRegExpr
    ''' and the change was automatically reflected in Find and Find in Files dialogs.
    ''' But at least in VS 2013, this change is ignored in the dialogs. Nothing helps,
    ''' even Dte.Find.Execute doesn't apply the change.
    ''' This method accesses appropriate settings directly and sets the correct
    ''' values.
    ''' </remarks>
    Private Sub SetRegexInFindInFilesDialog()
        Try
            Dim settings As New IdeSettings

            ' Visual Studio Environment Package
            Dim pkgGuid As String = "{DA9FB551-C724-11d0-AE1F-00A0C90FFFC3}"
            ' category Environment_UnifiedFind
            Dim categoryGuid As String = "{DF00ADDF-C14C-4ffd-9325-634FD605850B}"

            Dim settingsStore As PackageMemorySettingsStore
            settingsStore = settings.GetSettings(pkgGuid, categoryGuid)
            If settingsStore IsNot Nothing Then
                ' set regex in Find and Find in Files dialogs
                Dim setting As PackageMemorySettingsStore.Setting = Nothing
                'All VS versions
                If settingsStore.Settings.TryGetValue("Options", setting) Then
                    setting.Value = setting.Value.ToString.Replace(" Plain ", " Regex ")
                End If
                ' VS 2005-2010
                If settingsStore.Settings.TryGetValue("FiF Options", setting) Then
                    setting.Value = setting.Value.ToString.Replace(" Plain ", " Regex ")
                End If
                ' VS 2012-2013
                If settingsStore.Settings.TryGetValue("DialogOptions", setting) Then
                    setting.Value = setting.Value.ToString.Replace(" Plain ", " Regex ")
                End If

                settings.SetSettings(pkgGuid, categoryGuid, settingsStore)
            End If
        Catch ex As Exception
        End Try
    End Sub


    Private Function GetVsVersion() As Double
        Dim version As Double = 10 ' default is VS 2010
        Try
            version = Double.Parse(dte.Version, New Globalization.CultureInfo("en-US", False).NumberFormat) 'use dot as decimal separator
        Catch ex As Exception
        End Try

        Return version
    End Function


    '''<summary>Transforms the 'Find what' text to regular expression syntax.</summary>
    '''<param name="original">Original text.</param>
    '''<returns>Text with escaped regex characters.</returns>
    Private Function ConvertFindWhatToRegEx(ByVal original As String) As String
        Dim specialChars() As Char = "\.*+^$><[]|{}:@#()~".ToCharArray
        Dim c As Char
        For Each c In specialChars
            original = original.Replace(c.ToString, "\" & c.ToString)
        Next

        ' Starting with VS 2012, the regex syntax in Find dialog has changed. It is now
        ' the same as .NET regex where \r is defined and needed.
        If GetVsVersion() > 10 Then
            original = original.Replace(vbCrLf, "((\r\n)|\n|\r)")
        Else
            original = original.Replace(vbCrLf, "\n")
        End If

        Return original
    End Function


    '''<summary>Transforms the 'Replace with' text to regular expression syntax in Replace field.</summary>
    '''<param name="original">Original text.</param>
    '''<returns>Text with some escaped regex characters.</returns>
    Private Function ConvertReplaceWithToRegEx(ByVal original As String) As String
        Dim specialChars() As Char = "\".ToCharArray
        Dim c As Char
        For Each c In specialChars
            original = original.Replace(c.ToString, "\" & c.ToString)
        Next

        ' Starting with VS 2012, the regex syntax in Find dialog has changed. It is now
        ' the same as .NET regex where \r is defined and needed.
        If GetVsVersion() > 10 Then
            original = original.Replace(vbCrLf, "\r\n")
        Else
            original = original.Replace(vbCrLf, "\n")
        End If

        Return original
    End Function


End Class


'''<summary>Types of find/replace operations.</summary>
Public Enum FindReplaceKind
    '''<summary>Find</summary>
    find
    '''<summary>Find In Files</summary>
    findInFiles
    '''<summary>Replace</summary>
    replace
    '''<summary>Replace in Files</summary>
    replaceInFiles
    '''<summary>None. Cancel was pressed.</summary>
    none
End Enum
