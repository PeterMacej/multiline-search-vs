
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Helixoft.MultiLineSearch.Settings;

namespace Helixoft.MultiLineSearch.Gui
{

    /// <summary>
    /// Options of <see cref="MultilineSearchControl"/>.
    /// </summary>
    /// <remarks></remarks>
    public class MultilineSearchControlOptions
    {

        #region "Properties"

        /// <summary>
        /// Gets or sets a value indicating whether Find options section is collapsed
        /// in Find/Search window.
        /// </summary>
        /// <value><see langword="true"/> if Find options section is collapsed; otherwise, <see langword="false"/>.</value>
        /// <remarks></remarks>
        public bool IsFindOptionsCollapsed { get; set; }


        /// <summary>
        /// Gets or sets a position (in percents) of splitter between 'Find what' and 'Replace with' text boxes.
        /// </summary>
        /// <value></value>
        /// <remarks></remarks>
        public int SplitterPosition { get; set; }


        private SavedSearchList _SavedSearches;
        /// <summary>
        /// Gets or sets all saved searches.
        /// </summary>
        /// <value></value>
        public SavedSearchList SavedSearches
        {
            get
            {
                if (_SavedSearches == null)
                {
                    _SavedSearches = new SavedSearchList();
                }
                return _SavedSearches;
            }
            set
            {
                _SavedSearches = value;
            }
        }

        #endregion
    }

}
