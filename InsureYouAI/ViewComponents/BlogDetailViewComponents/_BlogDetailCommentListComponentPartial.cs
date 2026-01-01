using InsureYouAI.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InsureYouAI.ViewComponents.BlogDetailViewComponents;

public class _BlogDetailCommentListComponentPartial : ViewComponent
{
    private readonly InsureContext _context;

    public _BlogDetailCommentListComponentPartial( InsureContext context)
    {
        _context = context;
    }
    
    public IViewComponentResult Invoke(Guid blogId)
    {
        var values = _context.Comments
            .Where(x => x.ArticleId == blogId && x.CommentStatus == "Yorum Onaylandı")
            .Include(z=>z.AppUser)
            .ToList();
        return View(values);
    }
}