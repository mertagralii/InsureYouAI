using InsureYouAI.Context;
using InsureYouAI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace InsureYouAI.Controllers
{
    public class AboutController : Controller
    {
        private readonly InsureContext _context;

        public AboutController(InsureContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult AboutList()
        {
            var Abouts = _context.Abouts.ToList();
            return View(Abouts);
        }

        [HttpGet]
        public IActionResult CreateAbout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateAbout(About about)
        {
            _context.Abouts.Add(about);
            _context.SaveChanges();
            return RedirectToAction("AboutList");
        }

        [HttpGet]
        public IActionResult UpdateAbout(Guid id)
        {
            var About = _context.Abouts.Find(id);
            return View(About);
        }

        [HttpPost]
        public IActionResult UpdateAbout(About About)
        {
            _context.Abouts.Update(About);
            _context.SaveChanges();
            return RedirectToAction("AboutList");
        }

        [HttpGet]
        public IActionResult DeleteAbout(Guid id)
        {
            var About = _context.Abouts.Find(id);
            if (About != null)
            {
                _context.Abouts.Remove(About);
                _context.SaveChanges();
            }

            return RedirectToAction("AboutList");
        }

    }
}
