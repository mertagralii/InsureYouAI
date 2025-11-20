using InsureYouAI.Context;
using InsureYouAI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace InsureYouAI.Controllers
{
    public class SliderController : Controller
    {
        private readonly InsureContext _context;

        public SliderController(InsureContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult SliderList()
        {
            var Sliders = _context.Sliders.ToList();
            return View(Sliders);
        }

        [HttpGet]
        public IActionResult CreateSlider()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateSlider(Slider Slider)
        {
            _context.Sliders.Add(Slider);
            _context.SaveChanges();
            return RedirectToAction("SliderList");
        }

        [HttpGet]
        public IActionResult UpdateSlider(Guid id)
        {
            var Slider = _context.Sliders.Find(id);
            return View(Slider);
        }

        [HttpPost]
        public IActionResult UpdateSlider(Slider Slider)
        {
            _context.Sliders.Update(Slider);
            _context.SaveChanges();
            return RedirectToAction("SliderList");
        }

        [HttpGet]
        public IActionResult DeleteSlider(Guid id)
        {
            var Slider = _context.Sliders.Find(id);
            if (Slider != null)
            {
                _context.Sliders.Remove(Slider);
                _context.SaveChanges();
            }

            return RedirectToAction("SliderList");
        }

    }
}
