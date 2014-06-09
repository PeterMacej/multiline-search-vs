Option Strict On
Option Explicit On 


Namespace Update

    Friend Class CheckUpdatesDlg
        Inherits System.Windows.Forms.Form


#Region "Properties"

        Private mUpdateInf As UpdateInfo
        Friend Property UpdateInf() As UpdateInfo
            Get
                Return mUpdateInf
            End Get
            Set(ByVal value As UpdateInfo)
                mUpdateInf = value
            End Set
        End Property

#End Region


        Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
            Try
                Me.Close()
            Catch ex As Exception
            End Try
        End Sub


        Private Sub CheckUpdatesDlg_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                ' fix header transparency
                Me.LabelHeader.Parent = Me.PictureBox1
                Me.LabelHeader.BackColor = Drawing.Color.Transparent

                'current version
                Try
                    LabelCurrentVersion.Text = Me.UpdateInf.CurrentVersion.Major.ToString
                    LabelCurrentVersion.Text &= "."
                    LabelCurrentVersion.Text &= Me.UpdateInf.CurrentVersion.Minor.ToString
                    If Me.UpdateInf.LatestVersion.Build <> -1 Then
                        'only show build for current if there is build number in latest version
                        LabelCurrentVersion.Text &= "."
                        LabelCurrentVersion.Text &= Me.UpdateInf.CurrentVersion.Build.ToString
                    End If
                Catch ex As Exception
                End Try

                'latest version
                Me.LabelLatestVersion.Text = Me.UpdateInf.LatestVersion.ToString
                Me.LabelLatestDate.Text = "updated on " & Me.UpdateInf.ReleaseDate.ToShortDateString

                'download button and what's new
                If Me.UpdateInf.IsLatestNewer Then
                    Me.ButtonDownload.Visible = True
                    Me.LabelYouHaveLatest.Visible = False
                    Me.PanelUpdateInfo.Visible = True

                    Me.LabelWhatsNew.Text = "What's new in version " & Me.UpdateInf.LatestVersion.ToString & ":"
                    Me.TextBoxWhatsNew.Text = Me.UpdateInf.WhatsNew
                Else
                    Me.ButtonDownload.Visible = False
                    Me.LabelYouHaveLatest.Visible = True
                    Me.PanelUpdateInfo.Visible = False
                End If

                'init links
                LinkLabel2.Links.Clear()
                LinkLabel2.Links.Add(0, LinkLabel2.Text.Length, Me.UpdateInf.HomeUrl)
            Catch ex As Exception
            End Try
        End Sub


        Private Sub LinkLabel2_LinkClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
            Try
                ' Determine which link was clicked within the LinkLabel.
                LinkLabel2.Links(LinkLabel2.Links.IndexOf(e.Link)).Visited = True
                ' Display the appropriate link based on the value of the LinkData property of the Link object.
                System.Diagnostics.Process.Start(e.Link.LinkData.ToString())
            Catch ex As Exception
            End Try
        End Sub


        Private Sub ButtonDownload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDownload.Click
            System.Diagnostics.Process.Start(Me.UpdateInf.DownloadUrl)
        End Sub

    End Class

End Namespace
