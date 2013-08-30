using System.Configuration;
using Autofac;
using Autofac.Integration.Wcf;
using Ojb.DataModules.Security.Contract.Repository;
using Ojb.DataModules.Security.Provider.Context;
using Ojb.DataModules.Security.Provider.Repository;
using Ojb.DomainServices.Library.ServiceImp;
using Ojb.Framework.Common.Logger;

namespace Ojb.DomainServices.Library.Bootstrapper
{
    using Ojb.DataModules.Product.Contract.Repository;
    using Ojb.DataModules.Product.Provider.Context;
    using Ojb.DataModules.Product.Provider.Repository;

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
            builder.RegisterType<AccountService>();
            builder.RegisterType<ProductService>();
            builder.RegisterType<SecurityService>();
        }

        /// <summary>
        /// The register provider.
        /// </summary>
        private void RegisterProvider()
        {
            // registering all things needed for building data context

            var securityConnStr =
                ConfigurationManager.ConnectionStrings["SecurityConnection"].ConnectionString;

            var productConnStr =
                ConfigurationManager.ConnectionStrings["ProductConnection"].ConnectionString;

            this.builder.RegisterInstance(new SecurityDbContext(securityConnStr)).AsSelf();
            this.builder.RegisterInstance(new ProductDbContext(productConnStr)).AsSelf();

            this.builder.RegisterGeneric(typeof(SecurityRepository<>)).As(typeof(ISecurityRepository<>))
            .WithParameter((pi, c) => pi.ParameterType == typeof(System.Data.Entity.DbContext),
                           (pi, c) => c.Resolve<SecurityDbContext>());

            this.builder.RegisterGeneric(typeof(ProductRepository<>)).As(typeof(IProductRepository<>))
            .WithParameter((pi, c) => pi.ParameterType == typeof(System.Data.Entity.DbContext),
                           (pi, c) => c.Resolve<ProductDbContext>());
        }

        #endregion
    }

}
