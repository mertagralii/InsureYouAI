using InsureYouAI.Context;
using Microsoft.AspNetCore.Mvc;

namespace InsureYouAI.ViewComponents.DashboardViewComponents;

public class _DashboardWidgetsComponentPartial:ViewComponent
{
    private readonly InsureContext _dbContext;

    public _DashboardWidgetsComponentPartial(InsureContext dbContext)
    {
        _dbContext = dbContext;
    }
    public IViewComponentResult Invoke()
    {
        int n1,n2,n3,n4;
        int r1,r2,r3,r4;
        Random random = new Random();
        
        n1 = random.Next(0,10);
        r1 = random.Next(1,30);
        
        n2 = random.Next(0,10);
        r2 = random.Next(1,30);
        
        n3 = random.Next(0,10);
        r3 = random.Next(1,30);
        
        n4 = random.Next(0,10);
        r4 = random.Next(1,30);
        
        ViewBag.v1 = _dbContext.Articles.Count();
        ViewBag.v2 = _dbContext.Categories.Count();
        ViewBag.v3 = _dbContext.Comments.Count();
        ViewBag.v4 = _dbContext.Users.Count();
        ViewBag.r1 = n1+"."+r1;
        ViewBag.r2 = n2+"."+r2;
        ViewBag.r3 = n3+"."+r3;
        ViewBag.r4 = n4+"."+r4;
        return View();
    }
}