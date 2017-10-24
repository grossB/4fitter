using _4fitter.Utilities;
using System.Web.Mvc;

namespace _4fitter.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Authorize(Roles = Definitions.ROLE_ADMIN)]
        public ActionResult AdminPanel()
        {
            return View();
        }
    }
}