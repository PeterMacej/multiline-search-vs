using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using System.ComponentModel.Design;
using Microsoft.Win32;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Shell;
using Helixoft.MultiLineSearch.Settings;
using Helixoft.MultiLineSearch.Gui;


namespace Helixoft.MultiLineSearch
{
    /// <summary>
    /// This is the class that implements the package exposed by this assembly.
    ///
    /// The minimum requirement for a class to be considered a valid package for Visual Studio
    /// is to implement the IVsPackage interface and register itself with the shell.
    /// This package uses the helper classes defined inside the Managed Package Framework (MPF)
    /// to do it: it derives from the Package class that provides the implementation of the 
    /// IVsPackage interface and uses the registration attributes defined in the framework to 
    /// register itself and its components with the shell.
    /// </summary>
    /// <remarks>
    /// A Visual Studio component can be registered under different registry roots; for instance
    /// when you debug your package you want to register it in the experimental hive. The DefaultRegistryRoot
    /// attribute specifies the registry root to use if no one is provided to regpkg.exe with
    /// the /root switch.
    /// </remarks>
    // This attribute tells the PkgDef creation utility (CreatePkgDef.exe) that this class is
    // a package.
    [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
    // This attribute is used to register the information needed to show this package
    // in the Help/About dialog of Visual Studio.
    [InstalledProductRegistration("#110", "#112", "2.6", IconResourceID = 400)]
    // This attribute is needed to let the shell know that this package exposes some menus.
    [ProvideMenuResource("Menus.ctmenu", 1)]
    // This attribute registers a tool window exposed by this package.
    [ProvideToolWindow(typeof(MyToolWindow))]
    [Guid(GuidList.GUID_MULTI_LINE_SEARCH_PKG_STRING)]
    // registers the options page
    //[ProvideOptionPage(GetType(OptionPageMultilineFindReplace), "Environment", "Multiline Find and Replace", 0, 120, true)]
    // The ProvideProfile attribute registers settings category in Import/Export Settings. Note,
    // ProvideProfileAttribute is designed to write resource IDs for unmanaged resources
    // to the system registry. The Visual Studio resource loader expects unmanaged resource IDs 
    // to have numeric values preceded by "#", and managed resources to have numeric values with
    // no preceding "#". Therefore, we have to delete the "#" for managed resource IDs in registry manually.
    [ProvideProfile(typeof(OptionPageMultilineFindReplace), "Environment", "MultilineFindandReplace", 122, 123, true, DescriptionResourceID = 124)]
    public sealed class MultiLineSearchPackage : AsyncPackage
    {

        private DteInitializer dteInitializer;

        #region "Properties"

        private EnvDTE80.DTE2 mDte = null;
        /// <summary>
        /// Gets the DTE object.
        /// </summary>
        /// <value>Nothing if the IDE is not yet fully initialized.</value>
        /// <remarks></remarks>
        public EnvDTE80.DTE2 Dte
        {
            get { return mDte; }
        }


        /// <summary>
        /// Gets package main options.
        /// </summary>
        /// <value></value>
        /// <remarks></remarks>
        public OptionPageMultilineFindReplace PackageOptions
        {
            get { return this.GetDialogPage(typeof(OptionPageMultilineFindReplace)) as OptionPageMultilineFindReplace; }
        }

        #endregion



        /// <summary>
        /// Default constructor of the package.
        /// Inside this method you can place any initialization code that does not require 
        /// any Visual Studio service because at this point the package object is created but 
        /// not sited yet inside Visual Studio environment. The place to do all the other 
        /// initialization is the Initialize method.
        /// </summary>
        public MultiLineSearchPackage()
        {
            Debug.WriteLine(string.Format(CultureInfo.CurrentCulture, "Entering constructor for: {0}", this.ToString()));
        }


        /////////////////////////////////////////////////////////////////////////////
        // Overridden AsyncPackage Implementation
        #region Package Members

        /// <summary>
        /// The async initialization portion of the package initialization process. This method is invoked from a background thread.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token to monitor for initialization cancellation, which can occur when VS is shutting down.</param>
        /// <param name="progress"></param>
        /// <returns>A task representing the async work of package initialization, or an already completed task if there is none. Do not return null from this method.</returns>
        /// <remarks></remarks>
        protected override System.Threading.Tasks.Task InitializeAsync(System.Threading.CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
        {
            return ThreadHelper.JoinableTaskFactory.RunAsync<object>(async () =>
            {
                await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync();
                //IVsUIShell shellService = await asyncServiceProvider.GetServiceAsync<IVsUIShell>(typeof(SVsUIShell));
                this.MainThreadInitialization();
                return null;
            }).Task;
        }

        #endregion


        private void MainThreadInitialization()
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            InitializeDte();

            // Add our command handlers for menu (commands must exist in the .vsct file)
            OleMenuCommandService mcs = GetService(typeof(IMenuCommandService)) as OleMenuCommandService;
            if ((mcs != null))
            {
                // Create the command for the menu item.
                CommandID menuCommandID = new CommandID(GuidList.GuidMultiLineSearchCmdSet, Convert.ToInt32(PkgCmdIDList.CMDID_MULTILINE_FIND));
                MenuCommand menuItem = new MenuCommand(new EventHandler(MultilineFindCommandCallback), menuCommandID);
                mcs.AddCommand(menuItem);
            }
        }


        private void InitializeDte()
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            IVsShell shellService = default(IVsShell);

            this.mDte = this.GetService(typeof(Microsoft.VisualStudio.Shell.Interop.SDTE)) as EnvDTE80.DTE2;

            if (this.Dte == null)
            {
                // The IDE is not yet fully initialized
                shellService = this.GetService(typeof(SVsShell)) as IVsShell;
                this.dteInitializer = new DteInitializer(shellService, this.InitializeDte);
            }
            else
            {
                this.dteInitializer = null;
            }
        }


        /// <summary>
        /// This function is the callback used to execute a command when the a menu item is clicked.
        /// See the Initialize method to see how the menu item is associated to this function using
        /// the OleMenuCommandService service and the MenuCommand class.
        /// </summary>
        private void MultilineFindCommandCallback(object sender, EventArgs e)
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            //Dim uiShell As IVsUIShell = TryCast(GetService(GetType(SVsUIShell)), IVsUIShell)
            //Dim clsid As Guid = Guid.Empty
            //Dim result As Integer
            //Microsoft.VisualStudio.ErrorHandler.ThrowOnFailure(uiShell.ShowMessageBox(0, clsid, "Multiline Search and Replace", String.Format(CultureInfo.CurrentCulture, "Inside {0}.MenuItemCallback()", Me.GetType().Name), String.Empty, 0, OLEMSGBUTTON.OLEMSGBUTTON_OK, OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST, OLEMSGICON.OLEMSGICON_INFO, 0, result))
            ShowToolWindow(sender, e);
        }


        /// <summary>
        /// This function is called when the user clicks the menu item that shows the 
        /// tool window. See the Initialize method to see how the menu item is associated to 
        /// this function using the OleMenuCommandService service and the MenuCommand class.
        /// </summary>
        private void ShowToolWindow(object sender, EventArgs e)
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            // Get the instance number 0 of this tool window. This window is single instance so this instance
            // is actually the only one.
            // The last flag is set to true so that if the tool window does not exists it will be created.
            ToolWindowPane window = this.FindToolWindow(typeof(MyToolWindow), 0, true);
            if ((null == window) || (null == window.Frame))
            {
                throw new NotSupportedException(Resources.CanNotCreateWindow);
            }
            IVsWindowFrame windowFrame = (IVsWindowFrame)window.Frame;
            ((MyToolWindow)window).InitializeContent();
            Microsoft.VisualStudio.ErrorHandler.ThrowOnFailure(windowFrame.Show());
        }


    }
}
