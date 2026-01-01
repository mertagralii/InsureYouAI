using InsureYouAI.Context;
using Microsoft.AspNetCore.Mvc;

namespace InsureYouAI.ViewComponents.DefaultViewComponents;

public class _DefaultAboutComponentPartial : ViewComponent
{
    private readonly InsureContext _dbContext;
    public _DefaultAboutComponentPartial(InsureContext dbContext)
    {
        _dbContext = dbContext;
    }
    public IViewComponentResult Invoke()
    {
        ViewBag.title = _dbContext.Abouts.Select(x=>x.Title).FirstOrDefault();
        ViewBag.description = _dbContext.Abouts.Select(x=>x.Description).FirstOrDefault();
        ViewBag.imageUrl = _dbContext.Abouts.Select(x=>x.ImageUrl).FirstOrDefault();
        var aboutItems = _dbContext.AboutItems.ToList();
        return View(aboutItems);
    }
    
}