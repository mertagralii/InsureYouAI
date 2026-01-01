using System.Text;
using System.Text.Json;
using InsureYouAI.Context;
using InsureYouAI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace InsureYouAI.Controllers
{
    public class AboutItemController : Controller
    {
        private readonly InsureContext _context;

        public AboutItemController(InsureContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult AboutItemList()
        {
            ViewBag.ControllerName = "Hakkımızda Öğeleri";
            ViewBag.PageName = "Mevcut Hakkımızda Öğeleri";
            var AboutItems = _context.AboutItems.ToList();
            return View(AboutItems);
        }

        [HttpGet]
        public IActionResult CreateAboutItem()
        {
            ViewBag.ControllerName = "Hakkımızda Öğeleri";
            ViewBag.PageName = "Yeni Hakkımızda Öğe Girişi";
            return View();
        }

        [HttpPost]
        public IActionResult CreateAboutItem(AboutItem aboutItem)
        {
            _context.AboutItems.Add(aboutItem);
            _context.SaveChanges();
            return RedirectToAction("AboutItemList");
        }

        [HttpGet]
        public IActionResult UpdateAboutItem(Guid id)
        {
            ViewBag.ControllerName = "Hakkımızda";
            ViewBag.PageName = "Hakkımızda Öğeleri Güncelleme Sayfası";
            var AboutItem = _context.AboutItems.Find(id);
            return View(AboutItem);
        }

        [HttpPost]
        public IActionResult UpdateAboutItem(AboutItem AboutItem)
        {
            _context.AboutItems.Update(AboutItem);
            _context.SaveChanges();
            return RedirectToAction("AboutItemList");
        }

        [HttpGet]
        public IActionResult DeleteAboutItem(Guid id)
        {
            var AboutItem = _context.AboutItems.Find(id);
            if (AboutItem != null)
            {
                _context.AboutItems.Remove(AboutItem);
                _context.SaveChanges();
            }
            return RedirectToAction("AboutItemList");
        }
        
        [HttpGet]
        public async Task<IActionResult> CreateAboutItemWithGoogleGemini()
        {
            var apiKey = "YOUR_GOOGLE_API_KEY_HERE"; // Api Key
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
                                text="Kurumsal bir sigorta firması için etkileyici, güven verici ve profesyonel bir 'Hakkımızda alanları (about item)' yazısı oluştur. Örneğin : 'Geleceğinizi güvence altına alan kapsamlı sigorta çözümleri sunuyoruz.' şeklinde veya bunun gibi ve buna benzer daha zengin içerikler gelsin. En az 10 tane item istiyorum."
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
