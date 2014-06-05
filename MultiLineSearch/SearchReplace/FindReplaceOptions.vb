Namespace SearchReplace

    ''' <summary>
    ''' Options for find/replace operations.
    ''' </summary>
    ''' <remarks></remarks>
    Public Class FindReplaceOptions

        Private mSearchKind As FindReplaceKind = FindReplaceKind.None
        ''' <summary>
        ''' Gets or sets a kind of search or replace operation.
        ''' </summary>
        ''' <value></value>
        ''' <remarks></remarks>
        Public Property SearchKind() As FindReplaceKind
            Get
                Return mSearchKind
            End Get
            Set(ByVal value As FindReplaceKind)
                mSearchKind = value
            End Set
        End Property


        Private mIgnoreTrailingWhitespaces As Boolean
        ''' <summary>
        ''' Gets or sets a value indicating whether trailing whitespaces
        ''' on each line are ignored.
        ''' </summary>
        ''' <value><see langword="true"/> if whitespaces are ignored; otherwise, <see langword="false"/>.</value>
        ''' <remarks></remarks>
        Public Property IgnoreTrailingWhitespaces() As Boolean
            Get
                Return mIgnoreTrailingWhitespaces
            End Get
            Set(ByVal value As Boolean)
                mIgnoreTrailingWhitespaces = value
            End Set
        End Property


        Private mIgnoreLeadingWhitespaces As Boolean
        ''' <summary>
        ''' Gets or sets a value indicating whether leading whitespaces
        ''' on each new line (not on the first one) are ignored.
        ''' </summary>
        ''' <value><see langword="true"/> if whitespaces are ignored; otherwise, <see langword="false"/>.</value>
        ''' <remarks></remarks>
        Public Property IgnoreLeadingWhitespaces() As Boolean
            Get
                Return mIgnoreLeadingWhitespaces
            End Get
            Set(ByVal value As Boolean)
                mIgnoreLeadingWhitespaces = value
            End Set
        End Property


        Private mIgnoreAllWhitespaces As Boolean
        ''' <summary>
        ''' Gets or sets a value indicating whether all whitespaces
        ''' are ignored.
        ''' </summary>
        ''' <value><see langword="true"/> if whitespaces are ignored; otherwise, <see langword="false"/>.</value>
        ''' <remarks>If this property is set to <see langword="true"/>, then
        ''' <see cref="IgnoreLeadingWhitespaces"/> and <see cref="IgnoreTrailingWhitespaces"/>
        ''' properties are ignored. </remarks>
        Public Property IgnoreAllWhitespaces() As Boolean
            Get
                Return mIgnoreAllWhitespaces
            End Get
            Set(ByVal value As Boolean)
                mIgnoreAllWhitespaces = value
            End Set
        End Property


    End Class

End Namespace
