﻿using System;
using System.DirectoryServices.Protocols;

namespace LinqToLdap.Mapping
{
    /// <summary>
    /// Interface for a mapped property
    /// </summary>
    public interface IPropertyMapping
    {
        /// <summary>
        /// The type of the property
        /// </summary>
        Type PropertyType { get; }

        /// <summary>
        /// Name of the property
        /// </summary>
        string PropertyName { get; }

        /// <summary>
        /// Name of the property in the directory
        /// </summary>
        string AttributeName { get; }

        /// <summary>
        /// Controls read only strategy of this property.
        /// </summary>
        ReadOnly ReadOnly { get; }

        /// <summary>
        /// Indicates if the property is for the distinguished name.
        /// </summary>
        bool IsDistinguishedName { get; }

        /// <summary>
        /// Gets the default value of the type for the property
        /// </summary>
        /// <returns></returns>
        object Default();

        /// <summary>
        /// Gets the value from the property on <paramref name="instance"/>.
        /// </summary>
        /// <param name="instance">Object to get the value from</param>
        /// <returns></returns>
        object GetValue(object instance);

        /// <summary>
        /// Sets the value on the property for <paramref name="instance"/>.
        /// </summary>
        /// <param name="instance">Object to set the value for</param>
        /// <param name="value">Value to set</param>
        void SetValue(object instance, object value);

        /// <summary>
        /// Converts the value from the directory into a type that is valid for the mapped property.
        /// </summary>
        /// <param name="value">The value from the directory</param>
        /// <param name="dn">Distinguished name for the attribute</param>
        /// <returns></returns>
        object FormatValueFromDirectory(DirectoryAttribute value, string dn);

        /// <summary>
        /// Converts <paramref name="value"/> to a form that is valid for an LDAP filter.
        /// </summary>
        /// <param name="value">The value to format</param>
        /// <returns></returns>
        string FormatValueToFilter(object value);

        /// <summary>
        /// Builds a <see cref="DirectoryAttributeModification"/> from the value of this property on <paramref name="instance"/>.
        /// </summary>
        ///<param name="instance">The object</param>
        ///<returns></returns>
        DirectoryAttributeModification GetDirectoryAttributeModification(object instance);

        /// <summary>
        /// Builds a <see cref="DirectoryAttribute"/> from the value of this property on <paramref name="instance"/>.
        /// </summary>
        ///<param name="instance">The object</param>
        ///<returns></returns>
        DirectoryAttribute GetDirectoryAttribute(object instance);

        /// <summary>
        /// Determines if <paramref name="value"/> is equal to the current value for the property.
        /// </summary>
        /// <param name="instance">The instance from which to get the current value.</param>
        /// <param name="value">The value to compare.</param>
        /// <param name="modification">The resulting modification if the values are not equal.</param>
        /// <returns></returns>
        bool IsEqual(object instance, object value, out DirectoryAttributeModification modification);
    }
}