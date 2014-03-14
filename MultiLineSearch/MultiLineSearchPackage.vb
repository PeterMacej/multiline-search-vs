﻿' Implementation of MultiLineSearch
'

Imports Microsoft.VisualBasic
Imports System
Imports System.Diagnostics
Imports System.Globalization
Imports System.Runtime.InteropServices
Imports System.ComponentModel.Design
Imports Microsoft.Win32
Imports Microsoft.VisualStudio.Shell.Interop
Imports Microsoft.VisualStudio.OLE.Interop
Imports Microsoft.VisualStudio.Shell
Imports EnvDTE80

''' <summary>
''' This is the class that implements the package exposed by this assembly.
'''
''' The minimum requirement for a class to be considered a valid package for Visual Studio
''' is to implement the IVsPackage interface and register itself with the shell.
''' This package uses the helper classes defined inside the Managed Package Framework (MPF)
''' to do it: it derives from the Package class that provides the implementation of the 
''' IVsPackage interface and uses the registration attributes defined in the framework to 
''' register itself and its components with the shell.
''' </summary>
''' <remarks>
''' The PackageRegistration attribute tells the registration utility (regpkg.exe) that this class needs
''' to be registered as package.
'''
''' A Visual Studio component can be registered under different regitry roots; for instance
''' when you debug your package you want to register it in the experimental hive. The DefaultRegistryRoot
''' attribute specifies the registry root to use if no one is provided to regpkg.exe with
''' the /root switch.
'''
''' The InstalledProductRegistration attribute is used to register the information needed to show this package
''' in the Help/About dialog of Visual Studio.
'''
''' In order be loaded inside Visual Studio in a machine that does not have the VS SDK installed, 
''' the package needs to have a valid load key (it can be requested at 
''' http://msdn.microsoft.com/vstudio/extend/). The [ProvideLoadKey attribute tells the shell that this 
''' package has a load key embedded in its resources.
'''
''' The ProvideMenuResource attribute is needed to let the shell know that this package exposes some menus.
'''
''' The ProvideToolWindow attribute registers a tool window exposed by this package.
''' </remarks>
<PackageRegistration(UseManagedResourcesOnly:=True), _
DefaultRegistryRoot("Software\\Microsoft\\VisualStudio\\8.0"), _
InstalledProductRegistration(False, "#110", "#112", "1.0", IconResourceID:=400), _
ProvideLoadKey("Standard", "1.1", "Multiline Search and Replace", "Helixoft", 1), _
ProvideMenuResource(1000, 1), _
ProvideToolWindow(GetType(MyToolWindow)), _
Guid(GuidList.guidMultiLineSearchPkgString)> _
Public NotInheritable Class MultiLineSearchPackage
    Inherits Package


    Private dteInitializer As DteInitializer
    Private dte As EnvDTE80.DTE2
    Private searchForm As MultilineSearchForm


    ''' <summary>
    ''' Default constructor of the package.
    ''' Inside this method you can place any initialization code that does not require 
    ''' any Visual Studio service because at this point the package object is created but 
    ''' not sited yet inside Visual Studio environment. The place to do all the other 
    ''' initialization is the Initialize method.
    ''' </summary>
    Public Sub New()
        Trace.WriteLine(String.Format(CultureInfo.CurrentCulture, "Entering constructor for: {0}", Me.GetType().Name))
    End Sub



    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' Overriden Package Implementation
#Region "Package Members"

    ''' <summary>
    ''' Initialization of the package; this method is called right after the package is sited, so this is the place
    ''' where you can put all the initilaization code that rely on services provided by VisualStudio.
    ''' </summary>
    Protected Overrides Sub Initialize()
        Trace.WriteLine(String.Format(CultureInfo.CurrentCulture, "Entering Initialize() of: {0}", Me.GetType().Name))
        MyBase.Initialize()

        InitializeDTE()

        ' Add our command handlers for menu (commands must exist in the .vsct file)
        Dim mcs As OleMenuCommandService = TryCast(GetService(GetType(IMenuCommandService)), OleMenuCommandService)
        If Not mcs Is Nothing Then
            ' Create the command for the menu item.
            Dim menuCommandID As New CommandID(GuidList.guidMultiLineSearchCmdSet, CInt(PkgCmdIDList.cmdidMultilineFind))
            Dim menuItem As New MenuCommand(New EventHandler(AddressOf MultilineFindCommandCallback), menuCommandID)
            mcs.AddCommand(menuItem)
        End If
    End Sub
#End Region


    Private Sub InitializeDTE()
        Dim shellService As IVsShell

        Me.dte = TryCast(Me.GetService(GetType(Microsoft.VisualStudio.Shell.Interop.SDTE)), EnvDTE80.DTE2)

        If Me.dte Is Nothing Then
            ' The IDE is not yet fully initialized
            shellService = TryCast(Me.GetService(GetType(SVsShell)), IVsShell)
            Me.dteInitializer = New DteInitializer(shellService, AddressOf Me.InitializeDTE)
        Else
            Me.dteInitializer = Nothing
        End If
    End Sub


    ''' <summary>
    ''' This function is the callback used to execute a command when the a menu item is clicked.
    ''' See the Initialize method to see how the menu item is associated to this function using
    ''' the OleMenuCommandService service and the MenuCommand class.
    ''' </summary>
    Private Sub MultilineFindCommandCallback(ByVal sender As Object, ByVal e As EventArgs)
        Dim uiShell As IVsUIShell = TryCast(GetService(GetType(SVsUIShell)), IVsUIShell)
        Dim clsid As Guid = Guid.Empty

        'Dim result As Integer
        'Microsoft.VisualStudio.ErrorHandler.ThrowOnFailure(uiShell.ShowMessageBox(0, clsid, "Multiline Search and Replace", String.Format(CultureInfo.CurrentCulture, "Inside {0}.MenuItemCallback()", Me.GetType().Name), String.Empty, 0, OLEMSGBUTTON.OLEMSGBUTTON_OK, OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST, OLEMSGICON.OLEMSGICON_INFO, 0, result))

        If searchForm Is Nothing Then
            searchForm = New MultilineSearchForm(dte)
        End If
        Dim winptr As New WinWrapper(dte)
        Microsoft.VisualStudio.ErrorHandler.ThrowOnFailure(searchForm.ShowDialog(winptr))
    End Sub


    ''' <summary>
    ''' This function is called when the user clicks the menu item that shows the 
    ''' tool window. See the Initialize method to see how the menu item is associated to 
    ''' this function using the OleMenuCommandService service and the MenuCommand class.
    ''' </summary>
    Private Sub ShowToolWindow(ByVal sender As Object, ByVal e As EventArgs)
        ' Get the instance number 0 of this tool window. This window is single instance so this instance
        ' is actually the only one.
        ' The last flag is set to true so that if the tool window does not exists it will be created.
        Dim window As ToolWindowPane = Me.FindToolWindow(GetType(MyToolWindow), 0, True)
        If (window Is Nothing) Or (window.Frame Is Nothing) Then
            Throw New NotSupportedException(My.Resources.CanNotCreateWindow)
        End If

        Dim windowFrame As IVsWindowFrame = TryCast(window.Frame, IVsWindowFrame)
        Microsoft.VisualStudio.ErrorHandler.ThrowOnFailure(windowFrame.Show())
    End Sub

End Class


''' <summary>
''' Helper class for passing parent window argument to ShowDialog method.
''' </summary>
''' <remarks>See http://support.microsoft.com/kb/312877 for details.</remarks>
Friend Class WinWrapper
    Implements System.Windows.Forms.IWin32Window

    Private vsinstance As DTE2

    Sub New(ByVal dte As DTE2)
        vsinstance = dte
    End Sub

    Overridable ReadOnly Property Handle() As System.IntPtr Implements System.Windows.Forms.IWin32Window.Handle
        Get
            Dim iptr As New System.IntPtr(vsinstance.MainWindow.HWnd)
            Return iptr
        End Get
    End Property
End Class