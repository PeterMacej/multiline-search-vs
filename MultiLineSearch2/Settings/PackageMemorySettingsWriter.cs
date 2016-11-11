
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio;


namespace Helixoft.MultiLineSearch.Settings
{

    /// <summary>
    /// Writes the package settings into memory.
    /// </summary>
    /// <remarks>The settings are stored in <see cref="PackageMemorySettingsStore"/>.</remarks>
    internal class PackageMemorySettingsWriter : IVsSettingsWriter
    {



        private readonly PackageMemorySettingsStore mSettingsStore = new PackageMemorySettingsStore();
        public PackageMemorySettingsStore SettingsStore
        {
            get { return mSettingsStore; }
        }


        public int ReportError(string pszError, uint dwErrorType)
        {
            return VSConstants.S_OK;
        }

        public int WriteCategoryVersion(int nMajor, int nMinor, int nBuild, int nRevision)
        {
            return VSConstants.S_OK;
        }


        public int WriteSettingAttribute(string pszSettingName, string pszAttributeName, string pszSettingValue)
        {
            SettingsStore.SetSettingAttribute(pszSettingName, pszAttributeName, pszSettingValue);
            return VSConstants.S_OK;
        }


        public int WriteSettingBoolean(string pszSettingName, int fSettingValue)
        {
            SettingsStore.SetSetting(pszSettingName, fSettingValue);
            return VSConstants.S_OK;
        }


        public int WriteSettingBytes(string pszSettingName, byte[] pSettingValue, int lDataLength)
        {
            byte[] newValue = null;
            if (pSettingValue.Length > lDataLength)
            {
                newValue = new byte[lDataLength + 1];
                Array.Copy(pSettingValue, 0, newValue, 0, lDataLength);
            }
            else
            {
                newValue = pSettingValue;
            }
            SettingsStore.SetSetting(pszSettingName, newValue);

            return VSConstants.S_OK;
        }


        public int WriteSettingLong(string pszSettingName, int lSettingValue)
        {
            SettingsStore.SetSetting(pszSettingName, lSettingValue);
            return VSConstants.S_OK;
        }


        public int WriteSettingString(string pszSettingName, string pszSettingValue)
        {
            SettingsStore.SetSetting(pszSettingName, pszSettingValue);
            return VSConstants.S_OK;
        }


        public int WriteSettingXml(object pIXMLDOMNode)
        {
            return VSConstants.S_OK;
        }

        public int WriteSettingXmlFromString(string szXML)
        {
            return VSConstants.S_OK;
        }


    }

}
