using System.Web.Helpers;
using System.Web.Mvc;
using WebApp.ViewModel;

namespace WebApp.Controllers
{
    public class DemoAndLabController : Controller
    {
        //
        // GET: /DemoAndLab/

        public ActionResult Index()
        {
            return View(new DemoAndLabVM());
        }

        public JsonResult SubmitList(DemoAndLabVM viewModel)
        {
            var test = viewModel;
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
    }
}
