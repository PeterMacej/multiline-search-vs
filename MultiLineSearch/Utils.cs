using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.Shell;
using System.Runtime.InteropServices;
using System.Reflection;


namespace Helixoft.MultiLineSearch
{


    /// <summary>
    /// Various functions.
    /// </summary>
    /// <remarks></remarks>
    internal class Utils
    {

        #region "Logging"

        public static void WriteToGeneralOutputPane(string message)
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            //System.Windows.Forms.MessageBox.Show(message)
            //Return

            IVsOutputWindow output = Package.GetGlobalService(typeof(SVsOutputWindow)) as IVsOutputWindow;
            if (output != null)
            {
                // can't write to the output window - just a pane
                // see References.Services HelperMethodsClass SDK Sample
                Guid generalPaneGuid = VSConstants.GUID_OutWindowGeneralPane;
                IVsOutputWindowPane pane = null;

                // fetch the pane wrapped in error handling:
                if (ErrorHandler.Failed(output.GetPane(generalPaneGuid, out pane)) || pane == null)
                {
                    // not created yet
                    output.CreatePane(generalPaneGuid, "General", 1, 0);
                    if (ErrorHandler.Failed(output.GetPane(generalPaneGuid, out pane)) || pane == null)
                    {
                        // ideally, throw an exception or trace/output...
                        return;
                    }
                }

                // wrap attempts to write in an error handler:
                message += Environment.NewLine;
                pane.Activate();
                if ((ErrorHandler.Failed(pane.OutputString(message))))
                {
                    // throw an exception/etc.
                    return;
                }
            }
        }

        #endregion


        #region "COM interfaces diagnostics"

        /// <summary>
        /// Get all implemented types in a COM object. Code based on work at
        /// http://fernandof.wordpress.com/2008/02/05/how-to-check-
        ///          the-type-of-a-com-object-system__comobject-with-visual-c-net/
        /// </summary>
        /// <param name="comObject">The object we want all types of.</param>
        /// <param name="assType">Any type in the COM assembly (the interface we expect that is implemented by the object).</param>
        /// <returns>All implemented classes/interfaces.</returns>
        private static List<Type> GetAllImplementedTypes(object comObject, Type assType)
        {
            //get all available assemblies
            List<Assembly> allAssemblies = default(List<Assembly>);
            allAssemblies = new List<Assembly>(AppDomain.CurrentDomain.GetAssemblies());

            // add assembly of the specified helper type (it is probably already loaded in AppDomain, but just for sure)
            Assembly interopAss = Assembly.GetAssembly(assType);
            if (!allAssemblies.Contains(interopAss))
            {
                allAssemblies.Add(interopAss);
            }

            // search in all assemblies
            List<Type> res = new List<Type>();
            foreach (Assembly ass in allAssemblies)
            {
                res.AddRange(GetAllImplementedTypes(comObject, ass));
            }

            return res;
        }


        /// <summary>
        /// Gets all types from an assembly that are implemented by a COM object.
        /// </summary>
        /// <param name="comObject">The object we want all types of.</param>
        /// <param name="interopAss">COM interop assembly to search.</param>
        /// <returns>All implemented classes/interfaces.</returns>
        private static List<Type> GetAllImplementedTypes(object comObject, Assembly interopAss)
        {
            List<Type> implTypes = new List<Type>();
            try
            {
                // get the com object and fetch its IUnknown
                IntPtr iunkwn = Marshal.GetIUnknownForObject(comObject);

                // enum all the types defined in the interop assembly
                Type[] allTypes = interopAss.GetTypes();

                // find all types it implements
                foreach (Type currType in allTypes)
                {
                    // com interop type must be an interface with valid iid
                    Guid iid = currType.GUID;
                    if (!currType.IsInterface || iid == Guid.Empty)
                    {
                        continue;
                    }

                    // query supportability of current interface on object
                    IntPtr ipointer = default(IntPtr);
                    Marshal.QueryInterface(iunkwn, ref iid, out ipointer);

                    if (ipointer != IntPtr.Zero)
                    {
                        implTypes.Add(currType);

                    }
                }
            }
            catch (ReflectionTypeLoadException ex)
            {
                foreach (Exception subEx in ex.LoaderExceptions)
                {
                    //WriteToGeneralOutputPane("   Error loading: " & interopAss.FullName)
                    //WriteToGeneralOutputPane("   EXCEPTION:" & ex.ToString)
                    //WriteToGeneralOutputPane("     SUBEXCEPTION:" & subEx.ToString)
                }
            }
            return implTypes;
        }


        /// <summary>
        /// Prints all implemented types in a COM object.
        /// </summary>
        /// <param name="comObject">The object we want all types of.</param>
        /// <param name="assType">Any type in the COM assembly (the interface we expect that is implemented by the object).</param>
        private void PrintAllTypes(object comObject, Type assType)
        {
            foreach (Type t in GetAllImplementedTypes(comObject, assType))
            {
                WriteToGeneralOutputPane("  " + t.FullName + " " + t.Assembly.FullName);
            }
        }

        #endregion


    }

}