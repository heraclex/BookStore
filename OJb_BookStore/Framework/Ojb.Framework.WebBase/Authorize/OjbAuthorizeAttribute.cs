namespace Ojb.Framework.WebBase.Authorize
{
    using System;
    using System.Web.Mvc;

    public class OjbAuthorizeAttribute : AuthorizeAttribute 
    {
        #region Public Methods and Operators

        /// <summary>
        /// Method will be called when request need to be authorized
        /// </summary>
        /// <param name="filterContext">
        /// The filter context. 
        /// </param>
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!(filterContext.Controller is OjbControllerBase))
            {
                throw new Exception("All controller have to inherit from CxControllerBase");
            }

            // var controllerBase = filterContext.Controller as OjbControllerBase;
            // var isDisabled = controllerBase.IsDisabled();
            if (!filterContext.HttpContext.Request.IsAuthenticated)//|| isDisabled)
            {
                var url = UrlHelper.GenerateContentUrl("~/Login/Index", filterContext.HttpContext);
                if (filterContext.HttpContext.Request.Cookies["isLogout"] != null && filterContext.HttpContext.Request.Cookies["isLogout"].Value == "true")
                {
                    // logout is called
                    url = UrlHelper.GenerateContentUrl("~/Login/Index", filterContext.HttpContext);
                }
                var urlRedirect = string.Format(
                    "<script>window.onbeforeunload = null; window.location.href='{0}'</script>",
                    url);
                filterContext.Result = new ContentResult { Content = urlRedirect };
            }
        }

        #endregion
    }
}
