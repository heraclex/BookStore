namespace WebApp
{
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using WebApp.AutofacConfiguration;
    using Ojb.Framework.Common.Logger;

    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            this.ConfigLogger();
            this.BootStrapperStart();
            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
        }

        /// <summary>
        /// The boot strapper start.
        /// </summary>
        private void BootStrapperStart()
        {
            // var bootstrapper = new UnityBootstrapper();
            var bootstrapper = new AutofacBootstrapper();
            bootstrapper.DoStart();
        }

        /// <summary>
        /// The config log 4 net.
        /// </summary>
        private void ConfigLogger()
        {
            LogManager.Initialize();
        }
    }
}