using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Globalization;
using System.Xml.Serialization;
using System.IO;


namespace Helixoft.MultiLineSearch.Settings
{

    /// <summary>
    /// Represents one saved search and replace setting.
    /// </summary>
    /// <remarks></remarks>
    [XmlRoot("SavedSearch")]
    [TypeConverter(typeof(SavedSearchTypeConverter))]
    public class SavedSearch
    {

        /// <summary>
        /// Gets or sets a name of the saved search.
        /// </summary>
        /// <value></value>
        public string Name { get; set; }


        /// <summary>
        /// Gets or sets the search phrase.
        /// </summary>
        /// <value></value>
        public string Search { get; set; }


        /// <summary>
        /// Gets or sets the replace text.
        /// </summary>
        /// <value></value>
        public string ReplaceWith { get; set; }


        /// <summary>
        /// Gets or sets a value indicating whether to ignore leading whitespaces.
        /// </summary>
        /// <value><see langword="true"/> if leading whitespaces are ignored; otherwise, <see langword="false"/>.</value>
        /// <remarks></remarks>
        public bool IgnoreLeadingWs { get; set; }


        /// <summary>
        /// Gets or sets a value indicating whether to ignore trailing whitespaces.
        /// </summary>
        /// <value><see langword="true"/> if trailing whitespaces are ignored; otherwise, <see langword="false"/>.</value>
        /// <remarks></remarks>
        public bool IgnoreTrailingWs { get; set; }


        /// <summary>
        /// Gets or sets a value indicating whether to ignore all whitespaces.
        /// </summary>
        /// <value><see langword="true"/> if all whitespaces are ignored; otherwise, <see langword="false"/>.</value>
        /// <remarks></remarks>
        public bool IgnoreAllWs { get; set; }


    }


    /// <summary>
    /// Represents a list of saved search and replace settings.
    /// </summary>
    /// <remarks></remarks>
    [XmlRoot("SavedSearchList")]
    [TypeConverter(typeof(SavedSearchListTypeConverter))]
    public class SavedSearchList : List<SavedSearch>
    {
        //[XmlArray("Searches"), XmlArrayItem(typeof(SavedSearch), ElementName = "SavedSearch")]
        //public List<SavedSearch> Searches { get; set; }
    }


    public class SavedSearchTypeConverter : TypeConverter
    {

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
        }


        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return destinationType == typeof(string) || base.CanConvertTo(context, destinationType);
        }


        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            var valueStr = value as string;
            if (valueStr != null)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(SavedSearch));
                StringReader reader = new StringReader(valueStr);
                SavedSearch res = (SavedSearch)serializer.Deserialize(reader);
                return res;
            } else
            {
                return base.ConvertFrom(context, culture, value);
            }
        }


        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            var valueTyped = value as SavedSearch;
            if (destinationType == typeof(string) && valueTyped != null)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(SavedSearch));
                TextWriter writer = new StringWriter();
                serializer.Serialize(writer, valueTyped);
                writer.Close();
                return writer.ToString();
            } else
            {
                return base.ConvertTo(context, culture, value, destinationType);
            }
        }
    }


    public class SavedSearchListTypeConverter : TypeConverter
    {

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
        }


        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return destinationType == typeof(string) || base.CanConvertTo(context, destinationType);
        }


        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            var valueStr = value as string;
            if (valueStr != null)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(SavedSearchList));
                StringReader reader = new StringReader(valueStr);
                SavedSearchList res = (SavedSearchList)serializer.Deserialize(reader);
                return res;
            }
            else
            {
                return base.ConvertFrom(context, culture, value);
            }
        }


        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            var valueTyped = value as SavedSearchList;
            if (destinationType == typeof(string) && valueTyped != null)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(SavedSearchList));
                TextWriter writer = new StringWriter();
                serializer.Serialize(writer, valueTyped);
                writer.Close();
                return writer.ToString();
            }
            else
            {
                return base.ConvertTo(context, culture, value, destinationType);
            }
        }
    }



}
