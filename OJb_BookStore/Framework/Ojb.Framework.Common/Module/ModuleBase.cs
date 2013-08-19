// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ModuleBase.cs" company="">
//   
// </copyright>
// <summary>
//   Base implementation for <see cref="IModule" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



namespace Ojb.Framework.Common.Module
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    /// <summary>
    ///     Base implementation for <see cref="IModule" />.
    /// </summary>
    public abstract class ModuleBase : IModule
    {
        /// <summary>
        /// The export entries.
        /// </summary>
        private readonly List<ExportEntry> exportEntries = new List<ExportEntry>(100);

        #region Public Properties

        /// <summary>
        ///     Gets module name, default to assembly fullname.
        /// </summary>
        public virtual string Name
        {
            get { return GetType().Assembly.FullName; }
        }

        /// <summary>
        ///     Gets module title, default to assembly title.
        /// </summary>
        public virtual string Title
        {
            get
            {
                object[] attributes = GetType().Assembly.GetCustomAttributes(typeof (AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    var titleAttribute = (AssemblyTitleAttribute) attributes[0];
                    return titleAttribute.Title;
                }

                return string.Empty;
            }
        }

        /// <summary>
        ///     Gets module version, default to assembly version.
        /// </summary>
        public virtual Version Version
        {
            get { return GetType().Assembly.GetName().Version; }
        }

        /// <summary>
        ///     Gets all export entries.
        /// </summary>
        public IEnumerable<ExportEntry> Entries
        {
            get { return exportEntries; }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The compare to other Module.
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int CompareTo(object obj)
        {
            var other = obj as IModule;
            if (other == null)
            {
                return -1;
            }

            return string.CompareOrdinal(this.Name, other.Name);
        }

        #endregion

        /// <summary>
        /// Add an export entry.
        /// </summary>
        /// <param name="entry">
        /// An entry to add.
        /// </param>
        protected void Add(ExportEntry entry)
        {
            this.exportEntries.Add(entry);
        }
    }
}