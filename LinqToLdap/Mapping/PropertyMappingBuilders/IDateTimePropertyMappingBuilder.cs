﻿using System;

namespace LinqToLdap.Mapping.PropertyMappingBuilders
{
    /// <summary>
    /// Interface for a DateTimePropertyMappingBuilder.
    /// </summary>
    /// <typeparam name="T">The type of the owner of the property</typeparam>
    /// <typeparam name="TProperty">The type of the property</typeparam>
    public interface IDateTimePropertyMappingBuilder<T, TProperty> : IDirectoryValueConversionMapper<IDateTimePropertyMappingBuilder<T, TProperty>, TProperty>,
        IDirectoryToConversion<IDateTimePropertyMappingBuilder<T, TProperty>, TProperty>,
        IInstanceValueConversionMapper<IDateTimePropertyMappingBuilder<T, TProperty>, TProperty>,
        IInstanceToConversion<IDateTimePropertyMappingBuilder<T, TProperty>> where T : class
    {
        /// <summary>
        /// Specify an attribute name for a mapped property.
        /// </summary>
        /// <param name="attributeName">Attribute name in the directory</param>
        /// <returns></returns>
        IDateTimePropertyMappingBuilder<T, TProperty> Named(string attributeName);

        /// <summary>
        /// Specify the format of the DateTime in the directory.  Use null if the DateTime is stored in file time.
        /// Default format is yyyyMMddHHmmss.0Z.  If the property is not a <see cref="DateTime"/> then this setting will be ignored.
        /// </summary>
        /// <example>
        /// <para>Common formats</para>
        /// <para>
        /// Active Directory: yyyyMMddHHmmss.0Z
        /// </para>
        /// <para>
        /// eDirectory: yyyyMMddHHmmssZ or yyyyMMddHHmmss00Z
        /// </para>
        /// </example>
        /// <param name="format">The format of the DateTime in the directory.</param>
        /// <returns></returns>
        IDateTimePropertyMappingBuilder<T, TProperty> DateTimeFormat(string format);

        /// <summary>
        /// Indicates if the property should always be read only.
        /// </summary>
        /// <returns></returns>
        IDateTimePropertyMappingBuilder<T, TProperty> ReadOnly();

        /// <summary>
        /// Configures the read only behavior.
        /// </summary>
        /// <returns></returns>
        IDateTimePropertyMappingBuilder<T, TProperty> ReadOnly(ReadOnly readOnly);
    }
}