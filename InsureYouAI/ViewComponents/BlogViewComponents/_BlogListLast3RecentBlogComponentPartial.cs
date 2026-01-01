using InsureYouAI.Context;
using Microsoft.AspNetCore.Mvc;

namespace InsureYouAI.ViewComponents.BlogViewComponents;

public class _BlogListLast3RecentBlogComponentPartial :ViewComponent
{
    private readonly InsureContext _context;

    public _BlogListLast3RecentBlogComponentPartial(InsureContext context)
    {
        _context = context;
    }
    public IViewComponentResult Invoke()
    {
        var recentBlogs = _context.Articles
            .OrderByDescending(b => b.CreatedDate)
            .Take(3)
            .ToList();
        return View(recentBlogs);
    }
}