
namespace Helixoft.MultiLineSearch.SearchReplace
{

    /// <summary>
    /// Options for find/replace operations.
    /// </summary>
    /// <remarks></remarks>
    public class FindReplaceOptions
    {

        private FindReplaceKind mSearchKind = FindReplaceKind.None;
        /// <summary>
        /// Gets or sets a kind of search or replace operation.
        /// </summary>
        /// <value></value>
        /// <remarks></remarks>
        public FindReplaceKind SearchKind
        {
            get { return mSearchKind; }
            set { mSearchKind = value; }
        }


        private bool mIgnoreTrailingWhitespaces;
        /// <summary>
        /// Gets or sets a value indicating whether trailing whitespaces
        /// on each line are ignored.
        /// </summary>
        /// <value><see langword="true"/> if whitespaces are ignored; otherwise, <see langword="false"/>.</value>
        /// <remarks></remarks>
        public bool IgnoreTrailingWhitespaces
        {
            get { return mIgnoreTrailingWhitespaces; }
            set { mIgnoreTrailingWhitespaces = value; }
        }


        private bool mIgnoreLeadingWhitespaces;
        /// <summary>
        /// Gets or sets a value indicating whether leading whitespaces
        /// on each new line (not on the first one) are ignored.
        /// </summary>
        /// <value><see langword="true"/> if whitespaces are ignored; otherwise, <see langword="false"/>.</value>
        /// <remarks></remarks>
        public bool IgnoreLeadingWhitespaces
        {
            get { return mIgnoreLeadingWhitespaces; }
            set { mIgnoreLeadingWhitespaces = value; }
        }


        private bool mIgnoreAllWhitespaces;
        /// <summary>
        /// Gets or sets a value indicating whether all whitespaces
        /// are ignored.
        /// </summary>
        /// <value><see langword="true"/> if whitespaces are ignored; otherwise, <see langword="false"/>.</value>
        /// <remarks>If this property is set to <see langword="true"/>, then
        /// <see cref="IgnoreLeadingWhitespaces"/> and <see cref="IgnoreTrailingWhitespaces"/>
        /// properties are ignored. </remarks>
        public bool IgnoreAllWhitespaces
        {
            get { return mIgnoreAllWhitespaces; }
            set { mIgnoreAllWhitespaces = value; }
        }


        public FindReplaceOptions Clone()
        {
            FindReplaceOptions res = new FindReplaceOptions();
            res.SearchKind = this.SearchKind;
            res.IgnoreLeadingWhitespaces = this.IgnoreLeadingWhitespaces;
            res.IgnoreTrailingWhitespaces = this.IgnoreTrailingWhitespaces;
            res.IgnoreAllWhitespaces = this.IgnoreAllWhitespaces;

            return res;
        }

    }

}
