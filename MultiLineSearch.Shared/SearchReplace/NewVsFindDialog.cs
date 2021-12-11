using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell.Interop;
using System.Reflection;
using EnvDTE;

namespace Helixoft.MultiLineSearch.SearchReplace
{

    /// <summary>
    /// Provides interaction with the new 'Find/Replace in files' dialog introduced in VS 16.5. 
    /// </summary>
    /// <remarks>
    /// <para>
    /// Starting with VS 16.5, the new 'Find/Replace in files' dialog ignores the search strings stored in <see cref="EnvDTE.Find.FindWhat"/>
    /// and <see cref="EnvDTE.Find.ReplaceWith"/>. This helper class is needed to populate the new UI with specified values.
    /// </para>
    /// <para>
    /// This class uses undocumented Microsoft.VisualStudio.Editor.Implementation.NewFind.UI.NewFindDialog
    /// from Microsoft.VisualStudio.Editor.Implementation.dll via reflection.
    /// It's a hack, needs to be replaced with some more official implementation in the future.
    /// </para>
    /// </remarks>
    internal class NewVsFindDialog : ReflectionHelper
    {

        /// <summary>
        /// Populates the new 'Find/Replace in files' dialog introduced in VS 16.5+ with the required
        /// Find and Replace values and checks the Use regex checkbox.
        /// </summary>
        /// <param name="findText"></param>
        /// <param name="replaceText"></param>
        /// <param name="useRegex">The value of "Use regular expressions" checkbox.</param>
        public static void PopulateDialogValues(string findText, string replaceText, bool useRegex)
        {
            try
            {

                ThreadHelper.ThrowIfNotOnUIThread();

                // get Find/replace tool window
                //  get frame
                IVsUIShell vsUIShell = (IVsUIShell)Package.GetGlobalService(typeof(SVsUIShell));
                Guid guid = new Guid("6324226f-61b6-4f28-92ee-18d4b5fe1e48");    // Microsoft.VisualStudio.Editor.Implementation.NewFind.UI.NewFindDialog
                IVsWindowFrame windowFrame;
                int result = vsUIShell.FindToolWindow((uint)__VSFINDTOOLWIN.FTW_fFindFirst, ref guid, out windowFrame);   // Find MyToolWindow

                if (result != VSConstants.S_OK)
                {
                    return;
                }
                //  get pane
                object toolWinPane;
                windowFrame.GetProperty((int)__VSFPROPID.VSFPROPID_DocView, out toolWinPane);
                if (toolWinPane == null)
                {
                    return;
                }
                // The toolWinPane is of type ToolWindowPane, but it cannot be cast to it due to different versions of 
                // Microsoft.VisualStudio.Shell.XY.0 (used at runtime and referenced).

                // get Find/replace dialog control
                object newFindDlgCtrl = GetPropertyValue(toolWinPane, "Content");    // it's of type Microsoft.VisualStudio.Editor.Implementation.NewFind.UI.NewFindDialogControl
                if (newFindDlgCtrl == null)
                {
                    return;
                }

                // get Find/replace control (via the following field of newFindDlgCtrl):
                // private readonly Microsoft.VisualStudio.Editor.Implementation.NewFind.UI.FindReplaceControl _findReplaceControl;
                object _findReplaceControl = GetFieldValue(newFindDlgCtrl, "_findReplaceControl");
                if (_findReplaceControl == null)
                {
                    return;
                }

                // get Find combo box, which is of type Microsoft.VisualStudio.Editor.Implementation.NewFind.UI.OptionsControlledStringComboBox
                object _findPattern = GetFieldValue(_findReplaceControl, "_findPattern");
                if (_findPattern == null)
                {
                    // Starting with VS 16.9, this field has a new name "FindPattern", try to get it.
                    _findPattern = GetFieldValue(_findReplaceControl, "FindPattern");
                    if (_findPattern == null)
                    {
                        return;
                    }
                }
                // set the Find text
                ExecuteMethod(_findPattern, "SelectCurrentText");
                ExecuteMethod(_findPattern, "InsertTextInSelection", findText);

                // get Replace combo box, which is of type Microsoft.VisualStudio.Editor.Implementation.NewFind.UI.OptionsControlledStringComboBox
                object _replacePattern = GetFieldValue(_findReplaceControl, "_replacePattern");
                if (_replacePattern == null)
                {
                    // Starting with VS 16.9, this field has a new name "ReplacePattern", try to get it.
                    _replacePattern = GetFieldValue(_findReplaceControl, "ReplacePattern");
                    if (_replacePattern == null)
                    {
                        return;
                    }
                }
                // set the Replace text
                ExecuteMethod(_replacePattern, "SelectCurrentText");
                ExecuteMethod(_replacePattern, "InsertTextInSelection", replaceText);

                // Set Regex checkbox
                IEnumerable<object> _findWhatOptions = GetFieldValue(_findReplaceControl, "_findWhatOptions") as IEnumerable<object>;
                if (_findWhatOptions == null)
                {
                    return;
                }
                object regexCheckboxOptionCtrl = _findWhatOptions.FirstOrDefault(op => GetPropertyValue(op, "Name").ToString() == "find/useregex");
                if (regexCheckboxOptionCtrl == null)
                {
                    return;
                }
                System.Windows.Controls.CheckBox regexCheckbox = GetPropertyValue(regexCheckboxOptionCtrl, "Content") as System.Windows.Controls.CheckBox;
                regexCheckbox.IsChecked = useRegex;

            }
            catch (Exception)
            {
            }
        }

    }
}
