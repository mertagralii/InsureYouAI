using Microsoft.AspNetCore.Mvc;

namespace InsureYouAI.ViewComponents.AdminLayoutViewComponents;

public class _AdminLayoutBreadCrumpComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
    
}