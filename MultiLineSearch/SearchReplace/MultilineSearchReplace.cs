
using System;
using System.Collections;
using System.Collections.Generic;
using EnvDTE80;
using Helixoft.MultiLineSearch.Settings;
using System.Text.RegularExpressions;


namespace Helixoft.MultiLineSearch.SearchReplace
{

    /// <summary>
    /// Performs multiline search and replace in the VS IDE.
    /// </summary>
    /// <remarks></remarks>
    internal class MultilineSearchReplace : ISearchReplaceProvider
    {



        private readonly DTE2 dte;

        public MultilineSearchReplace(DTE2 dte)
        {
            if (dte == null)
            {
                throw new NullReferenceException();
            }

            this.dte = dte;
        }


        /// <summary>
        /// Execute search and replace operation.
        /// </summary>
        /// <param name="searchOptions"></param>
        /// <param name="findText">Plain text, can contain newlines.</param>
        /// <param name="replaceText">Plain text, can contain newlines.</param>
        public void ExecSearchReplace(FindReplaceOptions searchOptions, string findText, string replaceText)
        {
            if (searchOptions.SearchKind != FindReplaceKind.None)
            {
                // escape the texts to regex
                ConvertFindAndReplaceToRegEx(ref findText, ref replaceText, searchOptions);

                // dte.Find.PatternSyntax = vsFindPatternSyntax.vsFindPatternSyntaxRegExpr   ' no effect in VS 2013
                switch (searchOptions.SearchKind)
                {
                    case FindReplaceKind.Find:
                        SetRegexInFindDialog();
                        break;
                    case FindReplaceKind.FindInFiles:
                        SetRegexInFindInFilesDialog();
                        break;
                    case FindReplaceKind.Replace:
                        SetRegexInFindDialog();
                        break;
                    case FindReplaceKind.ReplaceInFiles:
                        SetRegexInFindInFilesDialog();
                        break;
                    default:
                        break;
                }

                dte.Find.FindWhat = findText;
                dte.Find.ReplaceWith = replaceText;

                switch (searchOptions.SearchKind)
                {
                    case FindReplaceKind.Find:
                        dte.ExecuteCommand("Edit.Find");
                        break;
                    case FindReplaceKind.FindInFiles:
                        dte.ExecuteCommand("Edit.FindinFiles");
                        break;
                    case FindReplaceKind.Replace:
                        dte.ExecuteCommand("Edit.Replace");
                        break;
                    case FindReplaceKind.ReplaceInFiles:
                        dte.ExecuteCommand("Edit.ReplaceinFiles");
                        break;
                    default:
                        break;
                }
            }
        }


        /// <summary>
        /// Turns on the regex option in the Find/Replace dialog.
        /// </summary>
        /// <remarks>In VS 2005-2010?, it was enough to set 
        /// Dte.Find.PatternSyntax = vsFindPatternSyntax.vsFindPatternSyntaxRegExpr
        /// and the change was automatically reflected in Find and Find in Files dialogs.
        /// But at least in VS 2013, this change is ignored in the dialogs. Nothing helps,
        /// even Dte.Find.Execute doesn't apply the change.
        /// This method accesses appropriate settings directly and sets the correct
        /// values.
        /// </remarks>
        private void SetRegexInFindDialog()
        {
            try
            {
                IdeSettings settings = new IdeSettings();

                // Visual Studio Environment Package
                string pkgGuid = "{DA9FB551-C724-11d0-AE1F-00A0C90FFFC3}";
                // category Environment_UnifiedFind
                string categoryGuid = "{DF00ADDF-C14C-4ffd-9325-634FD605850B}";

                PackageMemorySettingsStore settingsStore = default(PackageMemorySettingsStore);
                settingsStore = settings.GetSettings(pkgGuid, categoryGuid);
                if (settingsStore != null)
                {
                    // set regex in Find and Find in Files dialogs
                    PackageMemorySettingsStore.Setting setting = null;
                    //All VS versions
                    if (settingsStore.Settings.TryGetValue("Options", out setting))
                    {
                        setting.Value = setting.Value.ToString().Replace(" Plain ", " Regex ");
                    }
                    // VS 2005-2010
                    if (settingsStore.Settings.TryGetValue("Document Options", out setting))
                    {
                        setting.Value = setting.Value.ToString().Replace(" Plain ", " Regex ");
                    }
                    // VS 2012-2013
                    if (settingsStore.Settings.TryGetValue("AdornmentOptions",out setting))
                    {
                        setting.Value = setting.Value.ToString().Replace(" Plain ", " Regex ");
                    }

                    settings.SetSettings(pkgGuid, categoryGuid, settingsStore);
                }
            }
            catch (Exception ex)
            {
            }
        }


