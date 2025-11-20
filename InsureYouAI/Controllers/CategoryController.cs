using InsureYouAI.Context;
using InsureYouAI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace InsureYouAI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly InsureContext _context;

        public CategoryController(InsureContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult CategoryList()
        {
            var categories = _context.Categories.ToList();
            return View(categories);
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction("CategoryList");
        }

        [HttpGet]
        public IActionResult UpdateCategory(Guid id)
        {
            var category = _context.Categories.Find(id);
            return View(category);
        }

        [HttpPost]
        public IActionResult UpdateCategory(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
            return RedirectToAction("CategoryList");
        }

        [HttpGet]
        public IActionResult DeleteCategory(Guid id)
        {
            var category = _context.Categories.Find(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
            return RedirectToAction("CategoryList");
        }
    }
}
