﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell.Interop;
using System.Reflection;
using EnvDTE;


namespace Helixoft.MultiLineSearch.SearchReplace
{

    /// <summary>
    /// Provides interaction with the new quick find UI introduced in VS 17.0. 
    /// </summary>
    /// <remarks>
    /// <para>
    /// Starting with VS 17.0, the new quick find UI ignores the search strings stored in <see cref="EnvDTE.Find.FindWhat"/>
    /// and <see cref="EnvDTE.Find.ReplaceWith"/>. This helper class is needed to populate the new UI with specified values.
    /// </para>
    /// <para>
    /// This class uses undocumented Microsoft.VisualStudio.Editor.Implementation.NewFind.UI.NewFindDialog
    /// from Microsoft.VisualStudio.Editor.Implementation.dll via reflection.
    /// It's a hack, needs to be replaced with some more official implementation in the future.
    /// </para>
    /// </remarks>
    internal class NewVsQuickFind : ReflectionHelper
    {

        /// <summary>
        /// The GUID of the VS EditorPackage. This package handles also the find functionality.
        /// </summary>
        private static readonly Guid guidEditorPkg = new Guid("e269b994-ef71-4ce0-8bcd-581c217372e8");


        /// <summary>
        /// Populates the new quick find UI introduced in VS 17.0+ with the required
        /// Find and Replace values and checks the Use regex checkbox.
        /// </summary>
        /// <param name="findText"></param>
        /// <param name="replaceText"></param>
        /// <param name="useRegex">The value of "Use regular expressions" checkbox.</param>
        public static void PopulateQuickFindValues(string findText, string replaceText, bool useRegex)
        {
            try
            {
                ThreadHelper.ThrowIfNotOnUIThread();

                // get the EditorPackage from which we get the other objects
                var editorPkg = GetPackageByGuid(guidEditorPkg);    // it's of type Microsoft.VisualStudio.Editor.Implementation.EditorPackage
                if (editorPkg == null)
                {
                    return;
                }

                // get FindAdornmentManager
                object FindAdorment = GetPropertyValue(editorPkg, "FindAdorment");    // it's of type Microsoft.VisualStudio.Editor.Implementation.Find.FindAdornmentManager
                if (FindAdorment == null)
                {
                    return;
                }

                // get FindUI which a quick find control
                object FindUI = GetPropertyValue(FindAdorment, "FindUI");    // it's of type Microsoft.VisualStudio.Editor.Implementation.Find.FindUI
                if (FindUI == null)
                {
                    return;
                }

                // set the Find text
                string propertyName = "Microsoft.VisualStudio.Editor.IUpdateFindAndReplace.FindWhat"; // the explicit interface implementation
                SetPropertyValue(FindUI, propertyName, findText);

                // set the Replace text
                propertyName = "Microsoft.VisualStudio.Editor.IUpdateFindAndReplace.ReplaceWith"; // the explicit interface implementation
                SetPropertyValue(FindUI, propertyName, replaceText);

                // Set Regex checkbox
                propertyName = "Microsoft.VisualStudio.Editor.IUpdateFindAndReplace.UseRegex"; // the explicit interface implementation
                SetPropertyValue(FindUI, propertyName, useRegex);
            }
            catch (Exception)
            {
            }
        }


        private static IVsPackage GetPackageByGuid(Guid pkgGuid)
        {
            IVsPackage package = null;

            ThreadHelper.ThrowIfNotOnUIThread();
            var shellService = Package.GetGlobalService(typeof(SVsShell)) as IVsShell;
            if (shellService != null)
            {
                IEnumPackages packagesEnumerator;
                int res = shellService.GetPackageEnum(out packagesEnumerator);
                if (res == VSConstants.S_OK)
                {
                    IVsPackage[] rgelt = new IVsPackage[1];
                    UInt32 pceltFetched;
                    while (packagesEnumerator.Next(1, rgelt, out pceltFetched) == VSConstants.S_OK)
                    {
                        var pkg = rgelt[0];
                        if (pkg != null)
                        {
                            if (pkg.GetType().GUID == pkgGuid)
                            {
                                return pkg;
                            }
                        }
                    }
                }

            }

            return package;
        }


    }
}
