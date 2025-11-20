using InsureYouAI.Context;
using InsureYouAI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace InsureYouAI.Controllers
{
    public class PricingPlanController : Controller
    {
        private readonly InsureContext _context;

        public PricingPlanController(InsureContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult PricingPlanList()
        {
            var PricingPlanList = _context.PricingPlans.ToList();
            return View(PricingPlanList);
        }

        [HttpGet]
        public IActionResult CreatePricingPlan()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreatePricingPlan(PricingPlan PricingPlan)
        {
            _context.PricingPlans.Add(PricingPlan);
            _context.SaveChanges();
            return RedirectToAction("PricingPlanList");
        }

        [HttpGet]
        public IActionResult UpdatePricingPlan(Guid id)
        {
            var PricingPlan = _context.PricingPlans.Find(id);
            return View(PricingPlan);
        }

        [HttpPost]
        public IActionResult UpdatePricingPlan(PricingPlan PricingPlan)
        {
            _context.PricingPlans.Update(PricingPlan);
            _context.SaveChanges();
            return RedirectToAction("PricingPlanList");
        }

        [HttpGet]
        public IActionResult DeletePricingPlan(Guid id)
        {
            var PricingPlan = _context.PricingPlans.Find(id);
            if (PricingPlan != null)
            {
                _context.PricingPlans.Remove(PricingPlan);
                _context.SaveChanges();
            }
            return RedirectToAction("PricingPlanList");
        }

    }
}
