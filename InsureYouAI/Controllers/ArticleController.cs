using InsureYouAI.Context;
using InsureYouAI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace InsureYouAI.Controllers
{
    public class ArticleController : Controller
    {
        private readonly InsureContext _context;

        public ArticleController(InsureContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult ArticleList()
        {
            var Articles = _context.Articles.ToList();
            return View(Articles);
        }

        [HttpGet]
        public IActionResult CreateArticle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateArticle(Article Article)
        {
            Article.CreatedDate = DateTime.Now;
            _context.Articles.Add(Article);
            _context.SaveChanges();
            return RedirectToAction("ArticleList");
        }

        [HttpGet]
        public IActionResult UpdateArticle(Guid id)
        {
            var Article = _context.Articles.Find(id);
            return View(Article);
        }

        [HttpPost]
        public IActionResult UpdateArticle(Article Article)
        {
            _context.Articles.Update(Article);
            _context.SaveChanges();
            return RedirectToAction("ArticleList");
        }

        [HttpGet]
        public IActionResult DeleteArticle(Guid id)
        {
            var Article = _context.Articles.Find(id);
            if (Article != null)
            {
                _context.Articles.Remove(Article);
                _context.SaveChanges();
            }
            return RedirectToAction("ArticleList");
        }

    }
}
