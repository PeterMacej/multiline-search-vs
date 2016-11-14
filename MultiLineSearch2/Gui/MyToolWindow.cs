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
            control.Canceling += control_Canceling;

            base.Content = control;
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


        private void control_Canceling(object sender, System.ComponentModel.CancelEventArgs args)
        {
            try
            {
                IVsWindowFrame winFrame = this.Frame as IVsWindowFrame;
                if (winFrame != null)
                {
                    winFrame.CloseFrame(Convert.ToUInt32(__FRAMECLOSE.FRAMECLOSE_NoSave));
                }
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
            MultilineSearchControlOptions ctrlOptions = default(MultilineSearchControlOptions);
            ctrlOptions = control.GetOptions();
            try
            {
                MultiLineSearchPackage pkg = this.Package as MultiLineSearchPackage;
                if (pkg != null)
                {
                    OptionPageMultilineFindReplace options = pkg.PackageOptions;
                    if (options != null)
                    {
                        options.IgnoreLeadingWs = ctrlOptions.IgnoreLeadingWhitespaces;
                        options.IgnoreTrailingWs = ctrlOptions.IgnoreTrailingWhitespaces;
                        options.IgnoreAllWs = ctrlOptions.IgnoreAllWhitespaces;
                        options.IsFindOptionsCollapsed = ctrlOptions.IsFindOptionsCollapsed;
                        options.SplitterPosition = ctrlOptions.SplitterPosition;
                        options.SaveSettingsToStorage();
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
            ctrlOptions.HideCancelButton = true;
            try
            {
                // load options
                MultiLineSearchPackage pkg = this.Package as MultiLineSearchPackage;
                if (pkg != null)
                {
                    OptionPageMultilineFindReplace options = pkg.PackageOptions;
                    if (options != null)
                    {
                        ctrlOptions.IgnoreLeadingWhitespaces = options.IgnoreLeadingWs;
                        ctrlOptions.IgnoreTrailingWhitespaces = options.IgnoreTrailingWs;
                        ctrlOptions.IgnoreAllWhitespaces = options.IgnoreAllWs;
                        ctrlOptions.IsFindOptionsCollapsed = options.IsFindOptionsCollapsed;
                        ctrlOptions.SplitterPosition = options.SplitterPosition;
                    }
                }
            }
            catch (Exception ex)
            {
            }
            control.SetOptions(ctrlOptions);
        }
    }

}

