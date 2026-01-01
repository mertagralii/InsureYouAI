using InsureYouAI.Context;
using Microsoft.AspNetCore.Mvc;

namespace InsureYouAI.ViewComponents.BlogDetailViewComponents;

public class _BlogDetailNextAndPrevComponentPartial : ViewComponent
{
    private readonly InsureContext _context;

    public _BlogDetailNextAndPrevComponentPartial(InsureContext context)
    {
        _context = context;
    }
    public IViewComponentResult Invoke(Guid id)
    {
        var article = _context.Articles.FirstOrDefault(a => a.Id == id);
        
        if (article == null)
        {
            ViewBag.PrevArticleTitle = null;
            ViewBag.PrevArticleId = null;
            ViewBag.NextArticleTitle = null;
            ViewBag.NextArticleId = null;
            return View();
        }
        
        var prevArticle = _context.Articles
            .Where(a => a.CreatedDate < article.CreatedDate)
            .OrderByDescending(a => a.CreatedDate)
            .FirstOrDefault();
        
        var nextArticle = _context.Articles
            .Where(a => a.CreatedDate > article.CreatedDate)
            .OrderBy(a => a.CreatedDate)
            .FirstOrDefault();
        ViewBag.PrevArticleTitle = prevArticle?.Title;
        ViewBag.PrevArticleId = prevArticle?.Id;
        ViewBag.NextArticleTitle = nextArticle?.Title;
        ViewBag.NextArticleId = nextArticle?.Id;
        return View();
    }
}