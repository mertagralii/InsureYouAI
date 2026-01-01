using InsureYouAI.Context;
using Microsoft.AspNetCore.Mvc;

namespace InsureYouAI.ViewComponents.BlogDetailViewComponents;

public class _BlogDetailAboutAuthorComponentPartial : ViewComponent
{
    private readonly InsureContext _context;
    public _BlogDetailAboutAuthorComponentPartial(InsureContext context)
    {
        _context = context;
    }
    public IViewComponentResult Invoke(Guid id)
    {
        var appUserId = _context.Articles.Where(a => a.Id == id).Select(a => a.AppUserId).FirstOrDefault();
        var appUser = _context.Users.Where(a => a.Id == appUserId).FirstOrDefault();
        return View(appUser);
    }
}