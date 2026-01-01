using System.Text;
using System.Text.Json;
using InsureYouAI.Context;
using InsureYouAI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace InsureYouAI.Controllers
{
    public class AboutController : Controller
    {
        private readonly InsureContext _context;

        public AboutController(InsureContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult AboutList()
        {
            ViewBag.ControllerName = "Hakkımızda";
            ViewBag.PageName = "Hakkımızda Listesi";
            var Abouts = _context.Abouts.ToList();
            return View(Abouts);
        }

        [HttpGet]
        public IActionResult CreateAbout()
        {
            ViewBag.ControllerName = "Hakkımızda";
            ViewBag.PageName = "Yeni Hakkımızda Yazı Girişi";
            return View();
        }

        [HttpPost]
        public IActionResult CreateAbout(About about)
        {
            _context.Abouts.Add(about);
            _context.SaveChanges();
            return RedirectToAction("AboutList");
        }

        [HttpGet]
        public IActionResult UpdateAbout(Guid id)
        {
            ViewBag.ControllerName = "Hakkımızda";
            ViewBag.PageName = "Hakkımızda Yazı Güncelleme Sayfası";
            var About = _context.Abouts.Find(id);
            return View(About);
        }

        [HttpPost]
        public IActionResult UpdateAbout(About About)
        {
            _context.Abouts.Update(About);
            _context.SaveChanges();
            return RedirectToAction("AboutList");
        }

        [HttpGet]
        public IActionResult DeleteAbout(Guid id)
        {
            var About = _context.Abouts.Find(id);
            if (About != null)
            {
                _context.Abouts.Remove(About);
                _context.SaveChanges();
            }

            return RedirectToAction("AboutList");
        }
        [HttpGet]
        public async Task<IActionResult> CreateAboutWithGoogleGemini()
        {
            var apiKey = "YOUR_GOOGLE_API_KEY_HERE"; // Gemini API anahtarınızı buraya ekleyin
            var model = "gemini-2.5-pro";
            var url = $"https://generativelanguage.googleapis.com/v1/models/{model}:generateContent?key={apiKey}";
            var requestBody = new
            {
                contents = new[]
                {
                    new
                    {
                        parts=new[]
                        {
                            new
                            {
                                text="Kurumsal bir sigorta firması için etkileyici, güven verici ve profesyonel bir 'Hakkımızda' yazısı oluştur."
                            }
                        }
                    }
                }
            };

            var content = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");

            using var httpClient = new HttpClient();
            var response = await httpClient.PostAsync(url, content);
            var responseJson = await response.Content.ReadAsStringAsync();
            

            using var jsonDoc = JsonDocument.Parse(responseJson);
            var aboutText = jsonDoc.RootElement
                .GetProperty("candidates")[0]
                .GetProperty("content")
                .GetProperty("parts")[0]
                .GetProperty("text")
                .GetString();

            ViewBag.value = aboutText;

            return View();
        }
        

    }
}
