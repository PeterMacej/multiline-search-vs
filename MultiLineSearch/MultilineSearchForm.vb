
''' <summary>
''' The main search window.
''' </summary>
''' <remarks></remarks>
Public Class MultilineSearchForm

    Private dte As EnvDTE80.DTE2

    Public Sub New(ByVal dte As [EnvDTE80].DTE2)
        Me.InitializeComponent()

        If dte Is Nothing Then
            Throw New NullReferenceException()
        End If

        Me.dte = dte
        Me.MultilineSearchControl1.SearchProvider = New MultilineSearchReplace(dte)
    End Sub


    Private Sub MultilineSearchControl1_AfterSearch(ByVal sender As Object, ByVal args As AfterSearchEventArgs) Handles MultilineSearchControl1.AfterSearch
        Try
            Me.Close()
        Catch ex As Exception
        End Try
    End Sub

End Class