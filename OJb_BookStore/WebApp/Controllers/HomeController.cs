﻿namespace WebApp.Controllers
{
    using System.Web.Mvc;
    using Ojb.Framework.WebBase.Authorize;

    using WebApp.ViewModel.Builder;

    /// <summary>
    /// </summary>
    public class HomeController : Controller
    {
        private readonly IHomeVMBuilder homeVMBuilder = null;

        public HomeController(IHomeVMBuilder homeVMBuilder)
        {
            this.homeVMBuilder = homeVMBuilder;
        }

        public ActionResult Index()
        {
            var a = this.homeVMBuilder.BuidlerHomeView();

            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}