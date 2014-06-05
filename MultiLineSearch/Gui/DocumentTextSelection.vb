Imports EnvDTE
Imports EnvDTE80

Namespace Gui

    ''' <summary>
    ''' Provides access to a text selection.
    ''' </summary>
    ''' <remarks></remarks>
    Public Class DocumentTextSelection

        ''' <summary>
        ''' Gets selected text in active document window.
        ''' </summary>
        ''' <returns>Nothing if not available (no text document, ...)</returns>
        ''' <remarks>If no selection is made, the active word is selected.</remarks>
        Public Shared Function GetActiveDocumentText(ByVal dte As DTE2) As String
            Dim res As String = Nothing

            If dte.ActiveDocument Is Nothing Then
                Return res
            End If

            Dim txtDoc As TextDocument = TryCast(dte.ActiveDocument.Object, TextDocument)
            If txtDoc Is Nothing Then
                Return res
            End If

            Dim sel As TextSelection
            sel = txtDoc.Selection
            If sel IsNot Nothing Then
                Try
                    If sel.IsEmpty Then
                        ' no selection, just caret, select a word
                        Dim line As String = sel.ActivePoint.CreateEditPoint.GetLines(sel.ActivePoint.Line, sel.ActivePoint.Line + 1)
                        res = GetWord(line, sel.ActivePoint.LineCharOffset - 1) ' LineCharOffset is 1 based
                    Else
                        res = sel.Text
                    End If
                Catch ex As Exception
                End Try
            End If

            Return res
        End Function


        ''' <summary>
        ''' For the current cursor position, gets the whole word.
        ''' </summary>
        ''' <param name="line">A text representing one line.</param>
        ''' <param name="cursorPosition">A cursor position inside the line. Zero based.</param>
        ''' <remarks>A word is defined as a set of alphanumeric characters AND underscore.
        ''' Unlike Word, IE and others, VS handles the '_' character as part of a word.
        ''' Moreover, IE selects also a space after a word. This method doesn't.</remarks>
        ''' <returns>A text with a word or Nothing if the cursor is not inside a word.</returns>
        Public Shared Function GetWord(ByVal line As String, ByVal cursorPosition As Integer) As String
            If line Is Nothing Then
                Return Nothing
            End If
            If cursorPosition < 0 OrElse cursorPosition >= line.Length Then
                Return Nothing
            End If

            Dim start As Integer = cursorPosition
            Dim endd As Integer = cursorPosition

            ' find start of a word
            Do
                start -= 1
            Loop While start >= 0 AndAlso IsWord(line.Substring(start, endd - start))
            ' we found a non-word character or moved to -1, move back one character
            start += 1

            ' find end of a word
            Do
                endd += 1
            Loop While endd < line.Length AndAlso IsWord(line.Substring(start, endd - start + 1))
            ' we found a non-word character or moved after line, move back one character
            endd -= 1

            Dim res As String
            res = line.Substring(start, endd - start + 1)
            If res.Length = 0 Then
                res = Nothing
            End If
            Return res
        End Function


        ''' <summary>
        ''' Determines whether a string is a word.
        ''' </summary>
        ''' <param name="str">String to test.</param>
        ''' <returns>True if the string contains only alphanumeric characters or underscore.
        ''' For an empty string or null, false is returned.</returns>
        ''' <remarks>A word is defined as a set of alphanumeric characters AND underscore.
        ''' Unlike Word, IE and others, VS handles the '_' character as a part of a word.
        ''' </remarks>
        Private Shared Function IsWord(ByVal str As String) As Boolean
            If String.IsNullOrEmpty(str) Then
                Return False
            End If

            For Each c As Char In str.ToCharArray
                If Not (Char.IsLetterOrDigit(c) OrElse c = "_"c) Then
                    Return False
                End If
            Next

            Return True
        End Function

    End Class

End Namespace
