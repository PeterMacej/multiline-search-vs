Imports System.Security.Permissions
Imports System.Windows.Forms
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


    Private mSearchProvider As ISearchReplaceProvider
    ''' <summary>
    ''' Gets or sets a search provider.
    ''' </summary>
    ''' <value>If set to null, the search replace operations will not be performed.</value>
    Public Property SearchProvider() As ISearchReplaceProvider
        Get
            Return mSearchProvider
        End Get
        Set(ByVal value As ISearchReplaceProvider)
            mSearchProvider = value
        End Set
    End Property


    Private mSearchKind As FindReplaceKind = FindReplaceKind.None
    '''<summary>Gets result button from this dialog.</summary>
    '''<value>The value specifying which button was pressed.</value>
    Public ReadOnly Property SearchKind() As FindReplaceKind
        Get
            Return mSearchKind
        End Get
    End Property


    Private mFindText As String
    '''<summary>Gets or sets a plain multiline text to be searched.</summary>
    '''<value></value>
    Public Property FindText() As String
        Get
            Return mFindText
        End Get
        Set(ByVal value As String)
            If value IsNot Nothing Then
                mFindText = value
                Me.FindBox.Text = value
            End If
        End Set
    End Property


    Private mReplaceText As String
    '''<summary>Gets plain multiline replace text.</summary>
    '''<value></value>
    Public ReadOnly Property ReplaceText() As String
        Get
            Return mReplaceText
        End Get
    End Property


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

            Me.PanelBottom.Visible = Not value
            If value Then
                Me.TableLayoutPanel1.RowStyles.Item(2).Height = 0
            Else
                Me.TableLayoutPanel1.RowStyles.Item(2).Height = 34
            End If
        End Set
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
                mSearchKind = FindReplaceKind.None
                Me.FindForm.Close()
            End If
        Catch ex As System.Exception
        End Try
    End Sub


    Private Sub FindBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FindBtn.Click
        Try
            mFindText = Me.FindBox.Text
            mReplaceText = Me.ReplaceBox.Text
            mSearchKind = FindReplaceKind.Find
            ExecuteSearchReplace()
        Catch ex As System.Exception
        End Try
    End Sub


    Private Sub FindInFilesBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FindInFilesBtn.Click
        Try
            mFindText = Me.FindBox.Text
            mReplaceText = Me.ReplaceBox.Text
            mSearchKind = FindReplaceKind.FindInFiles
            ExecuteSearchReplace()
        Catch ex As System.Exception
        End Try
    End Sub


    Private Sub ReplaceBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReplaceBtn.Click
        Try
            mFindText = Me.FindBox.Text
            mReplaceText = Me.ReplaceBox.Text
            mSearchKind = FindReplaceKind.Replace
            ExecuteSearchReplace()
        Catch ex As System.Exception
        End Try
    End Sub


    Private Sub ReplaceInFilesBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReplaceInFilesBtn.Click
        Try
            mFindText = Me.FindBox.Text
            mReplaceText = Me.ReplaceBox.Text
            mSearchKind = FindReplaceKind.ReplaceInFiles
            ExecuteSearchReplace()
        Catch ex As System.Exception
        End Try
    End Sub


    ''' <summary>
    ''' Fix bottom anchoring of ReplaceBox. This didn't work at least in toolwindow in VS 2005.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub PanelTop_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles PanelTop.Resize
        Try
            Const BOTTOM_OFFSET As Integer = 3
            If Me.ReplaceBox.Bottom <> Me.PanelTop.Height - BOTTOM_OFFSET Then
                ' anchoring failed
                Me.ReplaceBox.Height = Me.PanelTop.Height - Me.ReplaceBox.Top - BOTTOM_OFFSET
            End If
        Catch ex As Exception
        End Try
    End Sub


    Private Sub MultilineSearchControl_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Try
            Dim topRowMinSize As Integer = 100

            Dim h As Integer = TableLayoutPanel1.Height
            For i As Integer = 1 To TableLayoutPanel1.RowCount - 1
                h -= CInt(TableLayoutPanel1.RowStyles(i).Height)
            Next

            If h < topRowMinSize Then
                h = topRowMinSize
            End If
            TableLayoutPanel1.RowStyles(0).Height = h
        Catch ex As Exception
        End Try
    End Sub

End Class