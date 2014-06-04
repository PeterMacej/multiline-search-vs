Imports System
Imports System.Windows.Forms
Imports System.Runtime.InteropServices
Imports Microsoft.VisualStudio.Shell.Interop
Imports Microsoft.VisualStudio.Shell


''' <summary>
''' This class implements the tool window exposed by this package and hosts a user control.
'''
''' In Visual Studio tool windows are composed of a frame (implemented by the shell) and a pane, 
''' usually implemented by the package implementer.
'''
''' This class derives from the ToolWindowPane class provided from the MPF in order to use its 
''' implementation of the IVsWindowPane interface.
''' </summary>
<Guid("5c82a791-7c9f-441e-952b-8848655dd85e")> _
Public Class MyToolWindow
    Inherits ToolWindowPane

    ' This is the user control hosted by the tool window; it is exposed to the base class 
    ' using the Window property. Note that, even if this class implements IDispose, we are
    ' not calling Dispose on this object. This is because ToolWindowPane calls Dispose on 
    ' the object returned by the Window property.
    Private WithEvents control As MultilineSearchControl

#Region "Properties"
    ''' <summary>
    ''' Gets the DTE object.
    ''' </summary>
    ''' <value>Nothing if the IDE is not yet fully initialized.</value>
    ''' <remarks></remarks>
    Private ReadOnly Property Dte() As EnvDTE80.DTE2
        Get
            Dim pkg As MultiLineSearchPackage = TryCast(Me.Package, MultiLineSearchPackage)
            If pkg Is Nothing Then
                Return Nothing
            Else
                Return pkg.Dte
            End If
        End Get
    End Property


    Private mSearchProvider As ISearchReplaceProvider = Nothing
    ''' <summary>
    ''' Gets the ISearchReplaceProvider to be used.
    ''' </summary>
    ''' <value>Nothing if the IDE is not yet fully initialized.</value>
    ''' <remarks></remarks>
    Private ReadOnly Property SearchProvider() As ISearchReplaceProvider
        Get
            If mSearchProvider Is Nothing Then
                If Me.Dte IsNot Nothing Then
                    mSearchProvider = New MultilineSearchReplace(Me.Dte)
                End If
            End If
            Return mSearchProvider
        End Get
    End Property


    ''' <summary>
    ''' This property returns the handle to the user control that should
    ''' be hosted in the Tool Window.
    ''' </summary>
    Public Overrides ReadOnly Property Window() As IWin32Window
        Get
            Return CType(control, IWin32Window)
        End Get
    End Property

#End Region


    ''' <summary>
    ''' Standard constructor for the tool window.
    ''' </summary>
    Public Sub New()
        MyBase.New(Nothing)
        ' Set the window title reading it from the resources.
        Me.Caption = My.Resources.ToolWindowTitle
        ' Set the image that will appear on the tab of the window frame
        ' when docked with an other window
        ' The resource ID correspond to the one defined in the resx file
        ' while the Index is the offset in the bitmap strip. Each image in
        ' the strip being 16x16.
        Me.BitmapResourceID = 301
        Me.BitmapIndex = 0

        control = New MultilineSearchControl()
        control.HideCancelButton = True
    End Sub


    ''' <summary>
    ''' Performs necessary initialization when the tool window is shown.
    ''' </summary>
    ''' <remarks>This method should be called before Show call.</remarks>
    Public Sub InitializeContent()
        Try
            ' prepopulate Find What field, if needed
            Dim findInit As Boolean = False
            Try
                Dim props As EnvDTE.Properties
                props = Dte.Properties("Environment", "FindAndReplace")
                Dim prop As EnvDTE.Property = props.Item("InitializeFromEditor")
                findInit = CBool(prop.Value)
            Catch ex2 As Exception
            End Try

            If findInit Then
                Dim initText As String = DocumentTextSelection.GetActiveDocumentText(Dte)
                If initText IsNot Nothing Then
                    Me.control.FindText = initText
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub


    Private Sub control_BeforeSearch(ByVal sender As Object, ByVal args As BeforeSearchEventArgs) Handles control.BeforeSearch
        Try
            ' set the search provider on the last possible moment (to be sure it's not null)
            Me.control.SearchProvider = Me.SearchProvider
        Catch ex As Exception
        End Try
    End Sub


    Private Sub control_Canceling(ByVal sender As Object, ByVal args As System.ComponentModel.CancelEventArgs) Handles control.Canceling
        Try
            Dim winFrame As IVsWindowFrame = TryCast(Me.Frame, IVsWindowFrame)
            If winFrame IsNot Nothing Then
                winFrame.CloseFrame(CUInt(__FRAMECLOSE.FRAMECLOSE_NoSave))
            End If
        Catch ex As Exception
        End Try
    End Sub


    '' not used
    'Public Overrides Sub OnToolWindowCreated()
    '    MyBase.OnToolWindowCreated()

    '    ' register window frame events
    '    Dim windowFrameEventsHandler As New ToolWindowFrameEvents()
    '    ErrorHandler.ThrowOnFailure( _
    '        (DirectCast(Me.Frame, IVsWindowFrame)).SetProperty( _
    '        CInt(__VSFPROPID.VSFPROPID_ViewHelper), _
    '        windowFrameEventsHandler))
    'End Sub

End Class


Friend Class ToolWindowFrameEvents
    Implements IVsWindowFrameNotify3


    Public Function OnClose(ByRef pgrfSaveOptions As UInteger) As Integer Implements Microsoft.VisualStudio.Shell.Interop.IVsWindowFrameNotify3.OnClose
        Return Microsoft.VisualStudio.VSConstants.S_OK
    End Function

    Public Function OnDockableChange(ByVal fDockable As Integer, ByVal x As Integer, ByVal y As Integer, ByVal w As Integer, ByVal h As Integer) As Integer Implements Microsoft.VisualStudio.Shell.Interop.IVsWindowFrameNotify3.OnDockableChange
        Return Microsoft.VisualStudio.VSConstants.S_OK
    End Function

    Public Function OnMove(ByVal x As Integer, ByVal y As Integer, ByVal w As Integer, ByVal h As Integer) As Integer Implements Microsoft.VisualStudio.Shell.Interop.IVsWindowFrameNotify3.OnMove
        Return Microsoft.VisualStudio.VSConstants.S_OK
    End Function

    Public Function OnShow(ByVal fShow As Integer) As Integer Implements Microsoft.VisualStudio.Shell.Interop.IVsWindowFrameNotify3.OnShow
        Select Case CType(fShow, __FRAMESHOW)
            Case __FRAMESHOW.FRAMESHOW_WinShown
                Diagnostics.Debug.WriteLine("aaa")
            Case __FRAMESHOW.FRAMESHOW_WinRestored
                Diagnostics.Debug.WriteLine("bbb")

        End Select
        Return Microsoft.VisualStudio.VSConstants.S_OK
    End Function

    Public Function OnSize(ByVal x As Integer, ByVal y As Integer, ByVal w As Integer, ByVal h As Integer) As Integer Implements Microsoft.VisualStudio.Shell.Interop.IVsWindowFrameNotify3.OnSize
        Return Microsoft.VisualStudio.VSConstants.S_OK
    End Function
End Class