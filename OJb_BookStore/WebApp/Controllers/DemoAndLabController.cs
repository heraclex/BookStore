using System.Collections.Generic;
using System.Web.Helpers;
using System.Web.Mvc;
using WebApp.Models;
using WebApp.ViewModel;

namespace WebApp.Controllers
{
    public class DemoAndLabController : Controller
    {
        //
        // GET: /DemoAndLab/

        public ActionResult Index()
        {
            return this.View(new DemoAndLabVM());
        }

        public ActionResult Table()
        {
            var model = new List<PersonModel>
                {
                    new PersonModel{Id = 1, Name = "One"},
                    new PersonModel{Id = 2, Name = "Two"},
                    new PersonModel{Id = 3, Name = "Three"},
                    new PersonModel{Id = 4, Name = "Four"},
                    new PersonModel{Id = 5, Name = "Five"},
                    new PersonModel{Id = 6, Name = "Six"},
                    new PersonModel{Id = 7, Name = "Sevent"},
                    new PersonModel{Id = 8, Name = "Eight"},
                };
            return this.View(model);
        }

        public JsonResult SubmitList(List<PersonModel> model)
        {
            var test = model;
            return new JsonResult
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new {mess = "123"}
                };
        }

        public ActionResult Popup()
        {
            return PartialView(new DemoAndLabVM());
        }

        public JsonResult Submit(DemoLabModel jsonObject)
        {
            return new JsonResult
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = new { mess = "123" }
            };
        }

    }
}
