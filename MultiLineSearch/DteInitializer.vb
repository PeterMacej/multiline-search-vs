Imports Microsoft.VisualStudio
Imports Microsoft.VisualStudio.Shell.Interop


Friend Delegate Sub Action()


''' <summary>
''' Initalizes the DTE object.
''' </summary>
''' <remarks></remarks>
Friend Class DteInitializer
    Implements IVsShellPropertyEvents
    Private ReadOnly shellService As IVsShell
    Private cookie As UInteger
    Private ReadOnly callback As Action


    Friend Sub New(ByVal shellService As IVsShell, ByVal callback As Action)
        Dim hr As Integer

        Me.shellService = shellService
        Me.callback = callback

        ' Set an event handler to detect when the IDE is fully initialized
        hr = Me.shellService.AdviseShellPropertyChanges(Me, Me.cookie)

        Microsoft.VisualStudio.ErrorHandler.ThrowOnFailure(hr)
    End Sub


    Private Function IVsShellPropertyEvents_OnShellPropertyChange(ByVal propid As Integer, ByVal var As Object) As Integer Implements IVsShellPropertyEvents.OnShellPropertyChange
        Dim hr As Integer
        Dim isZombie As Boolean

        If propid = CInt(__VSSPROPID.VSSPROPID_Zombie) Then
            isZombie = CBool(var)

            If Not isZombie Then
                ' Release the event handler to detect when the IDE is fully initialized
                hr = Me.shellService.UnadviseShellPropertyChanges(Me.cookie)
                Microsoft.VisualStudio.ErrorHandler.ThrowOnFailure(hr)
                Me.cookie = 0
                Me.callback()
            End If
        End If
        Return VSConstants.S_OK
    End Function
End Class

