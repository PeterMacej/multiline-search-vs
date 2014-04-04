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
        Me.Label2 = New System.Windows.Forms.Label
        Me.ReplaceBox = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.FindBox = New System.Windows.Forms.TextBox
        Me.PanelTop = New System.Windows.Forms.Panel
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripButtonFind = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButtonFindInFiles = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButtonReplace = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButtonReplaceInFiles = New System.Windows.Forms.ToolStripButton
        Me.PanelBottom = New System.Windows.Forms.Panel
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.PanelTop.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
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
        Me.ReplaceBox.Size = New System.Drawing.Size(393, 100)
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
        Me.PanelTop.Controls.Add(Me.ToolStrip1)
        Me.PanelTop.Controls.Add(Me.Label1)
        Me.PanelTop.Controls.Add(Me.FindBox)
        Me.PanelTop.Controls.Add(Me.ReplaceBox)
        Me.PanelTop.Controls.Add(Me.Label2)
        Me.PanelTop.Location = New System.Drawing.Point(3, 3)
        Me.PanelTop.Name = "PanelTop"
        Me.PanelTop.Size = New System.Drawing.Size(418, 273)
        Me.PanelTop.TabIndex = 0
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButtonFind, Me.ToolStripButtonFindInFiles, Me.ToolStripButtonReplace, Me.ToolStripButtonReplaceInFiles})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 235)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip1.Size = New System.Drawing.Size(418, 38)
        Me.ToolStrip1.TabIndex = 18
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButtonFind
        '
        Me.ToolStripButtonFind.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ToolStripButtonFind.Image = Global.Helixoft.MultiLineSearch.My.Resources.MainResources.vs2013_find
        Me.ToolStripButtonFind.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonFind.Margin = New System.Windows.Forms.Padding(12, 1, 0, 2)
        Me.ToolStripButtonFind.Name = "ToolStripButtonFind"
        Me.ToolStripButtonFind.Size = New System.Drawing.Size(34, 35)
        Me.ToolStripButtonFind.Text = "Find"
        Me.ToolStripButtonFind.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        Me.ToolStripButtonFind.ToolTipText = "Quick Find"
        '
        'ToolStripButtonFindInFiles
        '
        Me.ToolStripButtonFindInFiles.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ToolStripButtonFindInFiles.Image = Global.Helixoft.MultiLineSearch.My.Resources.MainResources.vs2013_find_in_files
        Me.ToolStripButtonFindInFiles.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonFindInFiles.Margin = New System.Windows.Forms.Padding(10, 1, 0, 2)
        Me.ToolStripButtonFindInFiles.Name = "ToolStripButtonFindInFiles"
        Me.ToolStripButtonFindInFiles.Size = New System.Drawing.Size(73, 35)
        Me.ToolStripButtonFindInFiles.Text = "Find in Files"
        Me.ToolStripButtonFindInFiles.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        Me.ToolStripButtonFindInFiles.ToolTipText = "Find in Files"
        '
        'ToolStripButtonReplace
        '
        Me.ToolStripButtonReplace.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ToolStripButtonReplace.Image = Global.Helixoft.MultiLineSearch.My.Resources.MainResources.vs2013_replace
        Me.ToolStripButtonReplace.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonReplace.Margin = New System.Windows.Forms.Padding(10, 1, 0, 2)
        Me.ToolStripButtonReplace.Name = "ToolStripButtonReplace"
        Me.ToolStripButtonReplace.Size = New System.Drawing.Size(52, 35)
        Me.ToolStripButtonReplace.Text = "Replace"
        Me.ToolStripButtonReplace.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        Me.ToolStripButtonReplace.ToolTipText = "Quick Replace"
        '
        'ToolStripButtonReplaceInFiles
        '
        Me.ToolStripButtonReplaceInFiles.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ToolStripButtonReplaceInFiles.Image = Global.Helixoft.MultiLineSearch.My.Resources.MainResources.vs2013_replace_in_files
        Me.ToolStripButtonReplaceInFiles.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonReplaceInFiles.Margin = New System.Windows.Forms.Padding(10, 1, 0, 2)
        Me.ToolStripButtonReplaceInFiles.Name = "ToolStripButtonReplaceInFiles"
        Me.ToolStripButtonReplaceInFiles.Size = New System.Drawing.Size(91, 35)
        Me.ToolStripButtonReplaceInFiles.Text = "Replace in Files"
        Me.ToolStripButtonReplaceInFiles.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
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
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.PanelBottom.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CancelBtn As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ReplaceBox As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents FindBox As System.Windows.Forms.TextBox
    Friend WithEvents PanelTop As System.Windows.Forms.Panel
    Friend WithEvents PanelBottom As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButtonFind As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButtonFindInFiles As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButtonReplace As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButtonReplaceInFiles As System.Windows.Forms.ToolStripButton

End Class