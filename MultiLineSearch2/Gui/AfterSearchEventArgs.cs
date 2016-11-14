
using System;
using System.Collections;
using System.Collections.Generic;
using Helixoft.MultiLineSearch.SearchReplace;

namespace Helixoft.MultiLineSearch.Gui
{

    /// <summary>
    /// Provides data for the <see cref="MultilineSearchControl.AfterSearch"/> event.
    /// </summary>
    /// <remarks></remarks>
    public class AfterSearchEventArgs : EventArgs
    {


        #region "Properties"

        private readonly FindReplaceOptions mSearchOptions = null;
        ///<summary>Gets a search operation kind.</summary>
        ///<value>The value specifying which search button was pressed.</value>
        public FindReplaceOptions SearchOptions
        {
            get { return mSearchOptions; }
        }



        private readonly string mFindText;
        ///<summary>Gets escaped multiline text to be searched.</summary>
        ///<value></value>
        public string FindText
        {
            get { return mFindText; }
        }



        private readonly string mReplaceText;
        ///<summary>Gets escaped multiline replace text.</summary>
        ///<value></value>
        public string ReplaceText
        {
            get { return mReplaceText; }
        }

        #endregion


        public AfterSearchEventArgs(FindReplaceOptions searchOptions, string findText, string replaceText)
        {
            this.mSearchOptions = searchOptions;
            this.mFindText = findText;
            this.mReplaceText = replaceText;
        }

    }

}
