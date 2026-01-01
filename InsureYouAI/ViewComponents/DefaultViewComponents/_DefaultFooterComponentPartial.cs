using InsureYouAI.Context;
using Microsoft.AspNetCore.Mvc;

namespace InsureYouAI.ViewComponents.DefaultViewComponents;

public class _DefaultFooterComponentPartial : ViewComponent
{
    private readonly InsureContext _insureContext;
    public _DefaultFooterComponentPartial(InsureContext insureContext)
    {
        _insureContext = insureContext;
    }
    public IViewComponentResult Invoke()
    {
        ViewBag.description = _insureContext.Contacts.Select(x=>x.Description).FirstOrDefault();
        ViewBag.phone = _insureContext.Contacts.Select(x=>x.PhoneNumber).FirstOrDefault();
        ViewBag.email = _insureContext.Contacts.Select(x=>x.Email).FirstOrDefault();
        ViewBag.address = _insureContext.Contacts.Select(x=>x.Address).FirstOrDefault();
        return View();
    }
    
}