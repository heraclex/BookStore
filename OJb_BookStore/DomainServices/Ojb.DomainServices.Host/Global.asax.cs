using System;
using System.Web;
using Ojb.DomainServices.Library.Bootstrapper;

namespace Ojb.DomainServices.Host
{
    using Ojb.Framework.Common.Logger;

    /// <summary>
    /// Global application class for the multitenant WCF example application.
    /// </summary>
    /// <remarks>
    /// <para>
    /// It is easiest to see this application in action from the MVC example.
    /// The MVC example makes use of this service and displays the information,
    /// illustrating a complete multitenant system in action.
    /// </para>
    /// </remarks>
    public class Global : HttpApplication
    {
        /// <summary>
        /// Handles the global application startup event.
        /// </summary>
        protected void Application_Start(object sender, EventArgs e)
        {
            LogManager.Initialize();

            // https://code.google.com/p/autofac/source/browse/Examples/MultitenantExample.WcfService/Global.asax.cs
            var bootStart = new AutofacConfiguration();
            bootStart.DoStart();
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}