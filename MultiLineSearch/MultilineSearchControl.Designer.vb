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
        Me.SplitContainerFindRep = New System.Windows.Forms.SplitContainer
        Me.PanelBottom = New System.Windows.Forms.Panel
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.PanelButtons = New System.Windows.Forms.Panel
        Me.Label3 = New System.Windows.Forms.Label
        Me.ButtonFindOptionsCollapse = New System.Windows.Forms.Button
        Me.GroupBoxFindOptions = New System.Windows.Forms.GroupBox
        Me.CheckBoxIgnoreAllWs = New System.Windows.Forms.CheckBox
        Me.CheckBoxIgnoreTrailWs = New System.Windows.Forms.CheckBox
        Me.CheckBoxIgnoreLeadWs = New System.Windows.Forms.CheckBox
        Me.HelpIgnoreLeadWs = New System.Windows.Forms.Label
        Me.HelpIgnoreTraiWs = New System.Windows.Forms.Label
        Me.HelpIgnoreAllWs = New System.Windows.Forms.Label
        Me.PanelTop.SuspendLayout()
        Me.SplitContainerFindRep.Panel1.SuspendLayout()
        Me.SplitContainerFindRep.Panel2.SuspendLayout()
        Me.SplitContainerFindRep.SuspendLayout()
        Me.PanelBottom.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.PanelButtons.SuspendLayout()
        Me.GroupBoxFindOptions.SuspendLayout()
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
        Me.ReplaceInFilesBtn.Location = New System.Drawing.Point(292, 130)
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
        Me.ReplaceBtn.Location = New System.Drawing.Point(202, 130)
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
        Me.FindInFilesBtn.Location = New System.Drawing.Point(292, 100)
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
        Me.FindBtn.Location = New System.Drawing.Point(202, 100)
        Me.FindBtn.Name = "FindBtn"
        Me.FindBtn.Size = New System.Drawing.Size(84, 27)
        Me.FindBtn.TabIndex = 14
        Me.FindBtn.Text = "Find"
        Me.FindBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(3, 11)
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
        Me.ReplaceBox.Location = New System.Drawing.Point(3, 28)
        Me.ReplaceBox.Multiline = True
        Me.ReplaceBox.Name = "ReplaceBox"
        Me.ReplaceBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.ReplaceBox.Size = New System.Drawing.Size(412, 60)
        Me.ReplaceBox.TabIndex = 12
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(3, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(143, 14)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Find what:"
        '
        'FindBox
        '
        Me.FindBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FindBox.Location = New System.Drawing.Point(3, 19)
        Me.FindBox.Multiline = True
        Me.FindBox.Name = "FindBox"
        Me.FindBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.FindBox.Size = New System.Drawing.Size(412, 76)
        Me.FindBox.TabIndex = 10
        '
        'PanelTop
        '
        Me.PanelTop.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelTop.Controls.Add(Me.SplitContainerFindRep)
        Me.PanelTop.Location = New System.Drawing.Point(3, 3)
        Me.PanelTop.Name = "PanelTop"
        Me.PanelTop.Size = New System.Drawing.Size(418, 203)
        Me.PanelTop.TabIndex = 0
        '
        'SplitContainerFindRep
        '
        Me.SplitContainerFindRep.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainerFindRep.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerFindRep.Name = "SplitContainerFindRep"
        Me.SplitContainerFindRep.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainerFindRep.Panel1
        '
        Me.SplitContainerFindRep.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainerFindRep.Panel1.Controls.Add(Me.FindBox)
        Me.SplitContainerFindRep.Panel1MinSize = 40
        '
        'SplitContainerFindRep.Panel2
        '
        Me.SplitContainerFindRep.Panel2.Controls.Add(Me.Label2)
        Me.SplitContainerFindRep.Panel2.Controls.Add(Me.ReplaceBox)
        Me.SplitContainerFindRep.Panel2MinSize = 40
        Me.SplitContainerFindRep.Size = New System.Drawing.Size(418, 203)
        Me.SplitContainerFindRep.SplitterDistance = 108
        Me.SplitContainerFindRep.TabIndex = 14
        '
        'PanelBottom
        '
        Me.PanelBottom.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelBottom.Controls.Add(Me.CancelBtn)
        Me.PanelBottom.Location = New System.Drawing.Point(3, 390)
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
        Me.TableLayoutPanel1.Controls.Add(Me.PanelBottom, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.PanelTop, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.PanelButtons, 0, 1)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 209.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 164.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(424, 435)
        Me.TableLayoutPanel1.TabIndex = 20
        '
        'PanelButtons
        '
        Me.PanelButtons.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelButtons.Controls.Add(Me.Label3)
        Me.PanelButtons.Controls.Add(Me.ButtonFindOptionsCollapse)
        Me.PanelButtons.Controls.Add(Me.GroupBoxFindOptions)
        Me.PanelButtons.Controls.Add(Me.ReplaceInFilesBtn)
        Me.PanelButtons.Controls.Add(Me.FindBtn)
        Me.PanelButtons.Controls.Add(Me.ReplaceBtn)
        Me.PanelButtons.Controls.Add(Me.FindInFilesBtn)
        Me.PanelButtons.Location = New System.Drawing.Point(3, 212)
        Me.PanelButtons.Name = "PanelButtons"
        Me.PanelButtons.Size = New System.Drawing.Size(418, 158)
        Me.PanelButtons.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(25, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 13)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Find options"
        '
        'ButtonFindOptionsCollapse
        '
        Me.ButtonFindOptionsCollapse.Image = Global.Helixoft.MultiLineSearch.My.Resources.MainResources.minus
        Me.ButtonFindOptionsCollapse.Location = New System.Drawing.Point(5, 10)
        Me.ButtonFindOptionsCollapse.Name = "ButtonFindOptionsCollapse"
        Me.ButtonFindOptionsCollapse.Size = New System.Drawing.Size(18, 18)
        Me.ButtonFindOptionsCollapse.TabIndex = 0
        Me.ButtonFindOptionsCollapse.UseVisualStyleBackColor = True
        '
        'GroupBoxFindOptions
        '
        Me.GroupBoxFindOptions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBoxFindOptions.Controls.Add(Me.HelpIgnoreAllWs)
        Me.GroupBoxFindOptions.Controls.Add(Me.HelpIgnoreTraiWs)
        Me.GroupBoxFindOptions.Controls.Add(Me.HelpIgnoreLeadWs)
        Me.GroupBoxFindOptions.Controls.Add(Me.CheckBoxIgnoreAllWs)
        Me.GroupBoxFindOptions.Controls.Add(Me.CheckBoxIgnoreTrailWs)
        Me.GroupBoxFindOptions.Controls.Add(Me.CheckBoxIgnoreLeadWs)
        Me.GroupBoxFindOptions.Cursor = System.Windows.Forms.Cursors.Default
        Me.GroupBoxFindOptions.Location = New System.Drawing.Point(6, 9)
        Me.GroupBoxFindOptions.Name = "GroupBoxFindOptions"
        Me.GroupBoxFindOptions.Size = New System.Drawing.Size(409, 84)
        Me.GroupBoxFindOptions.TabIndex = 18
        Me.GroupBoxFindOptions.TabStop = False
        '
        'CheckBoxIgnoreAllWs
        '
        Me.CheckBoxIgnoreAllWs.AutoSize = True
        Me.CheckBoxIgnoreAllWs.Location = New System.Drawing.Point(17, 63)
        Me.CheckBoxIgnoreAllWs.Name = "CheckBoxIgnoreAllWs"
        Me.CheckBoxIgnoreAllWs.Size = New System.Drawing.Size(131, 17)
        Me.CheckBoxIgnoreAllWs.TabIndex = 2
        Me.CheckBoxIgnoreAllWs.Text = "Ignore all whitespaces"
        Me.CheckBoxIgnoreAllWs.UseVisualStyleBackColor = True
        '
        'CheckBoxIgnoreTrailWs
        '
        Me.CheckBoxIgnoreTrailWs.AutoSize = True
        Me.CheckBoxIgnoreTrailWs.Location = New System.Drawing.Point(17, 43)
        Me.CheckBoxIgnoreTrailWs.Name = "CheckBoxIgnoreTrailWs"
        Me.CheckBoxIgnoreTrailWs.Size = New System.Drawing.Size(151, 17)
        Me.CheckBoxIgnoreTrailWs.TabIndex = 1
        Me.CheckBoxIgnoreTrailWs.Text = "Ignore trailing whitespaces"
        Me.CheckBoxIgnoreTrailWs.UseVisualStyleBackColor = True
        '
        'CheckBoxIgnoreLeadWs
        '
        Me.CheckBoxIgnoreLeadWs.AutoSize = True
        Me.CheckBoxIgnoreLeadWs.Location = New System.Drawing.Point(17, 23)
        Me.CheckBoxIgnoreLeadWs.Name = "CheckBoxIgnoreLeadWs"
        Me.CheckBoxIgnoreLeadWs.Size = New System.Drawing.Size(155, 17)
        Me.CheckBoxIgnoreLeadWs.TabIndex = 0
        Me.CheckBoxIgnoreLeadWs.Text = "Ignore leading whitespaces"
        Me.CheckBoxIgnoreLeadWs.UseVisualStyleBackColor = True
        '
        'HelpIgnoreLeadWs
        '
        Me.HelpIgnoreLeadWs.Cursor = System.Windows.Forms.Cursors.Help
        Me.HelpIgnoreLeadWs.Image = Global.Helixoft.MultiLineSearch.My.Resources.MainResources.help
        Me.HelpIgnoreLeadWs.Location = New System.Drawing.Point(193, 23)
        Me.HelpIgnoreLeadWs.Name = "HelpIgnoreLeadWs"
        Me.HelpIgnoreLeadWs.Size = New System.Drawing.Size(16, 16)
        Me.HelpIgnoreLeadWs.TabIndex = 3
        '
        'HelpIgnoreTraiWs
        '
        Me.HelpIgnoreTraiWs.Cursor = System.Windows.Forms.Cursors.Help
        Me.HelpIgnoreTraiWs.Image = Global.Helixoft.MultiLineSearch.My.Resources.MainResources.help
        Me.HelpIgnoreTraiWs.Location = New System.Drawing.Point(193, 43)
        Me.HelpIgnoreTraiWs.Name = "HelpIgnoreTraiWs"
        Me.HelpIgnoreTraiWs.Size = New System.Drawing.Size(16, 16)
        Me.HelpIgnoreTraiWs.TabIndex = 4
        '
        'HelpIgnoreAllWs
        '
        Me.HelpIgnoreAllWs.Cursor = System.Windows.Forms.Cursors.Help
        Me.HelpIgnoreAllWs.Image = Global.Helixoft.MultiLineSearch.My.Resources.MainResources.help
        Me.HelpIgnoreAllWs.Location = New System.Drawing.Point(193, 63)
        Me.HelpIgnoreAllWs.Name = "HelpIgnoreAllWs"
        Me.HelpIgnoreAllWs.Size = New System.Drawing.Size(16, 16)
        Me.HelpIgnoreAllWs.TabIndex = 5
        '
        'MultilineSearchControl
        '
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "MultilineSearchControl"
        Me.Size = New System.Drawing.Size(424, 441)
        Me.PanelTop.ResumeLayout(False)
        Me.SplitContainerFindRep.Panel1.ResumeLayout(False)
        Me.SplitContainerFindRep.Panel1.PerformLayout()
        Me.SplitContainerFindRep.Panel2.ResumeLayout(False)
        Me.SplitContainerFindRep.Panel2.PerformLayout()
        Me.SplitContainerFindRep.ResumeLayout(False)
        Me.PanelBottom.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.PanelButtons.ResumeLayout(False)
        Me.PanelButtons.PerformLayout()
        Me.GroupBoxFindOptions.ResumeLayout(False)
        Me.GroupBoxFindOptions.PerformLayout()
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
    Friend WithEvents PanelButtons As System.Windows.Forms.Panel
    Friend WithEvents SplitContainerFindRep As System.Windows.Forms.SplitContainer
    Friend WithEvents GroupBoxFindOptions As System.Windows.Forms.GroupBox
    Friend WithEvents ButtonFindOptionsCollapse As System.Windows.Forms.Button
    Friend WithEvents CheckBoxIgnoreLeadWs As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxIgnoreTrailWs As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxIgnoreAllWs As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents HelpIgnoreLeadWs As System.Windows.Forms.Label
    Friend WithEvents HelpIgnoreAllWs As System.Windows.Forms.Label
    Friend WithEvents HelpIgnoreTraiWs As System.Windows.Forms.Label

End Class