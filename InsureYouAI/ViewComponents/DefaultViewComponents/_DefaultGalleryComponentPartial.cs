using InsureYouAI.Context;
using Microsoft.AspNetCore.Mvc;

namespace InsureYouAI.ViewComponents.DefaultViewComponents;

public class _DefaultGalleryComponentPartial: ViewComponent
{
    private readonly InsureContext _insureContext;
    public _DefaultGalleryComponentPartial(InsureContext insureContext)
    {
        _insureContext = insureContext;
    }
    public IViewComponentResult Invoke()
    {
        var values = _insureContext.Galleries.ToList();
        return View(values);
    }
}