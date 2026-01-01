using InsureYouAI.Context;
using Microsoft.AspNetCore.Mvc;

namespace InsureYouAI.ViewComponents.DefaultViewComponents;

public class _DefaultCounterComponentPartial: ViewComponent
{
    private readonly  InsureContext _dbContext;
    public _DefaultCounterComponentPartial(InsureContext dbContext)
    {
        _dbContext = dbContext;
    }
    public IViewComponentResult Invoke()
    {
        ViewBag.categoryCount = _dbContext.Categories.Count();
        ViewBag.serviceCount = _dbContext.Services.Count();
        ViewBag.userCount = _dbContext.Users.Count();
        ViewBag.articleCount = _dbContext.Articles.Count();
        return View();
    }
    
}