using System.Web.Mvc;

namespace Goals.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            return View();
        }
    }
}