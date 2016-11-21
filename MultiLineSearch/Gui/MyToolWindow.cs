using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.Shell;
using Helixoft.MultiLineSearch.SearchReplace;
using Helixoft.MultiLineSearch.Settings;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;


namespace Helixoft.MultiLineSearch.Gui
{
    /// <summary>
    /// This class implements the tool window exposed by this package and hosts a user control.
    ///
    /// In Visual Studio tool windows are composed of a frame (implemented by the shell) and a pane, 
    /// usually implemented by the package implementer.
    ///
    /// This class derives from the ToolWindowPane class provided from the MPF in order to use its 
    /// implementation of the IVsUIElementPane interface.
    /// </summary>
    [Guid("5c82a791-7c9f-441e-952b-8848655dd85e")]
    public class MyToolWindow : ToolWindowPane
    {

        // This is the user control hosted by the tool window; it is exposed to the base class 
        // using the Content property. Note that, even if this class implements IDispose, we are
        // not calling Dispose on this object. This is because ToolWindowPane calls Dispose on 
        // the object returned by the Content property.
        private MultilineSearchControl control;


        #region "Properties"

        /// <summary>
        /// Gets the DTE object.
        /// </summary>
        /// <value>Nothing if the IDE is not yet fully initialized.</value>
        /// <remarks></remarks>
        private EnvDTE80.DTE2 Dte
        {
            get
            {
                MultiLineSearchPackage pkg = this.Package as MultiLineSearchPackage;
                if (pkg == null)
                {
                    return null;
                }
                else
                {
                    return pkg.Dte;
                }
            }
        }



        private ISearchReplaceProvider mSearchProvider = null;
        /// <summary>
        /// Gets the ISearchReplaceProvider to be used.
        /// </summary>
        /// <value>Nothing if the IDE is not yet fully initialized.</value>
        /// <remarks></remarks>
        private ISearchReplaceProvider SearchProvider
        {
            get
            {
                if (mSearchProvider == null)
                {
                    if (this.Dte != null)
                    {
                        mSearchProvider = new MultilineSearchReplace(this.Dte);
                    }
                }
                return mSearchProvider;
            }
        }


        #endregion





        /// <summary>
        /// Standard constructor for the tool window.
        /// </summary>
        public MyToolWindow() :
            base(null)
        {
            // Set the window title reading it from the resources.
            this.Caption = Resources.ToolWindowTitle;
            // Set the image that will appear on the tab of the window frame
            // when docked with an other window
            // The resource ID correspond to the one defined in the resx file
            // while the Index is the offset in the bitmap strip. Each image in
            // the strip being 16x16.
            this.BitmapResourceID = 301;
            this.BitmapIndex = 0;

            // This is the user control hosted by the tool window; Note that, even if this class implements IDisposable,
            // we are not calling Dispose on this object. This is because ToolWindowPane calls Dispose on 
            // the object returned by the Content property.
            control = new MultilineSearchControl();
            control.BeforeSearch += control_BeforeSearch;

            base.Content = control;
        }


        /// <summary>
        /// Process F1.
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        protected override bool PreProcessMessage(ref Message m)
        {
            const int WM_KEYDOWN = 0x100;
            if (m.Msg== WM_KEYDOWN)
            {
                Keys keyCode = (Keys)m.WParam & Keys.KeyCode;
                switch (keyCode)
                {
                    case Keys.F1:
                        // F1 is not passed to this.Content by Visual Studio.
                        // Instead, it always opens MSDN.
                        // Let's pass F1 manually here and stop VS from opening MSDN.
                        SendKeys.Send(Key.F1);
                        return true;    // processed
                        break;
                }
                        
            }
            return base.PreProcessMessage(ref m);
        }


