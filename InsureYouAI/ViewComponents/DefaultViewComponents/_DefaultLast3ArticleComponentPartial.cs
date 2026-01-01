using InsureYouAI.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InsureYouAI.ViewComponents.DefaultViewComponents;

public class _DefaultLast3ArticleComponentPartial : ViewComponent
{
    private readonly InsureContext _context;
    public _DefaultLast3ArticleComponentPartial(InsureContext context)
    {
        _context = context;
    }
    public IViewComponentResult Invoke()
    {
        var values = _context.Articles.OrderByDescending(x=> x.Id)
            .Include(y=> y.Category)
            .Include(z=> z.AppUser)
            .Take(3).ToList();
        return View(values);
    }
    
}