<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MultilineSearchControl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.CancelBtn = New System.Windows.Forms.Button
        Me.ReplaceInFilesBtn = New System.Windows.Forms.Button
        Me.ReplaceBtn = New System.Windows.Forms.Button
        Me.FindInFilesBtn = New System.Windows.Forms.Button
        Me.FindBtn = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.ReplaceBox = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.FindBox = New System.Windows.Forms.TextBox
        Me.PanelTop = New System.Windows.Forms.Panel
        Me.PanelBottom = New System.Windows.Forms.Panel
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.PanelTop.SuspendLayout()
        Me.PanelBottom.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CancelBtn
        '
        Me.CancelBtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CancelBtn.Location = New System.Drawing.Point(169, 1)
        Me.CancelBtn.Name = "CancelBtn"
        Me.CancelBtn.Size = New System.Drawing.Size(80, 24)
        Me.CancelBtn.TabIndex = 18
        Me.CancelBtn.Text = "Cancel"
        '
        'ReplaceInFilesBtn
        '
        Me.ReplaceInFilesBtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ReplaceInFilesBtn.Image = Global.Helixoft.MultiLineSearch.My.Resources.MainResources.vs2013_replace_in_files
        Me.ReplaceInFilesBtn.Location = New System.Drawing.Point(282, 243)
        Me.ReplaceInFilesBtn.Name = "ReplaceInFilesBtn"
        Me.ReplaceInFilesBtn.Size = New System.Drawing.Size(123, 27)
        Me.ReplaceInFilesBtn.TabIndex = 17
        Me.ReplaceInFilesBtn.Text = "Replace in Files"
        Me.ReplaceInFilesBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        '
        'ReplaceBtn
        '
        Me.ReplaceBtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ReplaceBtn.Image = Global.Helixoft.MultiLineSearch.My.Resources.MainResources.vs2013_replace
        Me.ReplaceBtn.Location = New System.Drawing.Point(192, 243)
        Me.ReplaceBtn.Name = "ReplaceBtn"
        Me.ReplaceBtn.Size = New System.Drawing.Size(84, 27)
        Me.ReplaceBtn.TabIndex = 16
        Me.ReplaceBtn.Text = "Replace"
        Me.ReplaceBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        '
        'FindInFilesBtn
        '
        Me.FindInFilesBtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FindInFilesBtn.Image = Global.Helixoft.MultiLineSearch.My.Resources.MainResources.vs2013_find_in_files
        Me.FindInFilesBtn.Location = New System.Drawing.Point(282, 213)
        Me.FindInFilesBtn.Name = "FindInFilesBtn"
        Me.FindInFilesBtn.Size = New System.Drawing.Size(123, 27)
        Me.FindInFilesBtn.TabIndex = 15
        Me.FindInFilesBtn.Text = "Find in Files"
        Me.FindInFilesBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        '
        'FindBtn
        '
        Me.FindBtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FindBtn.Image = Global.Helixoft.MultiLineSearch.My.Resources.MainResources.vs2013_find
        Me.FindBtn.Location = New System.Drawing.Point(192, 213)
        Me.FindBtn.Name = "FindBtn"
        Me.FindBtn.Size = New System.Drawing.Size(84, 27)
        Me.FindBtn.TabIndex = 14
        Me.FindBtn.Text = "Find"
        Me.FindBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(12, 114)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(153, 16)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Replace with:"
        '
        'ReplaceBox
        '
        Me.ReplaceBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ReplaceBox.Location = New System.Drawing.Point(12, 130)
        Me.ReplaceBox.Multiline = True
        Me.ReplaceBox.Name = "ReplaceBox"
        Me.ReplaceBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.ReplaceBox.Size = New System.Drawing.Size(393, 77)
        Me.ReplaceBox.TabIndex = 12
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(12, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(153, 16)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Find what:"
        '
        'FindBox
        '
        Me.FindBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FindBox.Location = New System.Drawing.Point(12, 26)
        Me.FindBox.Multiline = True
        Me.FindBox.Name = "FindBox"
        Me.FindBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.FindBox.Size = New System.Drawing.Size(393, 80)
        Me.FindBox.TabIndex = 10
        '
        'PanelTop
        '
        Me.PanelTop.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelTop.Controls.Add(Me.ReplaceInFilesBtn)
        Me.PanelTop.Controls.Add(Me.ReplaceBtn)
        Me.PanelTop.Controls.Add(Me.FindInFilesBtn)
        Me.PanelTop.Controls.Add(Me.FindBtn)
        Me.PanelTop.Controls.Add(Me.Label1)
        Me.PanelTop.Controls.Add(Me.FindBox)
        Me.PanelTop.Controls.Add(Me.ReplaceBox)
        Me.PanelTop.Controls.Add(Me.Label2)
        Me.PanelTop.Location = New System.Drawing.Point(3, 3)
        Me.PanelTop.Name = "PanelTop"
        Me.PanelTop.Size = New System.Drawing.Size(418, 273)
        Me.PanelTop.TabIndex = 0
        '
        'PanelBottom
        '
        Me.PanelBottom.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelBottom.Controls.Add(Me.CancelBtn)
        Me.PanelBottom.Location = New System.Drawing.Point(3, 282)
        Me.PanelBottom.Name = "PanelBottom"
        Me.PanelBottom.Size = New System.Drawing.Size(418, 28)
        Me.PanelBottom.TabIndex = 1
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.PanelBottom, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.PanelTop, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(424, 313)
        Me.TableLayoutPanel1.TabIndex = 20
        '
        'MultilineSearchControl
        '
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "MultilineSearchControl"
        Me.Size = New System.Drawing.Size(424, 313)
        Me.PanelTop.ResumeLayout(False)
        Me.PanelTop.PerformLayout()
        Me.PanelBottom.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CancelBtn As System.Windows.Forms.Button
    Friend WithEvents ReplaceInFilesBtn As System.Windows.Forms.Button
    Friend WithEvents ReplaceBtn As System.Windows.Forms.Button
    Friend WithEvents FindInFilesBtn As System.Windows.Forms.Button
    Friend WithEvents FindBtn As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ReplaceBox As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents FindBox As System.Windows.Forms.TextBox
    Friend WithEvents PanelTop As System.Windows.Forms.Panel
    Friend WithEvents PanelBottom As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel

End Class