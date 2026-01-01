using InsureYouAI.Context;
using Microsoft.AspNetCore.Mvc;

namespace InsureYouAI.ViewComponents.DefaultViewComponents;

public class _DefaultSliderComponentPartial : ViewComponent
{
    private readonly InsureContext _insureContext;
    public _DefaultSliderComponentPartial(InsureContext insureContext)
    {
        _insureContext = insureContext;
    }
    public IViewComponentResult Invoke()
    {
        var values = _insureContext.Sliders.ToList();
        return View(values);
    }
}