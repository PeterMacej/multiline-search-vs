Imports system.ComponentModel


''' <summary>
''' Provides data for the <see cref="MultilineSearchControl.BeforeSearch"/> event.
''' </summary>
''' <remarks></remarks>
Public Class BeforeSearchEventArgs
    Inherits CancelEventArgs


#Region "Properties"

    Private m_SearchKind As FindReplaceKind = FindReplaceKind.none
    '''<summary>Gets or sets a search operation kind.</summary>
    '''<value>The value specifying which search button was pressed.</value>
    Public Property SearchKind() As FindReplaceKind
        Get
            Return m_SearchKind
        End Get
        Set(ByVal value As FindReplaceKind)
            m_SearchKind = value
        End Set
    End Property


    Private m_findText As String
    '''<summary>Gets or sets escaped multiline text to be searched.</summary>
    '''<value></value>
    Public Property FindText() As String
        Get
            Return m_findText
        End Get
        Set(ByVal value As String)
            m_findText = value
        End Set
    End Property


    Private m_replaceText As String
    '''<summary>Gets or sets escaped multiline replace text.</summary>
    '''<value></value>
    Public Property ReplaceText() As String
        Get
            Return m_replaceText
        End Get
        Set(ByVal value As String)
            m_replaceText = value
        End Set
    End Property
#End Region


    Sub New(ByVal searchKind As FindReplaceKind, ByVal findText As String, ByVal replaceText As String)
        Me.SearchKind = searchKind
        Me.FindText = findText
        Me.ReplaceText = replaceText
    End Sub

End Class
