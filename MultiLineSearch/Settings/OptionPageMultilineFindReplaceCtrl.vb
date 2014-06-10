

Namespace Settings


    ''' <summary>
    ''' Custom control for setting the package options.
    ''' </summary>
    ''' <remarks></remarks>
    Public Class OptionPageMultilineFindReplaceCtrl

        Private optionPage As OptionPageMultilineFindReplace


        Public Sub Initialize(ByVal optionPage As OptionPageMultilineFindReplace)
            Me.optionPage = optionPage

            UpdateControls()
        End Sub


        Private Sub UpdateControls()
            If Me.optionPage.CheckForUpdatesInterval < 0 Then
                Me.CheckBoxAutoUpdates.Checked = False
                Me.NumericUpDownDays.Value = Me.optionPage.CheckForUpdatesInterval * -1
            Else
                Me.CheckBoxAutoUpdates.Checked = True
                Me.NumericUpDownDays.Value = Me.optionPage.CheckForUpdatesInterval
            End If
        End Sub


        Public Sub ApplyChanges()
            Me.optionPage.CheckForUpdatesInterval = CInt(Me.NumericUpDownDays.Value)
            If Not Me.CheckBoxAutoUpdates.Checked Then
                Me.optionPage.CheckForUpdatesInterval *= -1
            End If
        End Sub


        Private Sub ButtonCheckUpdates_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCheckUpdates.Click
            try
                Dim updCheck As New Update.UpdateChecker
                updCheck.CheckForUpdates()
            Catch ex As Exception
            End Try
        End Sub

        Private Sub CheckBoxAutoUpdates_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxAutoUpdates.CheckedChanged
            Try
                Me.Label10.Enabled = Me.CheckBoxAutoUpdates.Checked
                Me.Label14.Enabled = Me.CheckBoxAutoUpdates.Checked
                Me.NumericUpDownDays.Enabled = Me.CheckBoxAutoUpdates.Checked
            Catch ex As Exception
            End Try
        End Sub
    End Class

End Namespace
