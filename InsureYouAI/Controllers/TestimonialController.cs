using System.Net.Http.Headers;
using System.Text.Json;
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
        
        [HttpGet]
        public async Task<IActionResult> CreateTestimonialWithAnhropicClaude()
        {
            string apiKey = "YOUR_ANTHROPIC_API_KEY";
            string prompt ="Bir sigorta şirketi için müşteri deneyimlerine dair yorum oluşturmanı istiyorum yani İngilizce karşılığı ile: testimonial. Bu alanda Türkçe olarak 6 tane yorum, 6 tane müşteri adı ve soyadı, Bu müşteriklerin unvanı olsun. Buna göre içeriği hazırla.";
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://api.anthropic.com/");
            client.DefaultRequestHeaders.Add("x-api-key", apiKey);
            client.DefaultRequestHeaders.Add("anthropic-version", "2023-06-01");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var requestBody = new
            {
                model = "claude-sonnet-4-5",
                max_tokens = 512,
                temperature = 0.7,
               messages = new[]
                {
                    new
                    {
                        role = "user",
                        content = prompt
                    }
                }
            };
            var jsonContent = new StringContent(JsonSerializer.Serialize(requestBody));
            var response = await client.PostAsync("v1/messages", jsonContent);
            if (!response.IsSuccessStatusCode)
            {
                ViewBag.testimonials = new List<string>
                {
                    $"Cloude Api'den cevap alınamadı. Hata:{response.StatusCode}"
                };
                return View();
            }
            var responseString = await response.Content.ReadAsStringAsync();
            using var doc = JsonDocument.Parse(responseString);
            var fullText = doc.RootElement
                .GetProperty("content")[0]
                .GetProperty("text")
                .GetString();
            var testimonial = fullText.Split('\n')
                .Where(x => !string.IsNullOrEmpty(x))
                .Select(x => x.TrimStart('1', '2', '3', '4', '5', '.', ' '))
                .ToList();
            ViewBag.testimonials = testimonial;
            return View();
        }
    }
}
