﻿Imports System.Security.Permissions
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports system.ComponentModel

'''<summary>
'''  Multiline search controls.
'''</summary>
Public Class MultilineSearchControl
    Inherits UserControl


    ''' <summary>
    ''' Occurs before the control is canceled.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="args"></param>
    ''' <remarks>The Canceling event occurs as the control is being canceled with Cancel button.
    ''' When a control is canceled, its parent form is closed.
    ''' To cancel the closure of a form, set the Cancel property
    ''' of the <see cref="CancelEventArgs"/> passed to your event handler to true.</remarks>
    Public Event Canceling(ByVal sender As Object, ByVal args As CancelEventArgs)


    ''' <summary>
    ''' Occurs before the search is executed.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="args"></param>
    ''' <remarks>This event occurs before the control executes a search
    ''' initiated with any of the search buttons.
    ''' You can change the search parameters by modifying properties
    ''' of the <see cref="BeforeSearchEventArgs"/> passed to your event handler.
    ''' To cancel the search, set the Cancel property
    ''' of the <see cref="BeforeSearchEventArgs"/> passed to your event handler to true.</remarks>
    Public Event BeforeSearch(ByVal sender As Object, ByVal args As BeforeSearchEventArgs)


    ''' <summary>
    ''' Occurs after the search is executed.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="args"></param>
    ''' <remarks>This event occurs after the control executes a search
    ''' initiated with any of the search buttons.
    ''' </remarks>
    Public Event AfterSearch(ByVal sender As Object, ByVal args As AfterSearchEventArgs)




#Region "Properties"

    '''<summary>
    ''' Enable the IME status handling for this control.
    '''</summary>
    Protected Overrides ReadOnly Property CanEnableIme() As Boolean
        Get
            Return True
        End Get
    End Property


    Private m_SearchProvider As ISearchReplaceProvider
    ''' <summary>
    ''' Gets or sets a search provider.
    ''' </summary>
    ''' <value>If set to null, the search replace operations will not be performed.</value>
    Public Property SearchProvider() As ISearchReplaceProvider
        Get
            Return m_SearchProvider
        End Get
        Set(ByVal value As ISearchReplaceProvider)
            m_SearchProvider = value
        End Set
    End Property


    Private m_SearchKind As FindReplaceKind = FindReplaceKind.none
    '''<summary>Gets result button from this dialog.</summary>
    '''<value>The value specifying which button was pressed.</value>
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


    '''<summary> 
    '''  Let this control process the mnemonics.
    '''</summary>
    <UIPermission(SecurityAction.LinkDemand, Window:=UIPermissionWindow.AllWindows)> _
    Protected Overrides Function ProcessDialogChar(ByVal charCode As Char) As Boolean
        ' If we're the top-level form or control, we need to do the mnemonic handling
        If charCode <> " "c And ProcessMnemonic(charCode) Then
            Return True
        End If
        Return MyBase.ProcessDialogChar(charCode)
    End Function


    ''' <summary>
    ''' Raises the <see cref="Canceling"/> event.
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Overridable Sub OnCanceling(ByVal e As CancelEventArgs)
        RaiseEvent Canceling(Me, e)
    End Sub


    ''' <summary>
    ''' Raises the <see cref="BeforeSearch"/> event.
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Overridable Sub OnBeforeSearch(ByVal e As BeforeSearchEventArgs)
        RaiseEvent BeforeSearch(Me, e)
    End Sub


    ''' <summary>
    ''' Raises the <see cref="AfterSearch"/> event.
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Overridable Sub OnAfterSearch(ByVal e As AfterSearchEventArgs)
        RaiseEvent AfterSearch(Me, e)
    End Sub


#Region "Search, replace, regex"
    '''<summary>Transforms the text to regular expression syntax.</summary>
    '''<param name="original">Original text.</param>
    '''<returns>Text with escaped regex characters.</returns>
    Private Function escapeRegEx(ByVal original As String) As String
        Dim specialChars() As Char = "\.*+^$><[]|{}:@#()~".ToCharArray
        Dim c As Char
        For Each c In specialChars
            original = original.Replace(c.ToString, "\" & c.ToString)
        Next
        original = original.Replace(vbCrLf, "\n")
        Return original
    End Function


    '''<summary>Transforms the text to regular expression syntax in Replace field.</summary>
    '''<param name="original">Original text.</param>
    '''<returns>Text with some escaped regex characters.</returns>
    Private Function escapeReplaceRegEx(ByVal original As String) As String
        Dim specialChars() As Char = "\".ToCharArray
        Dim c As Char
        For Each c In specialChars
            original = original.Replace(c.ToString, "\" & c.ToString)
        Next
        original = original.Replace(vbCrLf, "\n")
        Return original
    End Function


    ''' <summary>
    ''' Executes a search/replace and raises appropriate events.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ExecuteSearchReplace()
        Dim args1 As New BeforeSearchEventArgs(Me.SearchKind, Me.FindText, Me.ReplaceText)
        OnBeforeSearch(args1)

        If Me.SearchProvider Is Nothing Then
            args1.Cancel = True
        End If
        If Not args1.Cancel Then
            Me.SearchProvider.ExecSearchReplace(Me.SearchKind, Me.FindText, Me.ReplaceText)

            Dim args2 As New AfterSearchEventArgs(Me.SearchKind, Me.FindText, Me.ReplaceText)
            OnAfterSearch(args2)
        End If
    End Sub
#End Region



    Private Sub CancelBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelBtn.Click
        Try
            Dim args As New CancelEventArgs()
            Me.OnCanceling(args)
            If Not args.Cancel Then
                m_SearchKind = FindReplaceKind.none
                Me.FindForm.Close()
            End If
        Catch ex As System.Exception
        End Try
    End Sub


    Private Sub FindBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FindBtn.Click
        Try
            m_findText = escapeRegEx(Me.FindBox.Text)
            m_replaceText = escapeReplaceRegEx(Me.ReplaceBox.Text)
            m_SearchKind = FindReplaceKind.find
            ExecuteSearchReplace()
        Catch ex As System.Exception
        End Try
    End Sub


    Private Sub FindInFilesBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FindInFilesBtn.Click
        Try
            m_findText = escapeRegEx(Me.FindBox.Text)
            m_replaceText = escapeReplaceRegEx(Me.ReplaceBox.Text)
            m_SearchKind = FindReplaceKind.findInFiles
            ExecuteSearchReplace()
        Catch ex As System.Exception
        End Try
    End Sub


    Private Sub ReplaceBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReplaceBtn.Click
        Try
            m_findText = escapeRegEx(Me.FindBox.Text)
            m_replaceText = escapeReplaceRegEx(Me.ReplaceBox.Text)
            m_SearchKind = FindReplaceKind.replace
            ExecuteSearchReplace()
        Catch ex As System.Exception
        End Try
    End Sub


    Private Sub ReplaceInFilesBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReplaceInFilesBtn.Click
        Try
            m_findText = escapeRegEx(Me.FindBox.Text)
            m_replaceText = escapeReplaceRegEx(Me.ReplaceBox.Text)
            m_SearchKind = FindReplaceKind.replaceInFiles
            ExecuteSearchReplace()
        Catch ex As System.Exception
        End Try
    End Sub
End Class