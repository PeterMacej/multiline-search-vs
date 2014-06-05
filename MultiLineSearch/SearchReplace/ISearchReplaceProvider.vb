
Namespace SearchReplace

    ''' <summary>
    ''' Provides search and replace functionality.
    ''' </summary>
    ''' <remarks></remarks>
    Public Interface ISearchReplaceProvider

        ''' <summary>
        ''' Execute search and replace operation.
        ''' </summary>
        ''' <param name="searchOptions">Search and replace options.</param>
        ''' <param name="findText">Plain text, can contain newlines.</param>
        ''' <param name="replaceText">Plain text, can contain newlines.</param>
        ''' <remarks></remarks>
        Sub ExecSearchReplace(ByVal searchOptions As FindReplaceOptions, ByVal findText As String, ByVal replaceText As String)

    End Interface

End Namespace
