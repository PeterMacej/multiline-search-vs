using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Microsoft.VisualStudio.Shell;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Windows.Forms;


namespace Helixoft.MultiLineSearch.Settings
{

    /// <summary>
    /// Package options
    /// </summary>
    /// <remarks></remarks>
    [ClassInterface(ClassInterfaceType.AutoDual), Guid("E0B68D27-9489-4053-AB39-6701AC637C30")]
    public class OptionPageMultilineFindReplace : DialogPage
    {


        public OptionPageMultilineFindReplace()
        {
            SetDefaultValues();
        }


        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected override IWin32Window Window
        {
            // get default grid view, we will never display the page
            get { return base.Window; }
        }


        protected override void OnApply(Microsoft.VisualStudio.Shell.DialogPage.PageApplyEventArgs e)
        {
            // persist settings
            base.OnApply(e);
        }


        protected override void OnActivate(System.ComponentModel.CancelEventArgs e)
        {
            base.OnActivate(e);
        }


        /// <summary>
        /// Set default values.
        /// </summary>
        /// <remarks></remarks>
        public override void ResetSettings()
        {
            SetDefaultValues();
            base.ResetSettings();
        }


        /// <summary>
        /// Set default values.
        /// </summary>
        /// <remarks></remarks>
        private void SetDefaultValues()
        {
            this.IsFindOptionsCollapsed = false;
            this.IgnoreLeadingWs = false;
            this.IgnoreTrailingWs = false;
            this.IgnoreAllWs = false;
            this.SplitterPosition = 100;
        }


        #region "Settings properties"


        private bool mIsFindOptionsCollapsed;
        /// <summary>
        /// Gets or sets a value indicating whether Find options section is collapsed
        /// in Find/Search window.
        /// </summary>
        /// <value><see langword="true"/> if Find options section is collapsed; otherwise, <see langword="false"/>.</value>
        /// <remarks></remarks>
        public bool IsFindOptionsCollapsed
        {
            get { return mIsFindOptionsCollapsed; }
            set { mIsFindOptionsCollapsed = value; }
        }


        private bool mIgnoreLeadingWs;
        /// <summary>
        /// Gets or sets a value indicating whether to ignore leading whitespaces.
        /// </summary>
        /// <value><see langword="true"/> if leading whitespaces are ignored; otherwise, <see langword="false"/>.</value>
        /// <remarks></remarks>
        public bool IgnoreLeadingWs
        {
            get { return mIgnoreLeadingWs; }
            set { mIgnoreLeadingWs = value; }
        }


        private bool mIgnoreTrailingWs;
        /// <summary>
        /// Gets or sets a value indicating whether to ignore trailing whitespaces.
        /// </summary>
        /// <value><see langword="true"/> if trailing whitespaces are ignored; otherwise, <see langword="false"/>.</value>
        /// <remarks></remarks>
        public bool IgnoreTrailingWs
        {
            get { return mIgnoreTrailingWs; }
            set { mIgnoreTrailingWs = value; }
        }


        private bool mIgnoreAllWs;
        /// <summary>
        /// Gets or sets a value indicating whether to ignore all whitespaces.
        /// </summary>
        /// <value><see langword="true"/> if all whitespaces are ignored; otherwise, <see langword="false"/>.</value>
        /// <remarks></remarks>
        public bool IgnoreAllWs
        {
            get { return mIgnoreAllWs; }
            set { mIgnoreAllWs = value; }
        }


        private int mSplitterPosition;
        /// <summary>
        /// Gets or sets a position (in percents) of splitter between 'Find what' and 'Replace with' text boxes.
        /// </summary>
        /// <value></value>
        /// <remarks></remarks>
        public int SplitterPosition
        {
            get { return mSplitterPosition; }
            set { mSplitterPosition = value; }
        }

        #endregion


    }

}
