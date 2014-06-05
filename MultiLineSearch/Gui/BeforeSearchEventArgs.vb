Imports system.ComponentModel
Imports Helixoft.MultiLineSearch.SearchReplace

Namespace Gui

    ''' <summary>
    ''' Provides data for the <see cref="MultilineSearchControl.BeforeSearch"/> event.
    ''' </summary>
    ''' <remarks></remarks>
    Public Class BeforeSearchEventArgs
    Inherits CancelEventArgs


#Region "Properties"

        Private mSearchKind As FindReplaceKind = FindReplaceKind.None
        '''<summary>Gets or sets a search operation kind.</summary>
        '''<value>The value specifying which search button was pressed.</value>
        Public Property SearchKind() As FindReplaceKind
            Get
                Return mSearchKind
            End Get
            Set(ByVal value As FindReplaceKind)
                mSearchKind = value
            End Set
        End Property


        Private mFindText As String
        '''<summary>Gets or sets escaped multiline text to be searched.</summary>
        '''<value></value>
        Public Property FindText() As String
            Get
                Return mFindText
            End Get
            Set(ByVal value As String)
                mFindText = value
            End Set
        End Property


        Private mReplaceText As String
        '''<summary>Gets or sets escaped multiline replace text.</summary>
        '''<value></value>
        Public Property ReplaceText() As String
            Get
                Return mReplaceText
            End Get
            Set(ByVal value As String)
                mReplaceText = value
            End Set
        End Property

#End Region


        Sub New(ByVal searchKind As FindReplaceKind, ByVal findText As String, ByVal replaceText As String)
            Me.SearchKind = searchKind
            Me.FindText = findText
            Me.ReplaceText = replaceText
        End Sub

    End Class

End Namespace
