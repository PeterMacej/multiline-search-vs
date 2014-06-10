Namespace Settings

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class OptionPageMultilineFindReplaceCtrl
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
            Me.Label9 = New System.Windows.Forms.Label
            Me.Label18 = New System.Windows.Forms.Label
            Me.Label17 = New System.Windows.Forms.Label
            Me.Label14 = New System.Windows.Forms.Label
            Me.NumericUpDownDays = New System.Windows.Forms.NumericUpDown
            Me.CheckBoxAutoUpdates = New System.Windows.Forms.CheckBox
            Me.ButtonCheckUpdates = New System.Windows.Forms.Button
            Me.Label10 = New System.Windows.Forms.Label
            CType(Me.NumericUpDownDays, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'Label9
            '
            Me.Label9.Location = New System.Drawing.Point(19, 115)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(360, 48)
            Me.Label9.TabIndex = 13
            Me.Label9.Text = "You will be only notified if a newer version is found. No message box will be sho" & _
                "wn during checking for an update or if there is no update available."
            '
            'Label18
            '
            Me.Label18.Location = New System.Drawing.Point(19, 83)
            Me.Label18.Name = "Label18"
            Me.Label18.Size = New System.Drawing.Size(360, 40)
            Me.Label18.TabIndex = 18
            Me.Label18.Text = "The new version will NOT be automatically installed or downloaded."
            '
            'Label17
            '
            Me.Label17.Location = New System.Drawing.Point(19, 163)
            Me.Label17.Name = "Label17"
            Me.Label17.Size = New System.Drawing.Size(360, 56)
            Me.Label17.TabIndex = 17
            Me.Label17.Text = "No personal information will be sent."
            '
            'Label14
            '
            Me.Label14.Location = New System.Drawing.Point(155, 35)
            Me.Label14.Name = "Label14"
            Me.Label14.Size = New System.Drawing.Size(64, 16)
            Me.Label14.TabIndex = 16
            Me.Label14.Text = "days"
            '
            'NumericUpDownDays
            '
            Me.NumericUpDownDays.Location = New System.Drawing.Point(107, 33)
            Me.NumericUpDownDays.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
            Me.NumericUpDownDays.Name = "NumericUpDownDays"
            Me.NumericUpDownDays.Size = New System.Drawing.Size(48, 20)
            Me.NumericUpDownDays.TabIndex = 15
            Me.NumericUpDownDays.Value = New Decimal(New Integer() {7, 0, 0, 0})
            '
            'CheckBoxAutoUpdates
            '
            Me.CheckBoxAutoUpdates.Location = New System.Drawing.Point(3, 3)
            Me.CheckBoxAutoUpdates.Name = "CheckBoxAutoUpdates"
            Me.CheckBoxAutoUpdates.Size = New System.Drawing.Size(312, 24)
            Me.CheckBoxAutoUpdates.TabIndex = 14
            Me.CheckBoxAutoUpdates.Text = "Automatically check for updates"
            '
            'ButtonCheckUpdates
            '
            Me.ButtonCheckUpdates.Location = New System.Drawing.Point(179, 251)
            Me.ButtonCheckUpdates.Name = "ButtonCheckUpdates"
            Me.ButtonCheckUpdates.Size = New System.Drawing.Size(200, 24)
            Me.ButtonCheckUpdates.TabIndex = 12
            Me.ButtonCheckUpdates.Text = "Check for updates now"
            '
            'Label10
            '
            Me.Label10.Location = New System.Drawing.Point(51, 35)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(64, 16)
            Me.Label10.TabIndex = 11
            Me.Label10.Text = "Every"
            '
            'OptionPageMultilineFindReplaceCtrl
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.Label9)
            Me.Controls.Add(Me.Label18)
            Me.Controls.Add(Me.Label17)
            Me.Controls.Add(Me.Label14)
            Me.Controls.Add(Me.NumericUpDownDays)
            Me.Controls.Add(Me.CheckBoxAutoUpdates)
            Me.Controls.Add(Me.ButtonCheckUpdates)
            Me.Controls.Add(Me.Label10)
            Me.Name = "OptionPageMultilineFindReplaceCtrl"
            Me.Size = New System.Drawing.Size(388, 287)
            CType(Me.NumericUpDownDays, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents Label18 As System.Windows.Forms.Label
        Friend WithEvents Label17 As System.Windows.Forms.Label
        Friend WithEvents Label14 As System.Windows.Forms.Label
        Friend WithEvents NumericUpDownDays As System.Windows.Forms.NumericUpDown
        Friend WithEvents CheckBoxAutoUpdates As System.Windows.Forms.CheckBox
        Friend WithEvents ButtonCheckUpdates As System.Windows.Forms.Button
        Friend WithEvents Label10 As System.Windows.Forms.Label

    End Class

End Namespace
