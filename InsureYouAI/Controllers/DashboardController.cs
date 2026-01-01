using Microsoft.AspNetCore.Mvc;

namespace InsureYouAI.Controllers
{
    public class DashboardController : Controller
    {
       
        public ActionResult Index()
        {
            ViewBag.ControllerName = "Dashboard";
            ViewBag.PageName = "Hızlı Bakış Tabloları & Grafikler & istatistikler";
            return View();
        }

    }
}
