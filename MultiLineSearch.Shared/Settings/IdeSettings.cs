using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.Shell;


namespace Helixoft.MultiLineSearch.Settings
{

    /// <summary>
    /// This class provides read/write access to any VS IDE setting that is available in 
    /// .vssettings file.
    /// </summary>
    /// <remarks>
    /// Normally, we can get/set IDE properties only with DTE.Properties. But only a limited
    /// set of all settings are available in DTE.
    /// We can access all settings in registry. But it has one main drawback. They are written only 
    /// when VS closes and they are read only at VS start. So we cannot get the current value during 
    /// VS execution.
    /// The third way is to export/import settings with 'Tools.ImportandExportSettings' command. This allows for
    /// getting and setting the current values. But we cannot programmatically export just a part fo settings
    /// (as it is possible with import/export wizard). So there will be always all settings exported, resulting in possibly
    /// several MB XMl file. Moreover, some extensions (MZ-Tools) hook into 'Tools.ImportandExportSettings' command
    /// and show some dialogs. This is intolerable.
    /// So as the solution, it seems to be the best to use import/export functionality of packages. But use it directly
    /// on particular packages and don't use files at all.
    /// 
    /// This class allows for fine import/export of settings based on package GUID and settings category GUID, as
    /// saved in .vssettings file. The settings are stored in memory.
    /// </remarks>
    internal class IdeSettings
    {


        private readonly IVsShell shellService;

        public IdeSettings()
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            shellService = Package.GetGlobalService(typeof(SVsShell)) as IVsShell;
            if (shellService == null)
            {
                throw new Exception("The IVsShell interface (or SVsShell service) couldn't be retrieved.");
            }
        }


        /// <summary>
        /// Gets settings for specified package and for specified settings category.
        /// </summary>
        /// <param name="packageGuid">The package GUID as specified in .vssettings file in 
        /// the 'Package' attribute of the 'Category' element.</param>
        /// <param name="categoryGuid">The category GUID as specified in .vssettings file in 
        /// the 'Category' attribute of the 'Category' element.</param>
        /// <returns>All settings from the category. Nothing if a problem occurs.</returns>
        /// <remarks></remarks>
        public PackageMemorySettingsStore GetSettings(string packageGuid, string categoryGuid)
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            try
            {
                Guid pkgGuid = new Guid(packageGuid);
                IVsPackage pkg = null;
                shellService.IsPackageLoaded(pkgGuid, out pkg);
                if (pkg != null)
                {
                    // VS 2005-2012
                    IVsUserSettings pkgSettings = pkg as IVsUserSettings;
                    // VS 2013
                    IVsUserSettings2 pkgSettings2 = pkg as IVsUserSettings2;

                    if (pkgSettings != null)
                    {
                        PackageMemorySettingsWriter setWriter = new PackageMemorySettingsWriter();
                        pkgSettings.ExportSettings(categoryGuid, setWriter);
                        return setWriter.SettingsStore;
                    }
                    else if (pkgSettings2 != null)
                    {
                        PackageMemorySettingsWriter setWriter = new PackageMemorySettingsWriter();
                        Guid catGuid = new Guid(categoryGuid);
                        pkgSettings2.ExportSettings(catGuid, setWriter, null);
                        return setWriter.SettingsStore;
                    }
                }
            }
            catch (Exception)
            {
            }

            return null;
        }


        /// <summary>
        /// Sets settings for specified package and for specified settings category.
        /// </summary>
        /// <param name="packageGuid">The package GUID as specified in .vssettings file in 
        /// the 'Package' attribute of the 'Category' element.</param>
        /// <param name="categoryGuid">The category GUID as specified in .vssettings file in 
        /// the 'Category' attribute of the 'Category' element.</param>
        /// <param name="settings">All settings from the category.</param>
        /// <remarks></remarks>
        public void SetSettings(string packageGuid, string categoryGuid, PackageMemorySettingsStore settings)
        {
            if (settings == null)
            {
                return;
            }

            ThreadHelper.ThrowIfNotOnUIThread();

            try
            {
                Guid pkgGuid = new Guid(packageGuid);
                IVsPackage pkg = null;
                shellService.IsPackageLoaded(pkgGuid, out pkg);
                if (pkg != null)
                {
                    // VS 2005-2012
                    IVsUserSettings pkgSettings = pkg as IVsUserSettings;
                    // VS 2013
                    IVsUserSettings2 pkgSettings2 = pkg as IVsUserSettings2;

                    if (pkgSettings != null)
                    {
                        PackageMemorySettingsReader setReader = new PackageMemorySettingsReader(settings);
                        int restartRequired = 0;
                        pkgSettings.ImportSettings(categoryGuid, setReader, Convert.ToUInt32(__UserSettingsFlags.USF_None), restartRequired);
                    }
                    else if (pkgSettings2 != null)
                    {
                        PackageMemorySettingsReader setReader = new PackageMemorySettingsReader(settings);
                        Guid catGuid = new Guid(categoryGuid);
#if VS2019
                        pkgSettings2.ImportSettings(catGuid, setReader, Convert.ToUInt32(__UserSettingsFlags.USF_None), null);
#else
                        pkgSettings2.ImportSettings(catGuid, setReader, __UserSettingsFlags.USF_None, null);
#endif

                    }
                }
            }
            catch (Exception)
            {
            }
        }


    }

}
