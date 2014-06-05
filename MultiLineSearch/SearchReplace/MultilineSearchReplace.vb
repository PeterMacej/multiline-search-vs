Imports System
Imports EnvDTE80
Imports Helixoft.MultiLineSearch.Settings
Imports Microsoft.VisualBasic


Namespace SearchReplace

    ''' <summary>
    ''' Performs multiline search and replace in the VS IDE.
    ''' </summary>
    ''' <remarks></remarks>
    Friend Class MultilineSearchReplace
    Implements ISearchReplaceProvider


        Private ReadOnly dte As DTE2


        Public Sub New(ByVal dte As DTE2)
            If dte Is Nothing Then
                Throw New NullReferenceException()
            End If

            Me.dte = dte
        End Sub


        ''' <summary>
        ''' Execute search and replace operation.
        ''' </summary>
        ''' <param name="searchOptions"></param>
        ''' <param name="findText">Plain text, can contain newlines.</param>
        ''' <param name="replaceText">Plain text, can contain newlines.</param>
        Public Sub ExecSearchReplace(ByVal searchOptions As FindReplaceOptions, ByVal findText As String, ByVal replaceText As String) Implements ISearchReplaceProvider.ExecSearchReplace
            If searchOptions.SearchKind <> FindReplaceKind.None Then
                ' escape the texts to regex
                ConvertFindAndReplaceToRegEx(findText, replaceText)

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
                Select Case searchOptions.SearchKind
                    Case FindReplaceKind.Find
                        SetRegexInFindDialog()
                    Case FindReplaceKind.FindInFiles
                        SetRegexInFindInFilesDialog()
                    Case FindReplaceKind.Replace
                        SetRegexInFindDialog()
                    Case FindReplaceKind.ReplaceInFiles
                        SetRegexInFindInFilesDialog()
                    Case Else
                End Select

                dte.Find.FindWhat = findText
                dte.Find.ReplaceWith = replaceText

                Select Case searchOptions.SearchKind
                    Case FindReplaceKind.Find
                        dte.ExecuteCommand("Edit.Find")
                    Case FindReplaceKind.FindInFiles
                        dte.ExecuteCommand("Edit.FindinFiles")
                    Case FindReplaceKind.Replace
                        dte.ExecuteCommand("Edit.Replace")
                    Case FindReplaceKind.ReplaceInFiles
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


        ''' <summary>
        ''' Transforms the 'Find what' and the 'Replace with' texts to regular expression syntax.
        ''' </summary>
        ''' <param name="findWhat">The text in 'Find what' field.</param>
        ''' <param name="replaceWith">The text in 'Replace with' field.</param>
        ''' <remarks>The method converts original strings to strings with escaped regex characters.</remarks>
        Private Sub ConvertFindAndReplaceToRegEx(ByRef findWhat As String, ByRef replaceWith As String)
            findWhat = ConvertFindWhatToRegEx(findWhat)
            replaceWith = ConvertReplaceWithToRegEx(replaceWith)

            ' define an empty group in Find what, if necessary
            If GetVsVersion() > 10 Then
                If replaceWith.IndexOf("$+") >= 0 Then
                    ' replaceWith contains the $+ which substitutes the last group
                    findWhat &= "()" ' create the last (and only) (and empty) group
                End If
            End If

        End Sub


        '''<summary>Transforms the 'Find what' text to regular expression syntax.</summary>
        '''<param name="original">Original text.</param>
        '''<returns>Text with escaped regex characters.</returns>
        Private Function ConvertFindWhatToRegEx(ByVal original As String) As String
            Dim specialChars() As Char = "\.*+^$><[]|{}:@#()~?!".ToCharArray
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
            ' Empty string
            If original.Length = 0 Then
                'If Replace text is empty, the Find dialog automatically
                'uses the last non-empty value from history. To prevent this,
                'we must pass some non-empty value which produces empty text.

                If GetVsVersion() > 10 Then
                    ' Starting with VS 2012, the regex syntax in Find dialog has changed. It is now
                    ' the same as .NET regex where $ is used for group replacement.
                    Return "$+" ' substitute the last group (which needs to be defined in 'Find what' and empty)
                Else
                    ' In VS 2005-2010, \number is used for group replacement
                    'The ninth regex tagged expression seems good for this as it is very
                    'unlikely that user will add 9 tagged expressions in Find field in
                    'original VS Find dialog after it is pre-filled with this macro.
                    Return "\9"
                End If
            End If

            ' Escape regex special chars used in Replace
            If GetVsVersion() > 10 Then
                ' Starting with VS 2012, the regex syntax in Find dialog has changed. It is now
                ' the same as .NET regex where $ is used for group replacement.
                original = original.Replace("$"c, "$$")
                ' All other characters are treated as literals, except for \r \n and \t. All other
                ' combinations are OK. For test, try to replace with the following:
                ' \a\b\c\d\e\f\g\h\i\j\k\l\m\n\o\p\q\r\s\t\u\w\v\x\y\z\1\0\9\A\B\C\D\E\F\G\H\I\J\K\L\M\N\O\P\Q\R\S\T\U\W\V\X\Y\Z\~\!\@\#\$\%\^\&\*\(\)\-\=\+\?\<\>\:\"\'\[\]\{\}\/
                ' The \\ doesn't work for escaping the \ character. So we cannot escape \r with \\r. We
                ' need to use more complicated \$+r, where again, the $+ substitutes the last group
                ' (which needs to be defined in 'Find what' and empty). This is important if we want to replace
                ' with a text like:
                ' C:\MyFolder\root\nextLevel\test
                ' Without escaping we would get:
                ' C:\MyFolder
                ' oot
                ' extLevel  est
                original = original.Replace("\r", "\$+r")
                original = original.Replace("\n", "\$+n")
                original = original.Replace("\t", "\$+t")
            Else
                ' In VS 2005-2010, \number is used for group replacement
                ' All other characters are treated as literals.
                Dim specialChars() As Char
                specialChars = "\".ToCharArray
                Dim c As Char
                For Each c In specialChars
                    original = original.Replace(c.ToString, "\" & c.ToString)
                Next
            End If

            ' Escape newlines
            If GetVsVersion() > 10 Then
                ' Starting with VS 2012, the regex syntax in Find dialog has changed. It is now
                ' the same as .NET regex where \r is defined and needed.
                original = original.Replace(vbCrLf, "\r\n")
            Else
                original = original.Replace(vbCrLf, "\n")
            End If

            Return original
        End Function


    End Class

End Namespace


