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
        Me.SuspendLayout()
        '
        'CancelBtn
        '
        Me.CancelBtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CancelBtn.Location = New System.Drawing.Point(164, 280)
        Me.CancelBtn.Name = "CancelBtn"
        Me.CancelBtn.Size = New System.Drawing.Size(80, 24)
        Me.CancelBtn.TabIndex = 18
        Me.CancelBtn.Text = "Cancel"
        '
        'ReplaceInFilesBtn
        '
        Me.ReplaceInFilesBtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ReplaceInFilesBtn.Location = New System.Drawing.Point(300, 240)
        Me.ReplaceInFilesBtn.Name = "ReplaceInFilesBtn"
        Me.ReplaceInFilesBtn.Size = New System.Drawing.Size(112, 24)
        Me.ReplaceInFilesBtn.TabIndex = 17
        Me.ReplaceInFilesBtn.Text = "Replace in Files >>"
        '
        'ReplaceBtn
        '
        Me.ReplaceBtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ReplaceBtn.Location = New System.Drawing.Point(212, 240)
        Me.ReplaceBtn.Name = "ReplaceBtn"
        Me.ReplaceBtn.Size = New System.Drawing.Size(80, 24)
        Me.ReplaceBtn.TabIndex = 16
        Me.ReplaceBtn.Text = "Replace >>"
        '
        'FindInFilesBtn
        '
        Me.FindInFilesBtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.FindInFilesBtn.Location = New System.Drawing.Point(100, 240)
        Me.FindInFilesBtn.Name = "FindInFilesBtn"
        Me.FindInFilesBtn.Size = New System.Drawing.Size(96, 24)
        Me.FindInFilesBtn.TabIndex = 15
        Me.FindInFilesBtn.Text = "Find in Files >>"
        '
        'FindBtn
        '
        Me.FindBtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.FindBtn.Location = New System.Drawing.Point(12, 240)
        Me.FindBtn.Name = "FindBtn"
        Me.FindBtn.Size = New System.Drawing.Size(80, 24)
        Me.FindBtn.TabIndex = 14
        Me.FindBtn.Text = "Find >>"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(12, 120)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(160, 16)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Replace with:"
        '
        'ReplaceBox
        '
        Me.ReplaceBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ReplaceBox.Location = New System.Drawing.Point(12, 136)
        Me.ReplaceBox.Multiline = True
        Me.ReplaceBox.Name = "ReplaceBox"
        Me.ReplaceBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.ReplaceBox.Size = New System.Drawing.Size(400, 80)
        Me.ReplaceBox.TabIndex = 12
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(12, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(160, 16)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Find what:"
        '
        'FindBox
        '
        Me.FindBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FindBox.Location = New System.Drawing.Point(12, 32)
        Me.FindBox.Multiline = True
        Me.FindBox.Name = "FindBox"
        Me.FindBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.FindBox.Size = New System.Drawing.Size(400, 80)
        Me.FindBox.TabIndex = 10
        '
        'MultilineSearchControl
        '
        Me.Controls.Add(Me.CancelBtn)
        Me.Controls.Add(Me.ReplaceInFilesBtn)
        Me.Controls.Add(Me.ReplaceBtn)
        Me.Controls.Add(Me.FindInFilesBtn)
        Me.Controls.Add(Me.FindBtn)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ReplaceBox)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.FindBox)
        Me.Name = "MultilineSearchControl"
        Me.Size = New System.Drawing.Size(424, 313)
        Me.ResumeLayout(False)
        Me.PerformLayout()

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

End Class