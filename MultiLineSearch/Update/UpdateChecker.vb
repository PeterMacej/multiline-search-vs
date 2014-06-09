Option Explicit On
Option Strict On

Imports System.Xml
Imports System.Reflection
Imports System.Windows.Forms
Imports Microsoft.VisualBasic


Namespace Update

    ''' <summary>
    ''' Provides functionality of checking for updates.
    ''' </summary>
    ''' <remarks></remarks>
    Friend Class UpdateChecker

        ''' <summary>
        ''' Checks for update if specified interval is over and shows the window with
        ''' results if update is found.
        ''' </summary>
        ''' <remarks></remarks>
        'Friend Sub CheckForUpdatesAutomatically(ByVal dte As EnvDTE80.DTE2, ByVal preferences As Preferences)
        '    Try
        '        'test interval
        '        Dim interval As Integer = preferences.checkForUpdatesInterval
        '        If interval <= 0 Then
        '            Return
        '        End If
        '        Dim lastCheck As Date = AppSettings.LoadLastUpdateCheckDate(dte)
        '        If Date.Today.Subtract(lastCheck).Days < interval Then
        '            Return
        '        End If

        '        'can check update
        '        AppSettings.SaveLastUpdateCheckDate(dte, Date.Today)
        '        dte.StatusBar.Text = "Multiline Search and Replace - checking for updates"
        '        Dim updInfo As UpdateInfo = ReadInfoFromXml(LoadXml)
        '        If updInfo.IsLatestNewer Then
        '            dte.StatusBar.Text = "Multiline Search and Replace - updates found"
        '            Dim updDlg As New CheckUpdates()
        '            updDlg.UpdateInf = updInfo
        '            Dim winptr As New Gui.WinWrapper(dte)
        '            updDlg.ShowDialog(winptr)
        '            dte.StatusBar.Text = ""
        '        Else
        '            dte.StatusBar.Text = "Multiline Search and Replace - no updates available"
        '        End If
        '    Catch ex As Exception
        '        dte.StatusBar.Text = "Multiline Search and Replace - error when checking for updates"
        '    End Try
        'End Sub


        ''' <summary>
        ''' Checks for update immediately and shows the window with
        ''' results in both cases - if update is or isn't found.
        ''' </summary>
        ''' <remarks></remarks>
        Friend Sub CheckForUpdates()
            Try
                Dim updDlg As New CheckUpdatesDlg()
                updDlg.UpdateInf = ReadInfoFromXml(LoadXml)
                updDlg.ShowDialog()
            Catch ex As Exception
                ShowUpdateError(ex)
            End Try
        End Sub


        Private Sub ShowUpdateError(ByVal ex As Exception)
            Dim msg As String = "Couldn't check for Multiline Search and Replace updates. The following error occured:"
            msg &= vbCrLf & ex.Message
            MessageBox.Show(msg, "Check for update error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Sub


        Private Function LoadXml() As XmlDocument
            Dim xd As New XmlDocument()
            xd.Load("http://www.helixoft.com/files/free/multiline-search/update.xml")
            Return xd
        End Function


        ''' <summary>
        ''' Reads complete update info from XML.
        ''' </summary>
        ''' <param name="xmlDoc"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function ReadInfoFromXml(ByVal xmlDoc As XmlDocument) As UpdateInfo
            Dim res As New UpdateInfo()

            Dim v As Version = Reflection.Assembly.GetExecutingAssembly().GetName.Version
            'ignore revision
            res.CurrentVersion = New Version(v.Major, v.Minor, v.Build)

            ReadLatesReleaseFromXml(xmlDoc, res)

            res.UpdateInfoUrl = xmlDoc.SelectSingleNode("/application-update/update-info-xml-url").InnerText.Trim

            Return res
        End Function


        ''' <summary>
        ''' Reads only latest release info from XML into specified <see cref="UpdateInfo"/> object.
        ''' </summary>
        ''' <param name="xmlDoc"></param>
        ''' <param name="info"></param>
        ''' <remarks></remarks>
        Private Sub ReadLatesReleaseFromXml(ByVal xmlDoc As XmlDocument, ByVal info As UpdateInfo)
            Dim nod, nod2 As XmlNode

            'urls and text
            nod = xmlDoc.SelectSingleNode("/application-update/release[@latest=""yes""]")
            info.DownloadUrl = nod.SelectSingleNode("download-url").InnerText.Trim
            info.HomeUrl = nod.SelectSingleNode("home-url").InnerText.Trim
            info.BuyUrl = nod.SelectSingleNode("buy-url").InnerText.Trim
            info.ReleaseNotesUrl = nod.SelectSingleNode("release-notes-url").InnerText.Trim
            info.WhatsNew = nod.SelectSingleNode("whats-new").InnerText
            'fix whitespaces and UNIX/DOS CRLF
            info.WhatsNew = info.WhatsNew.Replace(vbTab, " ")
            info.WhatsNew = info.WhatsNew.Replace(vbCrLf, vbLf)
            info.WhatsNew = info.WhatsNew.Replace(vbCr, vbLf)
            info.WhatsNew = info.WhatsNew.Replace(vbLf, vbCrLf)
            If info.WhatsNew.StartsWith(vbCrLf) Then
                info.WhatsNew = info.WhatsNew.Substring(vbCrLf.Length)
            End If
            'version
            Dim major, minor As Integer
            Dim build As String
            nod2 = nod.SelectSingleNode("version")
            major = Integer.Parse(nod2.SelectSingleNode("major").InnerText)
            minor = Integer.Parse(nod2.SelectSingleNode("minor").InnerText)
            build = nod2.SelectSingleNode("build").InnerText.Trim
            If build.Length > 0 Then
                info.LatestVersion = New Version(major, minor, Integer.Parse(build))
            Else
                info.LatestVersion = New Version(major, minor)
            End If
            'date
            Dim day, month, year As Integer
            nod2 = nod.SelectSingleNode("date")
            day = Integer.Parse(nod2.SelectSingleNode("day").InnerText)
            month = Integer.Parse(nod2.SelectSingleNode("month").InnerText)
            year = Integer.Parse(nod2.SelectSingleNode("year").InnerText)
            info.ReleaseDate = New Date(year, month, day)
        End Sub

    End Class

End Namespace