        /// <summary>
        /// Turns on the regex option in the Find/Replace in Files dialog.
        /// </summary>
        /// <remarks>In VS 2005-2010?, it was enough to set 
        /// Dte.Find.PatternSyntax = vsFindPatternSyntax.vsFindPatternSyntaxRegExpr
        /// and the change was automatically reflected in Find and Find in Files dialogs.
        /// But at least in VS 2013, this change is ignored in the dialogs. Nothing helps,
        /// even Dte.Find.Execute doesn't apply the change.
        /// This method accesses appropriate settings directly and sets the correct
        /// values.
        /// </remarks>
        private void SetRegexInFindInFilesDialog()
        {
            try
            {
                IdeSettings settings = new IdeSettings();

                // Visual Studio Environment Package
                string pkgGuid = "{DA9FB551-C724-11d0-AE1F-00A0C90FFFC3}";
                // category Environment_UnifiedFind
                string categoryGuid = "{DF00ADDF-C14C-4ffd-9325-634FD605850B}";

                PackageMemorySettingsStore settingsStore = default(PackageMemorySettingsStore);
                settingsStore = settings.GetSettings(pkgGuid, categoryGuid);
                if (settingsStore != null)
                {
                    // set regex in Find and Find in Files dialogs
                    PackageMemorySettingsStore.Setting setting = null;
                    //All VS versions
                    if (settingsStore.Settings.TryGetValue("Options", out setting))
                    {
                        setting.Value = setting.Value.ToString().Replace(" Plain ", " Regex ");
                    }
                    // VS 2005-2010
                    if (settingsStore.Settings.TryGetValue("FiF Options", out setting))
                    {
                        setting.Value = setting.Value.ToString().Replace(" Plain ", " Regex ");
                    }
                    // VS 2012-2013
                    if (settingsStore.Settings.TryGetValue("DialogOptions",out setting))
                    {
                        setting.Value = setting.Value.ToString().Replace(" Plain ", " Regex ");
                    }

                    settings.SetSettings(pkgGuid, categoryGuid, settingsStore);
                }
            }
            catch (Exception ex)
            {
            }
        }


        //private double GetVsVersion()
        //{
        //    double version = 10;
        //    // default is VS 2010
        //    try
        //    {
        //        version = double.Parse(dte.Version, new System.Globalization.CultureInfo("en-US", false).NumberFormat);
        //        //use dot as decimal separator
        //    }
        //    catch (Exception ex)
        //    {
        //    }

        //    return version;
        //}


        /// <summary>
        /// Transforms the 'Find what' and the 'Replace with' texts to regular expression syntax.
        /// </summary>
        /// <param name="findWhat">The text in 'Find what' field.</param>
        /// <param name="replaceWith">The text in 'Replace with' field.</param>
        /// <param name="searchOptions">Search and replace options.</param>
        /// <remarks>The method converts original strings to strings with escaped regex characters.</remarks>
        private void ConvertFindAndReplaceToRegEx(ref string findWhat, ref string replaceWith, FindReplaceOptions searchOptions)
        {
            findWhat = ConvertFindWhatToRegEx(findWhat, searchOptions);
            replaceWith = ConvertReplaceWithToRegEx(replaceWith);

            // define an empty group in Find what, if necessary
            if (replaceWith.IndexOf("$+") >= 0)
            {
                // replaceWith contains the $+ which substitutes the last group
                findWhat += "()";
                // create the last (and only) (and empty) group
            }
        }


