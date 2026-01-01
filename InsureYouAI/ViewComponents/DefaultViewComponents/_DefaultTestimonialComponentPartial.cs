using InsureYouAI.Context;
using Microsoft.AspNetCore.Mvc;

namespace InsureYouAI.ViewComponents.DefaultViewComponents;

public class _DefaultTestimonialComponentPartial : ViewComponent
{
    private readonly InsureContext _insureContext;

    public _DefaultTestimonialComponentPartial(InsureContext insureContext)
    {
        _insureContext = insureContext;
    }
    public IViewComponentResult Invoke()
    {
        var testimonials = _insureContext.Testimonials.ToList();
        return View(testimonials);
    }
    
}