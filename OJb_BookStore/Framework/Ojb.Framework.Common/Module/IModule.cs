namespace Ojb.Framework.Common.Module
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Define a code module that provide a name, title and all export entries for import/use later.
    /// </summary>
    public interface IModule : IComparable
    {
        #region Public Properties

        /// <summary>
        /// Gets the module name.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the module title.
        /// </summary>
        string Title { get; }

        /// <summary>
        /// Gets the module version.
        /// </summary>
        Version Version { get; }

        /// <summary>
        /// Gets all export entries.
        /// </summary>
        IEnumerable<ExportEntry> Entries { get; }

        #endregion
    }
}