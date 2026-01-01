using InsureYouAI.Context;
using Microsoft.AspNetCore.Mvc;

namespace InsureYouAI.ViewComponents.DefaultViewComponents;

public class _DefaultTrailVideoComponentPartial : ViewComponent
{
    private readonly InsureContext _insureContext;
    public _DefaultTrailVideoComponentPartial(InsureContext insureContext)
    {
        _insureContext = insureContext;
    }
    public IViewComponentResult Invoke()
    {
        var trailVideos = _insureContext.TrailerVideos.ToList();
        return View(trailVideos);
    }
    
}