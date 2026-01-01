using InsureYouAI.Context;
using InsureYouAI.Models;
using Microsoft.AspNetCore.Mvc;

namespace InsureYouAI.ViewComponents.BlogViewComponents;

public class _BlogListCategoryComponentPartial : ViewComponent
{
    private readonly InsureContext _context;
    public _BlogListCategoryComponentPartial(InsureContext context)
    {
        _context = context;
    }
    public IViewComponentResult Invoke()
    {
        var categories = _context.Categories
            .Select(c => new CategoryArticleCountViewModel
            {
                CategoryId = c.Id,
                CategoryName = c.Name,
                ArticleCount = c.Articles.Count()
            })
            .ToList();
        return View(categories);
    }
}