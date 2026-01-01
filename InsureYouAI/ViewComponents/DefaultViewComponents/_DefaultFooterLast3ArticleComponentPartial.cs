using InsureYouAI.Context;
using Microsoft.AspNetCore.Mvc;

namespace InsureYouAI.ViewComponents.DefaultViewComponents;

public class _DefaultFooterLast3ArticleComponentPartial : ViewComponent
{
    private readonly InsureContext _insureContext;
    public _DefaultFooterLast3ArticleComponentPartial(InsureContext insureContext)
    {
        _insureContext = insureContext;
    }
    public IViewComponentResult Invoke()
    {
        var value = _insureContext.Articles.OrderByDescending(x=>x.Id).Skip(3).Take(2).ToList();
        return View(value);
    }
    
}