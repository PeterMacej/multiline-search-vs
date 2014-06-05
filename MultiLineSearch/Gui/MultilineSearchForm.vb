
Namespace Gui

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


        Private Sub MultilineSearchForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Try
                ' prepopulate Find What field, if needed
                Dim findInit As Boolean = False
                Try
                    Dim props As EnvDTE.Properties
                    props = dte.Properties("Environment", "FindAndReplace")
                    Dim prop As EnvDTE.Property = props.Item("InitializeFromEditor")
                    findInit = CBool(prop.Value)
                Catch ex2 As Exception
                End Try

                If findInit Then
                    Dim initText As String = DocumentTextSelection.GetActiveDocumentText(dte)
                    If initText IsNot Nothing Then
                        Me.MultilineSearchControl1.FindText = initText
                    End If
                End If

            Catch ex As Exception
            End Try
        End Sub


    End Class

End Namespace