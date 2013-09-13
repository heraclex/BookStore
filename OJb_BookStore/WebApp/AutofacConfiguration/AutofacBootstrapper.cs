// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AutofacBootstrapper.cs" company="OjbSolution">
//   
// </copyright>
// <summary>
//   Defines the AutofacBootstrapper type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WebApp.AutofacConfiguration
{
    using System;
    using System.Web.Mvc;

    using Ojb.Framework.Common.Logger;

    using Autofac;
    using Autofac.Builder;
    using Autofac.Integration.Wcf;
    using Autofac.Extras.DynamicProxy2;

    using Castle.DynamicProxy;

    using WebApp.CastleConfiguration;

    using Ojb.DomainServices.Contract.Services;
    using System.ServiceModel;
    using System.Configuration;
    using System.ServiceModel.Channels;

    using WebApp.Security;
    using WebApp.ServiceProvider;

    /// <summary>
    /// Autofac Bootstrapper Configuration
    /// </summary>
    public class AutofacBootstrapper
    {
        #region Static Fields

        /// <summary>
        /// Interface Controller type.
        /// </summary>
        private static readonly Type IControllerType = typeof(IController);

        /// <summary>
        ///     The log4net logger instance.
        /// </summary>
        private readonly ILogger logger = LogManager.GetLogger(typeof(AutofacBootstrapper));

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
            this.logger.Info("/******** Application starts *********/");
            this.RegisterComponents();
            this.ConfigureIoc();
            this.logger.Info("/******** Application started sucessfully *********/");
        }

        #region Register For Autofac

        /// <summary>
        ///     Configure IOC container
        /// </summary>
        private void ConfigureIoc()
        {
            this.container = this.builder.Build();
            DependencyResolver.SetResolver(new AutofacDependenceResolver(this.container, DependencyResolver.Current));
        }

        // Should be refactored
        private void RegisterComponents()
        {
            // Register individual components
            // this.RegisterServices();
            this.RegisterServiceIoC();

            this.RegisterInterception();

            // Register all controller class
            this.RegisterViewModelAndControllers();

            this.RegisterSecurityService();
        }

        /// <summary>
        /// Export all controller classes.
        /// </summary>
        private void RegisterViewModelAndControllers()
        {
            this.logger.Info("*** Star register View Model and Controller ***");

            Type[] types = this.GetType().Assembly.GetTypes();
            foreach (Type type in types)
            {
                // Register Controllers
                if ((!type.IsAbstract) && IControllerType.IsAssignableFrom(type))
                {
                    this.logger.InfoFormat("--- Register {0}", type.Name);

                    this.builder.RegisterType(type).As<IController>()
                        .Named(type.Name.Replace("Controller", string.Empty).ToLowerInvariant(), typeof(IController));
                }
                // Register ViewModel
                else if (!(type.IsAbstract && type.IsInterface)
                    && (type.Name.EndsWith("VMBuilder") || type.Name.EndsWith("VMPersistence")))
                {
                    this.logger.InfoFormat("--- Register {0}", type.Name);

                    this.builder.RegisterType(type).As(type.GetInterface("I" + type.Name));
                }
            }

            this.builder.RegisterType(typeof(AutofacControllerFactory)).As<IControllerFactory>().SingleInstance();

            this.logger.Info("*** Register View Model and Controller was completed ***");
        }

        /// <summary>
        /// Register Services with interceptor
        /// </summary>
        private void RegisterServices()
        {
            IRegistrationBuilder<object, ConcreteReflectionActivatorData, SingleRegistrationStyle> regBuilder =
                    this.builder.RegisterType(typeof(ServiceProviderProxy)).As<IServiceProviderProxy>();

            regBuilder.SingleInstance();

            //regBuilder.InterceptWith(
            //        new Tuple<IInterceptor, IProxyGenerationHook>(
            //            new CastleTxInterceptor(),            
            //            new AutofacMethodNameProxyGenerationHook(
            //                "Add", "Update", "Delete", "Set", "Insert", "Save", "Exec")),
            //        new Tuple<IInterceptor, IProxyGenerationHook>(new CastleLogCallInterceptor(), null));

            regBuilder.InterceptWith(
                   new Tuple<IInterceptor, IProxyGenerationHook>(new CastleLogCallInterceptor(),
                       new AutofacMethodNameProxyGenerationHook(
                           "Add", "Update", "Delete", "Set", "Insert", "Save", "Exec")));
        }

        private void RegisterInterception()
        {
            // Register interceptor implement, tell to container know with class will handle intercep
            this.builder.RegisterType<CastleLogCallInterceptor>();
        }

        private void RegisterServiceIoC()
        {
            // https://code.google.com/p/autofac/wiki/WcfIntegration#Clients

            //***** Simple way and doesn't want to include interceptor *********/


            //builder.Register(c => new System.ServiceModel.ChannelFactory<IAccountService>(
            //    new CustomBinding("customOverHttps"),
            //    new EndpointAddress(ConfigurationManager.AppSettings["endpoint"])))
            //  .SingleInstance();

            //builder.Register(c => c.Resolve<ChannelFactory<IAccountService>>().CreateChannel())
            //  .UseWcfSafeRelease();

            //******************************************************************/

            //this.builder.Register(c => new ChannelFactory<IAccountService>(
            //   new CustomBinding("customOverHttps"),
            //   new EndpointAddress(ConfigurationManager.AppSettings["endpoint"])))
            // .SingleInstance();
            
            //this.builder
            //  .Register(c => c.Resolve<ChannelFactory<IAccountService>>().CreateChannel())
            //  .InterceptTransparentProxy(typeof(IAccountService))
            //  .InterceptedBy(typeof(CastleLogCallInterceptor))
            //  .UseWcfSafeRelease();

            this.builder.Register(c => new ChannelFactory<ISecurityService>(
               new CustomBinding("customOverHttps"),
               new EndpointAddress(ConfigurationManager.AppSettings["SecurityEndpoint"])))
             .SingleInstance();

            this.builder
              .Register(c => c.Resolve<ChannelFactory<ISecurityService>>().CreateChannel())
              .InterceptTransparentProxy(typeof(ISecurityService))
              .InterceptedBy(typeof(CastleLogCallInterceptor))
              .UseWcfSafeRelease();

            this.builder.Register(c => new ChannelFactory<IProductService>(
               new CustomBinding("customOverHttps"),
               new EndpointAddress(ConfigurationManager.AppSettings["ProductEndpoint"])))
             .SingleInstance();

            this.builder
              .Register(c => c.Resolve<ChannelFactory<IProductService>>().CreateChannel())
              .InterceptTransparentProxy(typeof(IProductService))
              .InterceptedBy(typeof(CastleLogCallInterceptor))
              .UseWcfSafeRelease();
        }
        
        private void RegisterSecurityService()
        {
            this.builder.RegisterType(typeof(OjbMemberShipProvider)).As<IOjbMemberShipProvider>();
            this.builder.RegisterType(typeof(FormsAuthenticationService)).As<IFormsAuthenticationService>();
        }

        #endregion
    }
}