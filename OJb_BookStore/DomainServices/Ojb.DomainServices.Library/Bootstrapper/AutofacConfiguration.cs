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
using Ojb.Framework.Domain.Interfaces;
using Ojb.Framework.EntityFrameworkProvider.Repository;

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
            this.logger.Info("/******** Servicves starts *********/");
            this.RegisterComponents();
            this.ConfigureIoc();

            this.logger.Info("/******** Servicves started sucessfully *********/");
        }

        #region Register For Autofac

        /// <summary>
        ///     Configure IOC container
        /// </summary>
        private void ConfigureIoc()
        {
            AutofacHostFactory.Container = this.builder.Build();
        }

        /// <summary>
        /// The register components.
        /// </summary>
        private void RegisterComponents()
        {
            // TODO: Should be refactored
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
            // this.builder.RegisterType<AccountService>().As<IAccountService>();
            builder.RegisterType<AccountService>();
        }

        /// <summary>
        /// The register provider.
        /// </summary>
        private void RegisterProvider()
        {
            // registering all things needed for building data context
            // builder.RegisterInstance(new SecurityDbContext("SecurityConnection")).AsSelf();

            string connStr =
                ConfigurationManager.ConnectionStrings["SecurityConnection"].ConnectionString;

            this.builder.RegisterInstance(new SecurityDbContext(connStr)).AsSelf();

            //this.builder.RegisterGeneric(typeof(SecurityRepository<>))
            //    .As(typeof(ISecurityRepository<>))
            //    .WithParameter((pi, c) => pi.ParameterType == typeof(System.Data.Entity.DbContext),
            //                   (pi, c) => c.Resolve<SecurityDbContext>());


            //this.builder.RegisterGeneric(typeof(RepositoryBase<>)).As(typeof(IRepositoryBase<>))
            //.WithParameter((pi, c) => pi.ParameterType == typeof(System.Data.Entity.DbContext),
            //               (pi, c) => c.Resolve<SecurityDbContext>());

            this.builder.RegisterGeneric(typeof(SecurityRepository<>)).As(typeof(ISecurityRepository<>))
            .WithParameter((pi, c) => pi.ParameterType == typeof(System.Data.Entity.DbContext),
                           (pi, c) => c.Resolve<SecurityDbContext>());
        }

        #endregion
    }

}
