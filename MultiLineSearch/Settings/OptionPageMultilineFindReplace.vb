Imports Microsoft.VisualStudio.Shell
Imports System.Runtime.InteropServices
Imports System.ComponentModel
Imports System.Windows.Forms


Namespace Settings

    ''' <summary>
    ''' Package options
    ''' </summary>
    ''' <remarks></remarks>
    <ClassInterface(ClassInterfaceType.AutoDual), _
    Guid("42C7F4D9-200D-4fe2-A093-49AFA2DDE7F8")> _
    Public Class OptionPageMultilineFindReplace
        Inherits DialogPage


        Private pageCtrl As OptionPageMultilineFindReplaceCtrl = Nothing

        <Browsable(False)> _
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
        Protected Overrides ReadOnly Property Window() As IWin32Window
            Get
                If pageCtrl Is Nothing Then
                    pageCtrl = New OptionPageMultilineFindReplaceCtrl()
                End If
                pageCtrl.Initialize(Me)

                Return pageCtrl
            End Get
        End Property


        Private mCheckForUpdatesInterval As Integer
        ''' <summary>
        ''' Gets or sets interval of automatic check for updates in days.
        ''' </summary>
        ''' <value>-1 if check is disabled.</value>
        ''' <remarks></remarks>
        <Category("Environment")> _
        <DisplayName("Automatically check for updates")> _
        <Description("Interval of automatic check for updates in days.")> _
        Public Property CheckForUpdatesInterval() As Integer
            Get
                Return mCheckForUpdatesInterval
            End Get
            Set(ByVal value As Integer)
                mCheckForUpdatesInterval = value
            End Set
        End Property


        Protected Overrides Sub OnApply(ByVal e As Microsoft.VisualStudio.Shell.DialogPage.PageApplyEventArgs)
            If e.ApplyBehavior = ApplyKind.Apply Then
                If pageCtrl IsNot Nothing Then
                    pageCtrl.ApplyChanges()
                End If
            End If

            ' persist settings
            MyBase.OnApply(e)
        End Sub


        Protected Overrides Sub OnActivate(ByVal e As System.ComponentModel.CancelEventArgs)
            MyBase.OnActivate(e)

            pageCtrl.Initialize(Me)
        End Sub




    End Class

End Namespace
