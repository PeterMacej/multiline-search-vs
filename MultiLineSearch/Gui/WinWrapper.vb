Imports EnvDTE80


Namespace Gui

    ''' <summary>
    ''' Helper class for passing parent window argument to ShowDialog method.
    ''' </summary>
    ''' <remarks>See http://support.microsoft.com/kb/312877 for details.</remarks>
    Friend Class WinWrapper
    Implements System.Windows.Forms.IWin32Window

        Private ReadOnly vsinstance As DTE2

        Sub New(ByVal dte As DTE2)
            vsinstance = dte
        End Sub

        Overridable ReadOnly Property Handle() As System.IntPtr Implements System.Windows.Forms.IWin32Window.Handle
            Get
                Dim iptr As New System.IntPtr(vsinstance.MainWindow.HWnd)
                Return iptr
            End Get
        End Property

    End Class

End Namespace