        /// <summary>
        /// Performs necessary initialization when the tool window is shown.
        /// </summary>
        /// <remarks>This method should be called before Show call.</remarks>
        public void InitializeContent()
        {
            try
            {
                // pre-populate Find What field, if needed
                bool findInit = false;
                try
                {
                    EnvDTE.Properties props = default(EnvDTE.Properties);
                    props = Dte.Properties["Environment", "FindAndReplace"];
                    EnvDTE.Property prop = props.Item("InitializeFromEditor");
                    findInit = Convert.ToBoolean(prop.Value);
                }
                catch (Exception ex2)
                {
                }

                if (findInit)
                {
                    string initText = DocumentTextSelection.GetActiveDocumentText(Dte);
                    if (initText != null)
                    {
                        this.control.FindText = initText;
                    }
                }

            }
            catch (Exception ex)
            {
            }
        }


        private void control_BeforeSearch(object sender, BeforeSearchEventArgs args)
        {
            try
            {
                // set the search provider on the last possible moment (to be sure it's not null)
                this.control.SearchProvider = this.SearchProvider;
            }
            catch (Exception ex)
            {
            }
        }


        //' not used
        //Public Overrides Sub OnToolWindowCreated()
        //    MyBase.OnToolWindowCreated()

        //    ' register window frame events
        //    Dim windowFrameEventsHandler As New ToolWindowFrameEvents()
        //    ErrorHandler.ThrowOnFailure( _
        //        (DirectCast(Me.Frame, IVsWindowFrame)).SetProperty( _
        //        CInt(__VSFPROPID.VSFPROPID_ViewHelper), _
        //        windowFrameEventsHandler))
        //End Sub


        protected override void OnClose()
        {
            // save options
            MultilineSearchControlOptions ctrlOptions;
            ctrlOptions = control.GetOptions();
            FindReplaceOptions searchOptions;
            searchOptions = control.SearchOptions;
            try
            {
                MultiLineSearchPackage pkg = this.Package as MultiLineSearchPackage;
                if (pkg != null)
                {
                    OptionPageMultilineFindReplace pkgOptions = pkg.PackageOptions;
                    if (pkgOptions != null)
                    {
                        pkgOptions.IgnoreLeadingWs = searchOptions.IgnoreLeadingWhitespaces;
                        pkgOptions.IgnoreTrailingWs = searchOptions.IgnoreTrailingWhitespaces;
                        pkgOptions.IgnoreAllWs = searchOptions.IgnoreAllWhitespaces;
                        pkgOptions.IsFindOptionsCollapsed = ctrlOptions.IsFindOptionsCollapsed;
                        pkgOptions.SplitterPosition = ctrlOptions.SplitterPosition;
                        pkgOptions.SaveSettingsToStorage();
                    }
                }
            }
            catch (Exception ex)
            {
            }

            base.OnClose();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Unlike in constructor, when this method is called, the package is already created and we
        /// can use it for retrieving the settings.
        /// </remarks>
        public override void OnToolWindowCreated()
        {
            base.OnToolWindowCreated();

            // load options
            MultilineSearchControlOptions ctrlOptions = new MultilineSearchControlOptions();
            FindReplaceOptions searchOptions = new FindReplaceOptions();
            try
            {
                // load options
                MultiLineSearchPackage pkg = this.Package as MultiLineSearchPackage;
                if (pkg != null)
                {
                    OptionPageMultilineFindReplace options = pkg.PackageOptions;
                    if (options != null)
                    {
                        searchOptions.IgnoreLeadingWhitespaces = options.IgnoreLeadingWs;
                        searchOptions.IgnoreTrailingWhitespaces = options.IgnoreTrailingWs;
                        searchOptions.IgnoreAllWhitespaces = options.IgnoreAllWs;
                        ctrlOptions.IsFindOptionsCollapsed = options.IsFindOptionsCollapsed;
                        ctrlOptions.SplitterPosition = options.SplitterPosition;
                    }
                }
            }
            catch (Exception ex)
            {
            }
            control.SetOptions(ctrlOptions);
            control.SearchOptions = searchOptions;
        }
    }

}