        /// <summary>Transforms the 'Find what' text to regular expression syntax.</summary>
        /// <param name="original">Original text.</param>
        /// <param name="searchOptions">Search and replace options.</param>
        /// <returns>Text with escaped regex characters.</returns>
        private string ConvertFindWhatToRegEx(string original, FindReplaceOptions searchOptions)
        {
            char[] specialChars = "\\.*+^$><[]|{}:@#()~?!".ToCharArray();
            char c = '\0';
            foreach (char c_loopVariable in specialChars)
            {
                c = c_loopVariable;
                original = original.Replace(c.ToString(), "\\" + c.ToString());
            }

            // normalize whitespaces
            if (searchOptions.IgnoreAllWhitespaces)
            {
                // normalize all whitespaces (including newlines)
                original = Regex.Replace(original, "(\\r|\\n| |\\t)+", "(\\r|\\n| |\\t)+");
                // RegexOptions.Singleline)' Singleline option will allow to match multi-line comments
            }
            else
            {
                if (searchOptions.IgnoreLeadingWhitespaces)
                {
                    original = Regex.Replace(original, "((\\r\\n)|\\n|\\r)( |\\t)*", "\r\n" + "( |\\t)*");
                }
                if (searchOptions.IgnoreTrailingWhitespaces)
                {
                    original = Regex.Replace(original, "( |\\t)*((\\r\\n)|\\n|\\r)", "( |\\t)*" + "\r\n");
                }
            }

            // Escape newlines
            original = original.Replace("\r\n", "((\\r\\n)|\\n|\\r)");

            return original;
        }


        ///<summary>Transforms the 'Replace with' text to regular expression syntax in Replace field.</summary>
        ///<param name="original">Original text.</param>
        ///<returns>Text with some escaped regex characters.</returns>
        private string ConvertReplaceWithToRegEx(string original)
        {
            // Empty string
            if (original.Length == 0)
            {
                //If Replace text is empty, the Find dialog automatically
                //uses the last non-empty value from history. To prevent this,
                //we must pass some non-empty value which produces empty text.

                // The $ is used for group replacement.
                return "$+";
                // substitute the last group (which needs to be defined in 'Find what' and empty)
            }

            // Escape regex special chars used in Replace
            // The $ is used for group replacement.
            original = original.Replace("$", "$$");
            // All other characters are treated as literals, except for \r \n and \t. All other
            // combinations are OK. For test, try to replace with the following:
            // \a\b\c\d\e\f\g\h\i\j\k\l\m\n\o\p\q\r\s\t\u\w\v\x\y\z\1\0\9\A\B\C\D\E\F\G\H\I\J\K\L\M\N\O\P\Q\R\S\T\U\W\V\X\Y\Z\~\!\@\#\$\%\^\&\*\(\)\-\=\+\?\<\>\:\"\'\[\]\{\}\/
            // The \\ doesn't work for escaping the \ character. So we cannot escape \r with \\r. We
            // need to use more complicated \$+r, where again, the $+ substitutes the last group
            // (which needs to be defined in 'Find what' and empty). This is important if we want to replace
            // with a text like:
            // C:\MyFolder\root\nextLevel\test
            // Without escaping we would get:
            // C:\MyFolder
            // oot
            // extLevel  est
            original = original.Replace("\\r", "\\$+r");
            original = original.Replace("\\n", "\\$+n");
            original = original.Replace("\\t", "\\$+t");

            // Escape newlines
            original = original.Replace("\r\n", "\\r\\n");

            return original;
        }


    }

}
