using System.Net.Http.Headers;
using System.Text.Json;
using InsureYouAI.Context;
using InsureYouAI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace InsureYouAI.Controllers
{
    public class ServiceController : Controller
    {
        private readonly InsureContext _context;

        public ServiceController(InsureContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult ServiceList()
        {
            var Service = _context.Services.ToList();
            return View(Service);
        }

        [HttpGet]
        public IActionResult CreateService()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateService(Service service)
        {
            _context.Services.Add(service);
            _context.SaveChanges();
            return RedirectToAction("ServiceList");
        }

        [HttpGet]
        public IActionResult UpdateService(Guid id)
        {
            var service = _context.Services.Find(id);
            return View(service);
        }

        [HttpPost]
        public IActionResult UpdateService(Service service)
        {
            _context.Services.Update(service);
            _context.SaveChanges();
            return RedirectToAction("ServiceList");
        }

        [HttpGet]
        public IActionResult DeleteService(Guid id)
        {
            var service = _context.Services.Find(id);
            if (service != null)
            {
                _context.Services.Remove(service);
                _context.SaveChanges();
            }
            return RedirectToAction("ServiceList");
        }

        [HttpGet]
        public async Task<IActionResult> CreateServiceWithAnhropicClaude()
        {
            string apiKey =
                "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";
            string prompt ="Bir sigorta şirketi için hizmetler bölümü hazırlamanı istiyorum. Burada 5 farklı hizmet olmalı.Bana maksimum 100 karakterden oluşan cümleler ile 5 tane hizmet içeriği yazar mısın?";
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
                ViewBag.services = new List<string>
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
            var services = fullText.Split('\n')
                .Where(x => !string.IsNullOrEmpty(x))
                .Select(x => x.TrimStart('1', '2', '3', '4', '5', '.', ' ','#'))
                .ToList();
            ViewBag.services = services;
            return View();
        }

    }
}
