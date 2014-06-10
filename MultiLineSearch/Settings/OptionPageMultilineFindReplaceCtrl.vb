

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
            Me.NumericUpDownDays.Value = Me.optionPage.CheckForUpdatesInterval

        End Sub


        Public Sub ApplyChanges()
            Me.optionPage.CheckForUpdatesInterval = CInt(Me.NumericUpDownDays.Value)
        End Sub

    End Class

End Namespace
