using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;


namespace Helixoft.MultiLineSearch.Settings
{

    /// <summary>
    /// Stores a package settings. This is an in-memory alternative of
    /// vssettings XML file.
    /// </summary>
    /// <remarks></remarks>
    internal class PackageMemorySettingsStore
    {


        private readonly Dictionary<string, Setting> mSettings = new Dictionary<string, Setting>();
        public Dictionary<string, Setting> Settings
        {
            get { return mSettings; }
        }


        public void SetSetting(string name, object value)
        {
            if (name == null)
            {
                return;
            }

            Setting setting = GetOrCreateSetting(name);
            setting.Value = value;
            Settings[name] = setting;
        }


        public void SetSettingAttribute(string setName, string attrName, string attrValue)
        {
            if (setName == null)
            {
                return;
            }

            Setting setting = GetOrCreateSetting(setName);
            setting.SetAttribute(attrName, attrValue);
            Settings[setName] = setting;
        }


        /// <summary>
        /// Gets specified setting if it already exists or creates a new one with
        /// null value.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        private Setting GetOrCreateSetting(string name)
        {
            Setting res = null;
            if (Settings.ContainsKey(name))
            {
                res = Settings[name];
            }
            else
            {
                res = new Setting(name);
            }

            return res;
        }


        public override string ToString()
        {
            StringBuilder res = new StringBuilder();

            foreach (Setting s in this.Settings.Values)
            {
                res.AppendLine(s.ToString());
            }

            return res.ToString();
        }


        /// <summary>
        /// Represents one IDE setting.
        /// </summary>
        /// <remarks></remarks>

        internal class Setting
        {

            public Setting(string name)
            {
                mName = name;
            }



            private readonly string mName;
            /// <summary>
            /// Gets or sets the setting name.
            /// </summary>
            /// <value></value>
            /// <remarks></remarks>
            public string Name
            {
                get { return mName; }
            }



            private object mValue = null;
            /// <summary>
            /// Gets or sets the setting value.
            /// </summary>
            /// <value></value>
            /// <remarks></remarks>
            public object Value
            {
                get { return mValue; }
                set { mValue = value; }
            }



            private readonly Dictionary<string, string> mAttributes = new Dictionary<string, string>();
            public Dictionary<string, string> Attributes
            {
                get { return mAttributes; }
            }


            public void SetAttribute(string attrName, string attrValue)
            {
                Attributes[attrName] = attrValue;
            }


            public override string ToString()
            {
                return this.Name + " = " + Convert.ToString(this.Value);
            }

        }
    }

}
