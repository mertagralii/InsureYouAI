using Microsoft.AspNetCore.Mvc;

namespace InsureYouAI.Controllers
{
    public class ErrorsController : Controller
    {
        [Route("/Errors/404")]
        public ActionResult Page404()
        {
            return View();
        }

    }
}
