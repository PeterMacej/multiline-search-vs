Imports System.Windows.Forms
Imports Microsoft.VisualStudio.Shell.Interop
Imports Microsoft.VisualStudio.Shell


Namespace Gui

    ''' <summary>
    ''' Provides functionality for doalogs in VS IDE.
    ''' </summary>
    ''' <remarks></remarks>
    Public Class Dialogs


        ''' <summary>
        ''' Shows a dialog as modal and determine the owner window automatically.
        ''' </summary>
        ''' <param name="dlg"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' As an owner window, this method uses the environment's main application window
        ''' unless another modal dialog box is already open. In this case, the top-most 
        ''' modal dialog is used.
        ''' </remarks>
        ''' <seealso href="http://msdn.microsoft.com/en-us/library/ee943166.aspx"/>
        Public Shared Function ShowAsModal(ByVal dlg As Form) As DialogResult
            Dim uiShell As IVsUIShell = TryCast(Package.GetGlobalService(GetType(SVsUIShell)), IVsUIShell)

            Dim hwnd As IntPtr = Nothing
            uiShell.GetDialogOwnerHwnd(hwnd)
            uiShell.EnableModeless(0)

            Dim res As [DialogResult] = DialogResult.None
            Try
                Dim owner As WinWrapper
                owner = New WinWrapper(hwnd)
                res = dlg.ShowDialog(owner)
            Finally
                'this will take place after the window is closed
                uiShell.EnableModeless(1)
            End Try

            Return res
        End Function


        ''' <summary>
        ''' Shows standard .NET message box.
        ''' </summary>
        ''' <param name="text"></param>
        ''' <param name="caption"></param>
        ''' <param name="buttons"></param>
        ''' <param name="icon"></param>
        ''' <param name="defaultButton"></param>
        ''' <param name="options"></param>
        ''' <param name="helpFilePath"></param>
        ''' <param name="keyword"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function ShowMessageBox(ByVal text As String, _
        ByVal caption As String, _
        ByVal buttons As System.Windows.Forms.MessageBoxButtons, _
        ByVal icon As System.Windows.Forms.MessageBoxIcon, _
        ByVal defaultButton As System.Windows.Forms.MessageBoxDefaultButton, _
        ByVal options As System.Windows.Forms.MessageBoxOptions, _
        ByVal helpFilePath As String, _
        ByVal keyword As String) As [DialogResult]

            Dim uiShell As IVsUIShell = TryCast(Package.GetGlobalService(GetType(SVsUIShell)), IVsUIShell)

            Dim hwnd As IntPtr = Nothing
            uiShell.GetDialogOwnerHwnd(hwnd)
            uiShell.EnableModeless(0)

            Dim res As [DialogResult] = DialogResult.None
            Try
                Dim owner As WinWrapper
                owner = New WinWrapper(hwnd)
                res = MessageBox.Show(owner, text, caption, buttons, icon, defaultButton, options, helpFilePath, keyword)
            Finally
                'this will take place after the window is closed
                uiShell.EnableModeless(1)
            End Try

            Return res
        End Function


        ''' <summary>
        ''' Shows standard .NET message box.
        ''' </summary>
        ''' <param name="text"></param>
        ''' <param name="caption"></param>
        ''' <param name="buttons"></param>
        ''' <param name="icon"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function ShowMessageBox(ByVal text As String, _
        ByVal caption As String, _
        ByVal buttons As System.Windows.Forms.MessageBoxButtons, _
        ByVal icon As System.Windows.Forms.MessageBoxIcon _
        ) As [DialogResult]

            Dim uiShell As IVsUIShell = TryCast(Package.GetGlobalService(GetType(SVsUIShell)), IVsUIShell)

            Dim hwnd As IntPtr = Nothing
            uiShell.GetDialogOwnerHwnd(hwnd)
            uiShell.EnableModeless(0)

            Dim res As [DialogResult] = DialogResult.None
            Try
                Dim owner As WinWrapper
                owner = New WinWrapper(hwnd)
                res = MessageBox.Show(owner, text, caption, buttons, icon)
            Finally
                'this will take place after the window is closed
                uiShell.EnableModeless(1)
            End Try

            Return res
        End Function


        ''' <summary>
        ''' Shows native VS message box.
        ''' </summary>
        ''' <param name="title"></param>
        ''' <param name="text"></param>
        ''' <param name="helpFile"></param>
        ''' <param name="msgbtn"></param>
        ''' <param name="msgdefbtn"></param>
        ''' <param name="msgicon"></param>
        ''' <returns></returns>
        ''' <remarks>It is similar to standard message box but for example, you
        ''' cannot change the title.</remarks>
        Public Shared Function ShowVsMessageBox(ByVal title As String, _
        ByVal text As String, _
        ByVal helpFile As String, _
        ByVal msgbtn As Microsoft.VisualStudio.Shell.Interop.OLEMSGBUTTON, _
        ByVal msgdefbtn As Microsoft.VisualStudio.Shell.Interop.OLEMSGDEFBUTTON, _
        ByVal msgicon As Microsoft.VisualStudio.Shell.Interop.OLEMSGICON) As Integer

            Dim uiShell As IVsUIShell = TryCast(Package.GetGlobalService(GetType(SVsUIShell)), IVsUIShell)
            Dim clsid As Guid = Guid.Empty
            Dim result As Integer
            Microsoft.VisualStudio.ErrorHandler.ThrowOnFailure( _
                uiShell.ShowMessageBox(0, _
                    clsid, _
                    title, _
                    text, _
                    String.Empty, _
                    0, _
                    OLEMSGBUTTON.OLEMSGBUTTON_OK, _
                    OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST, _
                    OLEMSGICON.OLEMSGICON_INFO, _
                    0, _
                    result))

            Return result
        End Function

    End Class


End Namespace
