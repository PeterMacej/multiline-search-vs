
''' <summary>
''' Provides search and replace functionality.
''' </summary>
''' <remarks></remarks>
Public Interface ISearchReplaceProvider

    ''' <summary>
    ''' Execute search and replace operation.
    ''' </summary>
    ''' <param name="searchKind"></param>
    ''' <param name="findText"></param>
    ''' <param name="replaceText"></param>
    ''' <remarks></remarks>
    Sub ExecSearchReplace(ByVal searchKind As FindReplaceKind, ByVal findText As String, ByVal replaceText As String)
End Interface
