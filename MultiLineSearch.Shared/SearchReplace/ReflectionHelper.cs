using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace Helixoft.MultiLineSearch.SearchReplace
{

    /// <summary>
    /// Provides an access to .NET instances via Reflection.
    /// </summary>
    internal class ReflectionHelper
    {

        /// <summary>
        /// Uses reflection to get the field value from an object.
        /// </summary>
        ///
        /// <param name="instance">The instance object.</param>
        /// <param name="fieldName">The field's name which is to be fetched.</param>
        ///
        /// <returns>The field value from the object.</returns>
        public static object GetFieldValue(object instance, string fieldName)
        {
            const BindingFlags bindFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static;
            var field = instance.GetType().GetField(fieldName, bindFlags);
            return field == null ? null : field.GetValue(instance);
        }


        /// <summary>
        /// Uses reflection to get the property value from an object.
        /// </summary>
        ///
        /// <param name="instance">The instance object.</param>
        /// <param name="propertyName">The property's name which is to be fetched.</param>
        ///
        /// <returns>The property value from the object.</returns>
        public static object GetPropertyValue(object instance, string propertyName)
        {
            const BindingFlags bindFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static;
            var property = instance.GetType().GetProperty(propertyName, bindFlags);
            return property == null ? null : property.GetValue(instance);
        }


        /// <summary>
        /// Uses reflection to set the property value from an object.
        /// </summary>
        ///
        /// <param name="instance">The instance object.</param>
        /// <param name="propertyName">The property's name which is to be set.</param>
        /// <param name="propertyValue">The value to set.</param>
        public static void SetPropertyValue(object instance, string propertyName, object propertyValue)
        {
            const BindingFlags bindFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static;
            var property = instance.GetType().GetProperty(propertyName, bindFlags);
            property.SetValue(instance, propertyValue);
        }


        /// <summary>
        /// Uses reflection to execute a method of an object.
        /// </summary>
        ///
        /// <param name="instance">The instance object.</param>
        /// <param name="methodName">The method's name which is to be executed.</param>
        ///
        /// <returns>The return value of the method.</returns>
        public static object ExecuteMethod(object instance, string methodName, object[] parameters)
        {
            const BindingFlags bindFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static;
            var method = instance.GetType().GetMethod(methodName, bindFlags);
            return method == null ? null : method.Invoke(instance, parameters);
        }


        /// <summary>
        /// Uses reflection to execute a method of an object.
        /// </summary>
        ///
        /// <param name="instance">The instance object.</param>
        /// <param name="methodName">The method's name which is to be executed.</param>
        ///
        /// <returns>The return value of the method.</returns>
        public static object ExecuteMethod(object instance, string methodName)
        {
            return ExecuteMethod(instance, methodName, null);
        }


        /// <summary>
        /// Uses reflection to execute a method of an object.
        /// </summary>
        ///
        /// <param name="instance">The instance object.</param>
        /// <param name="methodName">The method's name which is to be executed.</param>
        ///
        /// <returns>The return value of the method.</returns>
        public static object ExecuteMethod(object instance, string methodName, object param1)
        {
            return ExecuteMethod(instance, methodName, new object[] { param1 });
        }

    }
}
