Imports System


''' <summary>
''' Provides data for the <see cref="MultilineSearchControl.AfterSearch"/> event.
''' </summary>
''' <remarks></remarks>
Public Class AfterSearchEventArgs
    Inherits EventArgs


#Region "Properties"

    Private m_SearchKind As FindReplaceKind = FindReplaceKind.none
    '''<summary>Gets a search operation kind.</summary>
    '''<value>The value specifying which search button was pressed.</value>
    Public ReadOnly Property SearchKind() As FindReplaceKind
        Get
            Return m_SearchKind
        End Get
    End Property


    Private m_findText As String
    '''<summary>Gets escaped multiline text to be searched.</summary>
    '''<value></value>
    Public ReadOnly Property FindText() As String
        Get
            Return m_findText
        End Get
    End Property


    Private m_replaceText As String
    '''<summary>Gets escaped multiline replace text.</summary>
    '''<value></value>
    Public ReadOnly Property ReplaceText() As String
        Get
            Return m_replaceText
        End Get
    End Property
#End Region


    Sub New(ByVal searchKind As FindReplaceKind, ByVal findText As String, ByVal replaceText As String)
        Me.m_SearchKind = searchKind
        Me.m_findText = findText
        Me.m_replaceText = replaceText
    End Sub

End Class
