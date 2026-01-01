using InsureYouAI.Context;
using Microsoft.AspNetCore.Mvc;

namespace InsureYouAI.ViewComponents.DefaultViewComponents;

public class _DefaultPricingPlanComponentPartial : ViewComponent
{
    private readonly InsureContext _db;

    public _DefaultPricingPlanComponentPartial(InsureContext db)
    {
        _db = db;
    }
    public IViewComponentResult Invoke()
    {
        var pricingPlan1 = _db.PricingPlans
            .Where(x => x.IsFeature == true)
            .FirstOrDefault();
        
        
        ViewBag.PricingPlan1Title = pricingPlan1.Title;
        ViewBag.PricingPlan1Price = pricingPlan1.Price;
        ViewBag.PricingPlan1Id = pricingPlan1.Id;
        
        
        var pricingPlan2 = _db.PricingPlans
            .Where(x => x.IsFeature == false)
            .OrderByDescending(x=>x.Id)
            .FirstOrDefault();
        
        
        ViewBag.PricingPlan2Title = pricingPlan2.Title;
        ViewBag.PricingPlan2Price = pricingPlan2.Price;
        ViewBag.PricingPlan2Id = pricingPlan2.Id;
        
        var pricingPlanItems = _db.PricinPlanItems
            .Where(x => x.PricingPlanId == pricingPlan1.Id || x.PricingPlanId == pricingPlan2.Id)
            .ToList();
        return View(pricingPlanItems);
    }
    
}