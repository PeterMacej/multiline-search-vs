using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Helixoft.MultiLineSearch.SearchReplace;


namespace Helixoft.MultiLineSearch.Gui
{

    /// <summary>
    /// Provides data for the <see cref="MultilineSearchControl.BeforeSearch"/> event.
    /// </summary>
    /// <remarks></remarks>
    public class BeforeSearchEventArgs : CancelEventArgs
    {


        #region "Properties"

        private FindReplaceOptions mSearchOptions = null;
        ///<summary>Gets or sets a search operation kind.</summary>
        ///<value>The value specifying which search button was pressed.</value>
        public FindReplaceOptions SearchOptions
        {
            get { return mSearchOptions; }
            set { mSearchOptions = value; }
        }


        private string mFindText;
        ///<summary>Gets or sets escaped multiline text to be searched.</summary>
        ///<value></value>
        public string FindText
        {
            get { return mFindText; }
            set { mFindText = value; }
        }


        private string mReplaceText;
        ///<summary>Gets or sets escaped multiline replace text.</summary>
        ///<value></value>
        public string ReplaceText
        {
            get { return mReplaceText; }
            set { mReplaceText = value; }
        }

        #endregion


        public BeforeSearchEventArgs(FindReplaceOptions searchOptions, string findText, string replaceText)
        {
            this.SearchOptions = searchOptions;
            this.FindText = findText;
            this.ReplaceText = replaceText;
        }

    }

}
