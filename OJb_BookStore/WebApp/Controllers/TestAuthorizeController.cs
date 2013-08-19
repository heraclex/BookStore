using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    using Ojb.Framework.WebBase.Authorize;

    public class TestAuthorizeController : OjbControllerBase
    {
        //
        // GET: /TestAuthorize/

        public ActionResult Index()
        {
            return View();
        }

    }
}
