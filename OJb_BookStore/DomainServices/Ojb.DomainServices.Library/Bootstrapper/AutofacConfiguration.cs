using System.Configuration;
using System.Data.Entity;
using Autofac;
using Autofac.Integration.Wcf;
using Ojb.DataModules.Security.Contract.Repository;
using Ojb.DataModules.Security.Provider.Context;
using Ojb.DataModules.Security.Provider.Repository;
using Ojb.DomainServices.Contract.Services;
using Ojb.DomainServices.Library.ServiceImp;
using Ojb.Framework.Common.Logger;

namespace Ojb.DomainServices.Library.Bootstrapper
{
    /// <summary>
    /// The autofac configuration.
    /// </summary>
    public class AutofacConfiguration
    {
        #region Static Fields

        /// <summary>
        ///     The log4net logger instance.
        /// </summary>
        private readonly ILogger logger = LogManager.GetLogger(typeof (AutofacConfiguration));

        #endregion

        #region Fields

        /// <summary>
        ///     AUTOFAC builder.
        /// </summary>
        private readonly ContainerBuilder builder = new ContainerBuilder();

        /// <summary>
        ///     The <see cref="IComponentContext" /> from which services
        ///     should be located.
        /// </summary>
        private IContainer container;

        #endregion

        /// <summary>
        ///     Configure IOC container
        /// </summary>
        public void DoStart()
        {
            logger.Info("/******** Servicves starts *********/");
            RegisterComponents();
            ConfigureIoc();
            logger.Info("/******** Servicves started sucessfully *********/");
        }

        #region Register For Autofac

        /// <summary>
        ///     Configure IOC container
        /// </summary>
        private void ConfigureIoc()
        {
            this.container = this.builder.Build();
            AutofacHostFactory.Container = container;
        }

        // / Should be refactored
        /// <summary>
        /// The register components.
        /// </summary>
        private void RegisterComponents()
        {
            // Register individual components
            this.RegisterServicesImp();
            this.RegisterProvider();
        }

        /// <summary>
        /// The register services imp.
        /// </summary>
        private void RegisterServicesImp()
        {
            // registering all things needed for building data context
            this.builder.RegisterType<AccountService>().As<IAccountService>();
        }

        private void RegisterProvider()
        {
            // registering all things needed for building data context
            // builder.RegisterInstance(new SecurityDbContext("SecurityConnection")).AsSelf();

            string connStr =
                ConfigurationManager.ConnectionStrings["SecurityConnection"].ConnectionString;

            this.builder.RegisterInstance(new SecurityDbContext(connStr)).AsSelf();

            this.builder.RegisterGeneric(typeof (SecurityRepository<>))
                .As(typeof (ISecurityRepository<>))
                .WithParameter((pi, c) => pi.ParameterType == typeof (DbContext),
                               (pi, c) => c.Resolve<SecurityDbContext>());
        }

        #endregion
    }
}
