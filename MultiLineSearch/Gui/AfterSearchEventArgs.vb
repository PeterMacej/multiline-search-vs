Imports System
Imports Helixoft.MultiLineSearch.SearchReplace

Namespace Gui

    ''' <summary>
    ''' Provides data for the <see cref="MultilineSearchControl.AfterSearch"/> event.
    ''' </summary>
    ''' <remarks></remarks>
    Public Class AfterSearchEventArgs
    Inherits EventArgs


#Region "Properties"

        Private ReadOnly mSearchOptions As FindReplaceOptions = Nothing
        '''<summary>Gets a search operation kind.</summary>
        '''<value>The value specifying which search button was pressed.</value>
        Public ReadOnly Property SearchOptions() As FindReplaceOptions
            Get
                Return mSearchOptions
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


        Sub New(ByVal searchOptions As FindReplaceOptions, ByVal findText As String, ByVal replaceText As String)
            Me.mSearchOptions = searchOptions
            Me.mFindText = findText
            Me.mReplaceText = replaceText
        End Sub

    End Class

End Namespace
