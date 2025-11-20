using InsureYouAI.Context;
using InsureYouAI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace InsureYouAI.Controllers
{
    public class AboutItemController : Controller
    {
        private readonly InsureContext _context;

        public AboutItemController(InsureContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult AboutItemList()
        {
            var AboutItems = _context.AboutItems.ToList();
            return View(AboutItems);
        }

        [HttpGet]
        public IActionResult CreateAboutItem()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateAboutItem(AboutItem aboutItem)
        {
            _context.AboutItems.Add(aboutItem);
            _context.SaveChanges();
            return RedirectToAction("AboutItemList");
        }

        [HttpGet]
        public IActionResult UpdateAboutItem(Guid id)
        {
            var AboutItem = _context.AboutItems.Find(id);
            return View(AboutItem);
        }

        [HttpPost]
        public IActionResult UpdateAboutItem(AboutItem AboutItem)
        {
            _context.AboutItems.Update(AboutItem);
            _context.SaveChanges();
            return RedirectToAction("AboutItemList");
        }

        [HttpGet]
        public IActionResult DeleteAboutItem(Guid id)
        {
            var AboutItem = _context.AboutItems.Find(id);
            if (AboutItem != null)
            {
                _context.AboutItems.Remove(AboutItem);
                _context.SaveChanges();
            }
            return RedirectToAction("AboutItemList");
        }

    }
}
