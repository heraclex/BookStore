// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProviderModuleBase.cs" company="">
//   
// </copyright>
// <summary>
//   The provider module base.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System;
using System.Linq;
using Ojb.Framework.Common.Module;
using Ojb.Framework.EntityFrameworkProvider.Contract;
using AutoMapper;

namespace Ojb.Framework.EntityFrameworkProvider.Module
{
    /// <summary>
    /// The provider module base.
    /// </summary>
    public abstract class ProviderModuleBase : ModuleBase, IProviderModule
    {
        #region Static Fields

        /// <summary>
        ///     The cached <see cref="IRepositoryProvider" /> type for performance purpose.
        /// </summary>
        private static readonly Type ServiceType = typeof(IRepositoryProvider);

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ProviderModuleBase"/> class. 
        /// </summary>
        protected ProviderModuleBase()
        {
            // allow Null collections for automapper
            Mapper.Configuration.AllowNullCollections = true;

            this.ExportServices();
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Export all services classes.
        /// </summary>
        protected virtual void ExportServices()
        {
            Type[] types = GetType().Assembly.GetTypes();
            foreach (Type type in types)
            {
                // Register Profile for AutoMapper
                this.RegisterProfileForAutoMapper(type);

                if (type.IsAbstract || (!ServiceType.IsAssignableFrom(type)))
                {
                    continue;
                }

                string infName = "I" + type.Name;
                Type infType = type.GetInterfaces().FirstOrDefault(t => t.Name == infName);

                if (infType == null)
                {
                    continue;
                }

                this.Add(ExportEntry.Singleton(infType, type));
            }
        }

        /// <summary>
        /// The register profile for auto mapper.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        private void RegisterProfileForAutoMapper(Type type)
        {
            if (typeof (Profile).IsAssignableFrom(type))
            {
                Mapper.AddProfile((Profile) Activator.CreateInstance(type));
            }
        }

        #endregion
    }
}