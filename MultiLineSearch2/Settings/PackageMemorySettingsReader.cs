using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio;


namespace Helixoft.MultiLineSearch.Settings
{

    /// <summary>
    /// Reads the package settings from memory.
    /// </summary>
    /// <remarks>The settings are stored in <see cref="PackageMemorySettingsStore"/>.</remarks>
    internal class PackageMemorySettingsReader : IVsSettingsReader
    {



        private readonly PackageMemorySettingsStore mSettingsStore = new PackageMemorySettingsStore();
        public PackageMemorySettingsStore SettingsStore
        {
            get { return mSettingsStore; }
        }


        public PackageMemorySettingsReader(PackageMemorySettingsStore settingsStore)
        {
            if (settingsStore == null)
            {
                throw new ArgumentNullException("settingsStore");
            }
            this.mSettingsStore = settingsStore;
        }


        public int ReadCategoryVersion(out int pnMajor, out int pnMinor, out int pnBuild, out int pnRevision)
        {
            pnMajor = 0;
            pnMinor = 0;
            pnBuild = 0;
            pnRevision = 0;
            return VSConstants.S_OK;
        }


        public int ReadFileVersion(out int pnMajor, out int pnMinor, out int pnBuild, out int pnRevision)
        {
            pnMajor = 0;
            pnMinor = 0;
            pnBuild = 0;
            pnRevision = 0;
            return VSConstants.S_OK;
        }


        public int ReadSettingAttribute(string pszSettingName, string pszAttributeName, out string pbstrSettingValue)
        {
            pbstrSettingValue = null;
            try
            {
                if (SettingsStore.Settings.ContainsKey(pszSettingName))
                {
                    PackageMemorySettingsStore.Setting setting = SettingsStore.Settings[pszSettingName];
                    if (setting.Attributes.ContainsKey(pszAttributeName))
                    {
                        pbstrSettingValue = setting.Attributes[pszAttributeName];
                        return VSConstants.S_OK;
                    }
                }
            }
            catch (Exception ex)
            {
            }

            return VSConstants.S_FALSE;
        }


        public int ReadSettingBoolean(string pszSettingName, out int pfSettingValue)
        {
            pfSettingValue = 0;
            try
            {
                if (SettingsStore.Settings.ContainsKey(pszSettingName))
                {
                    PackageMemorySettingsStore.Setting setting = SettingsStore.Settings[pszSettingName];
                    pfSettingValue = (int)setting.Value;
                    return VSConstants.S_OK;
                }
            }
            catch (Exception ex)
            {
            }

            return VSConstants.S_FALSE;
        }


        public int ReadSettingBytes(string pszSettingName, ref byte pSettingValue, out int plDataLength, int lDataMax)
        {
            // since I couldn't test this method, just do nothing
            plDataLength = 0;
            return VSConstants.S_FALSE;

            try
            {
                if (SettingsStore.Settings.ContainsKey(pszSettingName))
                {
                    PackageMemorySettingsStore.Setting setting = SettingsStore.Settings[pszSettingName];
                    byte[] bytes = (byte[])setting.Value;
                    if (bytes.Length <= lDataMax)
                    {
                        IntPtr bufferPtr = default(IntPtr);
                        // byte and byte() are blittable so the pointer to the first array element is a pointer to the array itself
                        GCHandle pinnedBufferBytes = GCHandle.Alloc(pSettingValue, GCHandleType.Pinned);
                        bufferPtr = pinnedBufferBytes.AddrOfPinnedObject();

                        Marshal.Copy(bytes, 0, bufferPtr, bytes.Length);
                        plDataLength = bytes.Length;

                        // probably not needed because the byte array was allocated by the caller
                        pinnedBufferBytes.Free();

                        return VSConstants.S_OK;
                    }
                }
            }
            catch (Exception ex)
            {
            }

            return VSConstants.S_FALSE;
        }


        public int ReadSettingLong(string pszSettingName, out int plSettingValue)
        {
            plSettingValue = 0;
            try
            {
                if (SettingsStore.Settings.ContainsKey(pszSettingName))
                {
                    PackageMemorySettingsStore.Setting setting = SettingsStore.Settings[pszSettingName];
                    plSettingValue = (int)setting.Value;
                    return VSConstants.S_OK;
                }
            }
            catch (Exception ex)
            {
            }

            return VSConstants.S_FALSE;
        }


        public int ReadSettingString(string pszSettingName, out string pbstrSettingValue)
        {
            pbstrSettingValue = "";
            try
            {
                if (SettingsStore.Settings.ContainsKey(pszSettingName))
                {
                    PackageMemorySettingsStore.Setting setting = SettingsStore.Settings[pszSettingName];
                    pbstrSettingValue = (string)setting.Value;
                    return VSConstants.S_OK;
                }
            }
            catch (Exception ex)
            {
            }

            return VSConstants.S_FALSE;
        }


        public int ReadSettingXml(string pszSettingName, out object ppIXMLDOMNode)
        {
            ppIXMLDOMNode = null;
            return VSConstants.S_FALSE;
        }

        public int ReadSettingXmlAsString(string pszSettingName, out string pbstrXML)
        {
            pbstrXML = null;
            return VSConstants.S_FALSE;
        }

        public int ReportError(string pszError, uint dwErrorType)
        {
            return VSConstants.S_OK ;
        }

    }

}
