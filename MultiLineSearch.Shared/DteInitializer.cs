using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.Shell;


namespace Helixoft.MultiLineSearch
{


    /// <summary>
    /// Initializes the DTE object.
    /// </summary>
    /// <remarks></remarks>
    internal class DteInitializer : IVsShellPropertyEvents
    {
        private readonly IVsShell shellService;
        private uint cookie;

        private readonly Action callback;

        internal DteInitializer(IVsShell shellService, Action callback)
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            int hr = 0;

            this.shellService = shellService;
            this.callback = callback;

            // Set an event handler to detect when the IDE is fully initialized
            hr = this.shellService.AdviseShellPropertyChanges(this, out this.cookie);

            Microsoft.VisualStudio.ErrorHandler.ThrowOnFailure(hr);
        }


        private int IVsShellPropertyEvents_OnShellPropertyChange(int propid, object var)
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            int hr = 0;
            bool isZombie = false;

            if (propid == Convert.ToInt32(__VSSPROPID.VSSPROPID_Zombie))
            {
                isZombie = Convert.ToBoolean(var);

                if (!isZombie)
                {
                    // Release the event handler to detect when the IDE is fully initialized
                    hr = this.shellService.UnadviseShellPropertyChanges(this.cookie);
                    Microsoft.VisualStudio.ErrorHandler.ThrowOnFailure(hr);
                    this.cookie = 0;
                    this.callback();
                }
            }
            return VSConstants.S_OK;
        }
        int IVsShellPropertyEvents.OnShellPropertyChange(int propid, object var)
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            return IVsShellPropertyEvents_OnShellPropertyChange(propid, var);
        }
    }

}