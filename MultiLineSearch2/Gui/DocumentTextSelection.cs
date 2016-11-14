using System;
using System.Collections;
using System.Collections.Generic;
using EnvDTE;
using EnvDTE80;


namespace Helixoft.MultiLineSearch.Gui
{

    /// <summary>
    /// Provides access to a text selection.
    /// </summary>
    /// <remarks></remarks>
    public class DocumentTextSelection
    {

        /// <summary>
        /// Gets selected text in active document window.
        /// </summary>
        /// <returns>Nothing if not available (no text document, ...)</returns>
        /// <remarks>If no selection is made, the active word is selected.</remarks>
        public static string GetActiveDocumentText(DTE2 dte)
        {
            string res = null;

            if (dte.ActiveDocument == null)
            {
                return res;
            }

            TextDocument txtDoc = dte.ActiveDocument.Object() as TextDocument;
            if (txtDoc == null)
            {
                return res;
            }

            TextSelection sel = default(TextSelection);
            sel = txtDoc.Selection;
            if (sel != null)
            {
                try
                {
                    if (sel.IsEmpty)
                    {
                        // no selection, just caret, select a word
                        string line = sel.ActivePoint.CreateEditPoint().GetLines(sel.ActivePoint.Line, sel.ActivePoint.Line + 1);
                        res = GetWord(line, sel.ActivePoint.LineCharOffset - 1);
                        // LineCharOffset is 1 based
                    }
                    else
                    {
                        res = sel.Text;
                    }
                }
                catch (Exception ex)
                {
                }
            }

            return res;
        }


        /// <summary>
        /// For the current cursor position, gets the whole word.
        /// </summary>
        /// <param name="line">A text representing one line.</param>
        /// <param name="cursorPosition">A cursor position inside the line. Zero based.</param>
        /// <remarks>A word is defined as a set of alphanumeric characters AND underscore.
        /// Unlike Word, IE and others, VS handles the '_' character as part of a word.
        /// Moreover, IE selects also a space after a word. This method doesn't.</remarks>
        /// <returns>A text with a word or Nothing if the cursor is not inside a word.</returns>
        public static string GetWord(string line, int cursorPosition)
        {
            if (line == null)
            {
                return null;
            }
            if (cursorPosition < 0 || cursorPosition >= line.Length)
            {
                return null;
            }

            int start = cursorPosition;
            int endd = cursorPosition;

            // find start of a word
            do
            {
                start -= 1;
            } while (start >= 0 && IsWord(line.Substring(start, endd - start)));
            // we found a non-word character or moved to -1, move back one character
            start += 1;

            // find end of a word
            do
            {
                endd += 1;
            } while (endd < line.Length && IsWord(line.Substring(start, endd - start + 1)));
            // we found a non-word character or moved after line, move back one character
            endd -= 1;

            string res = null;
            res = line.Substring(start, endd - start + 1);
            if (res.Length == 0)
            {
                res = null;
            }
            return res;
        }


        /// <summary>
        /// Determines whether a string is a word.
        /// </summary>
        /// <param name="str">String to test.</param>
        /// <returns>True if the string contains only alphanumeric characters or underscore.
        /// For an empty string or null, false is returned.</returns>
        /// <remarks>A word is defined as a set of alphanumeric characters AND underscore.
        /// Unlike Word, IE and others, VS handles the '_' character as a part of a word.
        /// </remarks>
        private static bool IsWord(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return false;
            }

            foreach (char c in str.ToCharArray())
            {
                if (!(char.IsLetterOrDigit(c) || c == '_'))
                {
                    return false;
                }
            }

            return true;
        }

    }

}
