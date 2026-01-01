using InsureYouAI.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InsureYouAI.ViewComponents.BlogDetailViewComponents;

public class _BlogDetailContentComponentPartial : ViewComponent
{
    private readonly InsureContext _context;
    public _BlogDetailContentComponentPartial(InsureContext context)
    {
        _context = context;
    }
    public IViewComponentResult Invoke(Guid id)
    {
        var blog = _context.Articles.Where(i=> i.Id == id)
            .Include(b => b.AppUser)
            .Include(b => b.Category)
            .FirstOrDefault();
        ViewBag.CommentCount = _context.Comments.Count(c => c.ArticleId == id);
        return View(blog);
    }
}