using InsureYouAI.Context;
using InsureYouAI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace InsureYouAI.Controllers
{
    public class TestimonialController : Controller
    {
        private readonly InsureContext _context;

        public TestimonialController(InsureContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult TestimonialList()
        {
            var testimonials = _context.Testimonials.ToList();
            return View(testimonials);
        }

        [HttpGet]
        public IActionResult CreateTestimonial()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateTestimonial(Testimonial testimonial)
        {
            _context.Testimonials.Add(testimonial);
            _context.SaveChanges();
            return RedirectToAction("TestimonialList");
        }

        [HttpGet]
        public IActionResult UpdateTestimonial(Guid id)
        {
            var testimonial = _context.Testimonials.Find(id);
            return View(testimonial);
        }

        [HttpPost]
        public IActionResult UpdateTestimonial(Testimonial testimonial)
        {
            _context.Testimonials.Update(testimonial);
            _context.SaveChanges();
            return RedirectToAction("TestimonialList");
        }

        [HttpGet]
        public IActionResult DeleteTestimonial(Guid id)
        {
            var testimonial = _context.Testimonials.Find(id);
            if (testimonial != null)
            {
                _context.Testimonials.Remove(testimonial);
                _context.SaveChanges();
            }
            return RedirectToAction("TestimonialList");
        }
    }
}
