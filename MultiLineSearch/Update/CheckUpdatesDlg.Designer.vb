Option Strict
Option Explicit 
Imports System.Windows.Forms
Imports Helixoft.MultiLineSearch.Gui

Namespace Update

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Friend Partial Class CheckUpdatesDlg
        Inherits System.Windows.Forms.Form

        #Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            FormFontAndScaleFixer.FixFont(Me)
            FormFontAndScaleFixer.FixDpiScale(Me)
        End Sub

        'Form overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not (components Is Nothing) Then
                    components.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        Friend WithEvents Button1 As System.Windows.Forms.Button

        Friend WithEvents Label1 As System.Windows.Forms.Label

        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox

        Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox

        Friend WithEvents Label9 As System.Windows.Forms.Label

        Friend WithEvents Panel1 As System.Windows.Forms.Panel


        Friend WithEvents LinkLabel2 As System.Windows.Forms.LinkLabel

        Friend WithEvents LabelCurrentVersion As System.Windows.Forms.TextBox

        Friend WithEvents LabelLatestVersion As System.Windows.Forms.TextBox

        Friend WithEvents Label2 As System.Windows.Forms.Label

        Friend WithEvents LabelYouHaveLatest As System.Windows.Forms.Label

        Friend WithEvents ButtonDownload As System.Windows.Forms.Button

        Friend WithEvents PanelUpdateInfo As System.Windows.Forms.Panel

        Friend WithEvents LabelWhatsNew As System.Windows.Forms.Label

        Friend WithEvents TextBoxWhatsNew As System.Windows.Forms.TextBox



        Friend WithEvents LabelLatestDate As System.Windows.Forms.Label


        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CheckUpdatesDlg))
            Me.Button1 = New System.Windows.Forms.Button
            Me.Label1 = New System.Windows.Forms.Label
            Me.GroupBox1 = New System.Windows.Forms.GroupBox
            Me.PictureBox1 = New System.Windows.Forms.PictureBox
            Me.Label9 = New System.Windows.Forms.Label
            Me.Panel1 = New System.Windows.Forms.Panel
            Me.TextBoxWhatsNew = New System.Windows.Forms.TextBox
            Me.LabelWhatsNew = New System.Windows.Forms.Label
            Me.LinkLabel2 = New System.Windows.Forms.LinkLabel
            Me.LabelCurrentVersion = New System.Windows.Forms.TextBox
            Me.LabelLatestVersion = New System.Windows.Forms.TextBox
            Me.Label2 = New System.Windows.Forms.Label
            Me.LabelYouHaveLatest = New System.Windows.Forms.Label
            Me.ButtonDownload = New System.Windows.Forms.Button
            Me.PanelUpdateInfo = New System.Windows.Forms.Panel
            Me.LabelLatestDate = New System.Windows.Forms.Label
            Me.LabelHeader = New System.Windows.Forms.Label
            Me.ButtonPrefs = New System.Windows.Forms.Button
            CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel1.SuspendLayout()
            Me.PanelUpdateInfo.SuspendLayout()
            Me.SuspendLayout()
            '
            'Button1
            '
            Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.Button1.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.Button1.ForeColor = System.Drawing.SystemColors.ControlText
            Me.Button1.Location = New System.Drawing.Point(386, 414)
            Me.Button1.Name = "Button1"
            Me.Button1.Size = New System.Drawing.Size(76, 24)
            Me.Button1.TabIndex = 0
            Me.Button1.Text = "Close"
            Me.Button1.UseVisualStyleBackColor = False
            '
            'Label1
            '
            Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.Label1.Location = New System.Drawing.Point(464, 266)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(8, 12)
            Me.Label1.TabIndex = 6
            '
            'GroupBox1
            '
            Me.GroupBox1.Location = New System.Drawing.Point(24, 376)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(448, 4)
            Me.GroupBox1.TabIndex = 5
            Me.GroupBox1.TabStop = False
            '
            'PictureBox1
            '
            Me.PictureBox1.BackColor = System.Drawing.Color.LightSteelBlue
            Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
            Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
            Me.PictureBox1.Name = "PictureBox1"
            Me.PictureBox1.Size = New System.Drawing.Size(500, 60)
            Me.PictureBox1.TabIndex = 7
            Me.PictureBox1.TabStop = False
            '
            'Label9
            '
            Me.Label9.Location = New System.Drawing.Point(64, 80)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(128, 16)
            Me.Label9.TabIndex = 15
            Me.Label9.Text = "Your current version:"
            '
            'Panel1
            '
            Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
            Me.Panel1.Controls.Add(Me.TextBoxWhatsNew)
            Me.Panel1.ForeColor = System.Drawing.SystemColors.Control
            Me.Panel1.Location = New System.Drawing.Point(8, 24)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(432, 152)
            Me.Panel1.TabIndex = 18
            '
            'TextBoxWhatsNew
            '
            Me.TextBoxWhatsNew.BackColor = System.Drawing.SystemColors.ControlLightLight
            Me.TextBoxWhatsNew.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.TextBoxWhatsNew.Location = New System.Drawing.Point(1, 1)
            Me.TextBoxWhatsNew.Multiline = True
            Me.TextBoxWhatsNew.Name = "TextBoxWhatsNew"
            Me.TextBoxWhatsNew.ReadOnly = True
            Me.TextBoxWhatsNew.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.TextBoxWhatsNew.Size = New System.Drawing.Size(430, 150)
            Me.TextBoxWhatsNew.TabIndex = 20
            '
            'LabelWhatsNew
            '
            Me.LabelWhatsNew.Location = New System.Drawing.Point(8, 8)
            Me.LabelWhatsNew.Name = "LabelWhatsNew"
            Me.LabelWhatsNew.Size = New System.Drawing.Size(300, 16)
            Me.LabelWhatsNew.TabIndex = 19
            Me.LabelWhatsNew.Text = "What's new in version  :"
            '
            'LinkLabel2
            '
            Me.LinkLabel2.Location = New System.Drawing.Point(32, 392)
            Me.LinkLabel2.Name = "LinkLabel2"
            Me.LinkLabel2.Size = New System.Drawing.Size(284, 16)
            Me.LinkLabel2.TabIndex = 24
            Me.LinkLabel2.TabStop = True
            Me.LinkLabel2.Text = "Multiline Search and Replace home"
            '
            'LabelCurrentVersion
            '
            Me.LabelCurrentVersion.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.LabelCurrentVersion.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.LabelCurrentVersion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.LabelCurrentVersion.Location = New System.Drawing.Point(200, 80)
            Me.LabelCurrentVersion.Name = "LabelCurrentVersion"
            Me.LabelCurrentVersion.ReadOnly = True
            Me.LabelCurrentVersion.Size = New System.Drawing.Size(232, 13)
            Me.LabelCurrentVersion.TabIndex = 16
            Me.LabelCurrentVersion.Text = "1.0"
            '
            'LabelLatestVersion
            '
            Me.LabelLatestVersion.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.LabelLatestVersion.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.LabelLatestVersion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.LabelLatestVersion.Location = New System.Drawing.Point(200, 96)
            Me.LabelLatestVersion.Name = "LabelLatestVersion"
            Me.LabelLatestVersion.ReadOnly = True
            Me.LabelLatestVersion.Size = New System.Drawing.Size(232, 13)
            Me.LabelLatestVersion.TabIndex = 26
            Me.LabelLatestVersion.Text = "1.0"
            '
            'Label2
            '
            Me.Label2.Location = New System.Drawing.Point(64, 96)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(128, 16)
            Me.Label2.TabIndex = 25
            Me.Label2.Text = "Latest available version:"
            '
            'LabelYouHaveLatest
            '
            Me.LabelYouHaveLatest.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.LabelYouHaveLatest.Location = New System.Drawing.Point(64, 120)
            Me.LabelYouHaveLatest.Name = "LabelYouHaveLatest"
            Me.LabelYouHaveLatest.Size = New System.Drawing.Size(368, 48)
            Me.LabelYouHaveLatest.TabIndex = 27
            Me.LabelYouHaveLatest.Text = "You have the latest version. No need to update."
            Me.LabelYouHaveLatest.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'ButtonDownload
            '
            Me.ButtonDownload.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.ButtonDownload.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.ButtonDownload.ForeColor = System.Drawing.SystemColors.ControlText
            Me.ButtonDownload.Location = New System.Drawing.Point(127, 120)
            Me.ButtonDownload.Name = "ButtonDownload"
            Me.ButtonDownload.Size = New System.Drawing.Size(240, 40)
            Me.ButtonDownload.TabIndex = 28
            Me.ButtonDownload.Text = "Download latest version"
            Me.ButtonDownload.UseVisualStyleBackColor = False
            '
            'PanelUpdateInfo
            '
            Me.PanelUpdateInfo.Controls.Add(Me.LabelWhatsNew)
            Me.PanelUpdateInfo.Controls.Add(Me.Panel1)
            Me.PanelUpdateInfo.Location = New System.Drawing.Point(23, 176)
            Me.PanelUpdateInfo.Name = "PanelUpdateInfo"
            Me.PanelUpdateInfo.Size = New System.Drawing.Size(448, 192)
            Me.PanelUpdateInfo.TabIndex = 29
            '
            'LabelLatestDate
            '
            Me.LabelLatestDate.Location = New System.Drawing.Point(288, 96)
            Me.LabelLatestDate.Name = "LabelLatestDate"
            Me.LabelLatestDate.Size = New System.Drawing.Size(184, 21)
            Me.LabelLatestDate.TabIndex = 31
            Me.LabelLatestDate.Text = "updated on"
            '
            'LabelHeader
            '
            Me.LabelHeader.AutoSize = True
            Me.LabelHeader.BackColor = System.Drawing.Color.Transparent
            Me.LabelHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
            Me.LabelHeader.Location = New System.Drawing.Point(19, 16)
            Me.LabelHeader.Name = "LabelHeader"
            Me.LabelHeader.Size = New System.Drawing.Size(293, 25)
            Me.LabelHeader.TabIndex = 32
            Me.LabelHeader.Text = "Multiline Search and Replace"
            '
            'ButtonPrefs
            '
            Me.ButtonPrefs.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.ButtonPrefs.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.ButtonPrefs.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.ButtonPrefs.ForeColor = System.Drawing.SystemColors.ControlText
            Me.ButtonPrefs.Location = New System.Drawing.Point(34, 414)
            Me.ButtonPrefs.Name = "ButtonPrefs"
            Me.ButtonPrefs.Size = New System.Drawing.Size(179, 24)
            Me.ButtonPrefs.TabIndex = 33
            Me.ButtonPrefs.Text = "Update preferences ..."
            Me.ButtonPrefs.UseVisualStyleBackColor = False
            '
            'CheckUpdatesDlg
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.CancelButton = Me.Button1
            Me.ClientSize = New System.Drawing.Size(494, 450)
            Me.Controls.Add(Me.ButtonPrefs)
            Me.Controls.Add(Me.LabelHeader)
            Me.Controls.Add(Me.LabelLatestDate)
            Me.Controls.Add(Me.PanelUpdateInfo)
            Me.Controls.Add(Me.ButtonDownload)
            Me.Controls.Add(Me.LabelYouHaveLatest)
            Me.Controls.Add(Me.LabelLatestVersion)
            Me.Controls.Add(Me.Label2)
            Me.Controls.Add(Me.LabelCurrentVersion)
            Me.Controls.Add(Me.LinkLabel2)
            Me.Controls.Add(Me.Label9)
            Me.Controls.Add(Me.PictureBox1)
            Me.Controls.Add(Me.Label1)
            Me.Controls.Add(Me.GroupBox1)
            Me.Controls.Add(Me.Button1)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "CheckUpdatesDlg"
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Multiline Search and Replace Update"
            CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            Me.PanelUpdateInfo.ResumeLayout(False)
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents LabelHeader As System.Windows.Forms.Label
        Friend WithEvents ButtonPrefs As System.Windows.Forms.Button

        #End Region
    End Class

End Namespace

