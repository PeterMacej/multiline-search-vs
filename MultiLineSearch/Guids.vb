Imports System

Class GuidList
    Private Sub New()
    End Sub

    Public Const guidMultiLineSearchPkgString As String = "29956436-0205-4c9e-9396-abce099383f9"
    Public Const guidMultiLineSearchCmdSetString As String = "7d58fc84-2160-4645-be98-eb7f27c358f7"
    Public Const guidToolWindowPersistanceString As String = "5c82a791-7c9f-441e-952b-8848655dd85e"

    Public Shared ReadOnly guidMultiLineSearchCmdSet As New Guid(guidMultiLineSearchCmdSetString)
End Class