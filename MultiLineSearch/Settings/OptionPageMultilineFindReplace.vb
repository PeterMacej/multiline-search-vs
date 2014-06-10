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
    Guid("E0B68D27-9489-4053-AB39-6701AC637C30")> _
    Public Class OptionPageMultilineFindReplace
        Inherits DialogPage


        Private pageCtrl As OptionPageMultilineFindReplaceCtrl = Nothing


        Public Sub New()
            SetDefaultValues()
        End Sub


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


        ''' <summary>
        ''' Set default values.
        ''' </summary>
        ''' <remarks></remarks>
        Public Overrides Sub ResetSettings()
            SetDefaultValues()
            MyBase.ResetSettings()
        End Sub


        ''' <summary>
        ''' Set default values.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub SetDefaultValues()
            Me.CheckForUpdatesInterval = 7
            Me.LastCheckForUpdatesDate = DateTime.Today
            Me.IsFindOptionsCollapsed = False
            Me.IgnoreLeadingWs = False
            Me.IgnoreTrailingWs = False
            Me.IgnoreAllWs = False
        End Sub


#Region "Settings properties"


        Private mCheckForUpdatesInterval As Integer
        ''' <summary>
        ''' Gets or sets interval of automatic check for updates in days.
        ''' </summary>
        ''' <value>-1 if check is disabled.</value>
        ''' <remarks></remarks>
        <Category("Update")> _
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


        Private mLastCheckForUpdatesDate As DateTime
        ''' <summary>
        ''' Gets or sets the date of the last check for updates.
        ''' </summary>
        ''' <value></value>
        ''' <remarks></remarks>
        Public Property LastCheckForUpdatesDate() As DateTime
            Get
                Return mLastCheckForUpdatesDate
            End Get
            Set(ByVal value As DateTime)
                mLastCheckForUpdatesDate = value
            End Set
        End Property


        Private mIsFindOptionsCollapsed As Boolean
        ''' <summary>
        ''' Gets or sets a value indicating whether Find options section is collapsed
        ''' in Find/Search window.
        ''' </summary>
        ''' <value><see langword="true"/> if Find options section is collapsed; otherwise, <see langword="false"/>.</value>
        ''' <remarks></remarks>
        Public Property IsFindOptionsCollapsed() As Boolean
            Get
                Return mIsFindOptionsCollapsed
            End Get
            Set(ByVal value As Boolean)
                mIsFindOptionsCollapsed = value
            End Set
        End Property


        Private mIgnoreLeadingWs As Boolean
        ''' <summary>
        ''' Gets or sets a value indicating whether to ignore leading whitespaces.
        ''' </summary>
        ''' <value><see langword="true"/> if leading whitespaces are ignored; otherwise, <see langword="false"/>.</value>
        ''' <remarks></remarks>
        Public Property IgnoreLeadingWs() As Boolean
            Get
                Return mIgnoreLeadingWs
            End Get
            Set(ByVal value As Boolean)
                mIgnoreLeadingWs = value
            End Set
        End Property


        Private mIgnoreTrailingWs As Boolean
        ''' <summary>
        ''' Gets or sets a value indicating whether to ignore trailing whitespaces.
        ''' </summary>
        ''' <value><see langword="true"/> if trailing whitespaces are ignored; otherwise, <see langword="false"/>.</value>
        ''' <remarks></remarks>
        Public Property IgnoreTrailingWs() As Boolean
            Get
                Return mIgnoreTrailingWs
            End Get
            Set(ByVal value As Boolean)
                mIgnoreTrailingWs = value
            End Set
        End Property


        Private mIgnoreAllWs As Boolean
        ''' <summary>
        ''' Gets or sets a value indicating whether to ignore all whitespaces.
        ''' </summary>
        ''' <value><see langword="true"/> if all whitespaces are ignored; otherwise, <see langword="false"/>.</value>
        ''' <remarks></remarks>
        Public Property IgnoreAllWs() As Boolean
            Get
                Return mIgnoreAllWs
            End Get
            Set(ByVal value As Boolean)
                mIgnoreAllWs = value
            End Set
        End Property


#End Region


    End Class

End Namespace
