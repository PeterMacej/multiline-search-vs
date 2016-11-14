
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

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
        /// Determines whether the Cancel button is hidden.
        /// </summary>
        /// <value></value>
        /// <remarks></remarks>
        public bool HideCancelButton { get; set; } = false;


        /// <summary>
        /// Gets or sets a checked state of ignore trailing whitespaces
        /// checkbox.
        /// </summary>
        /// <value><see langword="true"/> if the checkbox is checked; otherwise, <see langword="false"/>.</value>
        /// <remarks></remarks>
        public bool IgnoreTrailingWhitespaces { get; set; }


        /// <summary>
        /// Gets or sets a checked state of ignore leading whitespaces
        /// checkbox.
        /// </summary>
        /// <value><see langword="true"/> if the checkbox is checked; otherwise, <see langword="false"/>.</value>
        /// <remarks></remarks>
        public bool IgnoreLeadingWhitespaces { get; set; }


        /// <summary>
        /// Gets or sets a checked state of ignore all whitespaces
        /// checkbox.
        /// </summary>
        /// <value><see langword="true"/> if the checkbox is checked; otherwise, <see langword="false"/>.</value>
        /// <remarks></remarks>
        public bool IgnoreAllWhitespaces { get; set; }


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

        #endregion
    }

}
