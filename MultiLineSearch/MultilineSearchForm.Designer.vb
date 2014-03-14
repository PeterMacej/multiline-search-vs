<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MultilineSearchForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MultilineSearchForm))
        Me.MultilineSearchControl1 = New Helixoft.MultiLineSearch.MultilineSearchControl
        Me.SuspendLayout()
        '
        'MultilineSearchControl1
        '
        Me.MultilineSearchControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MultilineSearchControl1.Location = New System.Drawing.Point(4, -1)
        Me.MultilineSearchControl1.Name = "MultilineSearchControl1"
        Me.MultilineSearchControl1.SearchProvider = Nothing
        Me.MultilineSearchControl1.Size = New System.Drawing.Size(424, 313)
        Me.MultilineSearchControl1.TabIndex = 0
        '
        'MultilineSearchForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(432, 313)
        Me.Controls.Add(Me.MultilineSearchControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "MultilineSearchForm"
        Me.ShowInTaskbar = False
        Me.Text = "Multiline Search and Replace"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MultilineSearchControl1 As Helixoft.MultiLineSearch.MultilineSearchControl
End Class
