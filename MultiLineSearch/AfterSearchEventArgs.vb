Imports System


''' <summary>
''' Provides data for the <see cref="MultilineSearchControl.AfterSearch"/> event.
''' </summary>
''' <remarks></remarks>
Public Class AfterSearchEventArgs
    Inherits EventArgs


#Region "Properties"

    Private ReadOnly mSearchKind As FindReplaceKind = FindReplaceKind.None
    '''<summary>Gets a search operation kind.</summary>
    '''<value>The value specifying which search button was pressed.</value>
    Public ReadOnly Property SearchKind() As FindReplaceKind
        Get
            Return mSearchKind
        End Get
    End Property


    Private ReadOnly mFindText As String
    '''<summary>Gets escaped multiline text to be searched.</summary>
    '''<value></value>
    Public ReadOnly Property FindText() As String
        Get
            Return mFindText
        End Get
    End Property


    Private ReadOnly mReplaceText As String
    '''<summary>Gets escaped multiline replace text.</summary>
    '''<value></value>
    Public ReadOnly Property ReplaceText() As String
        Get
            Return mReplaceText
        End Get
    End Property
#End Region


    Sub New(ByVal searchKind As FindReplaceKind, ByVal findText As String, ByVal replaceText As String)
        Me.mSearchKind = searchKind
        Me.mFindText = findText
        Me.mReplaceText = replaceText
    End Sub

End Class
