Imports EnvDTE80


Namespace Gui

    ''' <summary>
    ''' Helper class for passing owner window argument to ShowDialog method.
    ''' </summary>
    ''' <remarks>See http://support.microsoft.com/kb/312877 for details.</remarks>
    Friend Class WinWrapper
    Implements System.Windows.Forms.IWin32Window


        ''' <summary>
        ''' Creates IDE's main window.
        ''' </summary>
        ''' <param name="dte"></param>
        ''' <remarks></remarks>
        Sub New(ByVal dte As DTE2)
            If dte Is Nothing Then
                Throw New NullReferenceException("dte")
            End If
            mHandle = New System.IntPtr(dte.MainWindow.HWnd)
        End Sub


        ''' <summary>
        ''' Creates specified window.
        ''' </summary>
        ''' <param name="hwnd"></param>
        ''' <remarks></remarks>
        Sub New(ByVal hwnd As System.IntPtr)
            If hwnd = IntPtr.Zero Then
                Throw New ArgumentException("hwnd")
            End If

            mHandle = hwnd
        End Sub


        Private ReadOnly mHandle As System.IntPtr
        Overridable ReadOnly Property Handle() As System.IntPtr Implements System.Windows.Forms.IWin32Window.Handle
            Get
                Return mHandle
            End Get
        End Property

    End Class

End Namespace
