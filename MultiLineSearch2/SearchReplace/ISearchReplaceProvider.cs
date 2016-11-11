
namespace Helixoft.MultiLineSearch.SearchReplace
{

    /// <summary>
    /// Provides search and replace functionality.
    /// </summary>
    /// <remarks></remarks>
    public interface ISearchReplaceProvider
    {

        /// <summary>
        /// Execute search and replace operation.
        /// </summary>
        /// <param name="searchOptions">Search and replace options.</param>
        /// <param name="findText">Plain text, can contain newlines.</param>
        /// <param name="replaceText">Plain text, can contain newlines.</param>
        /// <remarks></remarks>

        void ExecSearchReplace(FindReplaceOptions searchOptions, string findText, string replaceText);
    }

}