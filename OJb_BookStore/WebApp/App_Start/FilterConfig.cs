using System.Web;
using System.Web.Mvc;

namespace WebApp
{
    using Ojb.Framework.WebBase.CustomFilter.Logging;

    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            filters.Add(new OjbMvcLoggingFilter());
        }
    }
}