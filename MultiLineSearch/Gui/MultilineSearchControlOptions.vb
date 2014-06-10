
Namespace Gui

    ''' <summary>
    ''' Options of <see cref="MultilineSearchControl"/>.
    ''' </summary>
    ''' <remarks></remarks>
    Public Class MultilineSearchControlOptions

#Region "Properties"

        Private mHideCancelButton As Boolean = False
        ''' <summary>
        ''' Determines whether the Cancel button is hidden.
        ''' </summary>
        ''' <value></value>
        ''' <remarks></remarks>
        Public Property HideCancelButton() As Boolean
            Get
                Return mHideCancelButton
            End Get
            Set(ByVal value As Boolean)
                mHideCancelButton = value
            End Set
        End Property


        Private mIgnoreTrailingWhitespaces As Boolean
        ''' <summary>
        ''' Gets or sets a checked state of ignore trailing whitespaces
        ''' checkbox.
        ''' </summary>
        ''' <value><see langword="true"/> if the checkbox is checked; otherwise, <see langword="false"/>.</value>
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
        ''' Gets or sets a checked state of ignore leading whitespaces
        ''' checkbox.
        ''' </summary>
        ''' <value><see langword="true"/> if the checkbox is checked; otherwise, <see langword="false"/>.</value>
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
        ''' Gets or sets a checked state of ignore all whitespaces
        ''' checkbox.
        ''' </summary>
        ''' <value><see langword="true"/> if the checkbox is checked; otherwise, <see langword="false"/>.</value>
        ''' <remarks></remarks>
        Public Property IgnoreAllWhitespaces() As Boolean
            Get
                Return mIgnoreAllWhitespaces
            End Get
            Set(ByVal value As Boolean)
                mIgnoreAllWhitespaces = value
            End Set
        End Property


        Private mIsFindOptionsCollapsed As Boolean
        ''' <summary>
        ''' Gets or sets a value indicating whether Find options section is collapsed
        ''' in Find/Search window.
        ''' </summary>
        ''' <value><see langword="true"/> if Find options section is collapsed; otherwise, <see langword="false"/>.</value>
        ''' <remarks></remarks>
        Public Property IsFindOptionsCollapsed() As Boolean
            Get
                Return mIsFindOptionsCollapsed
            End Get
            Set(ByVal value As Boolean)
                mIsFindOptionsCollapsed = value
            End Set
        End Property

#End Region
    End Class

End Namespace
