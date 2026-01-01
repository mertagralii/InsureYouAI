using System.Net.Http.Headers;
using InsureYouAI.Context;
using InsureYouAI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace InsureYouAI.Controllers
{
    public class ArticleController : Controller
    {
        private readonly InsureContext _context;

        public ArticleController(InsureContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult ArticleList()
        {
            ViewBag.ControllerName = "Makale";
            ViewBag.PageName = "Makale Listesi";
            var Articles = _context.Articles
                .Include(x=>x.AppUser)
                .Include(c=> c.Category)
                .ToList();
            return View(Articles);
        }

        [HttpGet]
        public IActionResult CreateArticle()
        {
            ViewBag.ControllerName = "Makaleler";
            ViewBag.PageName = "Yeni Makale Oluştur";
            
            List<SelectListItem> categories = _context.Categories
                .Select(x=> new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                })
                .ToList();
            ViewBag.Categories = categories;
            List<SelectListItem> appUsers = _context.Users
                .Select(x=> new SelectListItem
                {
                    Text = x.Name + " " + x.Surname,
                    Value = x.Id.ToString()
                })
                .ToList();
            ViewBag.AppUsers = appUsers;
            return View();
        }

        [HttpPost]
        public IActionResult CreateArticle(Article Article)
        {
            Article.CreatedDate = DateTime.UtcNow;
            _context.Articles.Add(Article);
            _context.SaveChanges();
            return RedirectToAction("ArticleList");
        }

        [HttpGet]
        public IActionResult UpdateArticle(Guid id)
        {
            ViewBag.ControllerName = "Makaleler";
            ViewBag.PageName = "Makale Güncelleme Sayfası";
            var article = _context.Articles.Find(id);
            
            List<SelectListItem> categories = _context.Categories
                .Select(x=> new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString(),
                    Selected = x.Id == article.CategoryId
                })
                .ToList();
            ViewBag.Categories = categories;
            List<SelectListItem> appUsers = _context.Users
                .Select(x=> new SelectListItem
                {
                    Text = x.Name + " " + x.Surname,
                    Value = x.Id.ToString(),
                    Selected = x.Id == article.AppUserId
                })
                .ToList();
            ViewBag.AppUsers = appUsers;
            return View(article);
        }

        [HttpPost]
        public IActionResult UpdateArticle(Article Article)
        {
            _context.Articles.Update(Article);
            _context.SaveChanges();
            return RedirectToAction("ArticleList");
        }

        [HttpGet]
        public IActionResult DeleteArticle(Guid id)
        {
            var Article = _context.Articles.Find(id);
            if (Article != null)
            {
                _context.Articles.Remove(Article);
                _context.SaveChanges();
            }
            return RedirectToAction("ArticleList");
        }
        [HttpGet]
        public async Task<IActionResult> CreateArticleWithOpenAI()
        {
            ViewBag.ControllerName = "Makaleler";
            ViewBag.PageName = "Yapay Zeka Makale Oluşturucu";
            return View();
        } 
        [HttpPost]
        public async Task<IActionResult> CreateArticleWithOpenAI(string prompt)
        {
            var apiKey = "YOUR_OPENAI_API_KEY_HERE"; // OpenAI Api Key
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
            var requestData = new
            {
                model = "gpt-3.5-turbo",
                messages = new[]
                {
                    new { role = "system", content = "Sen bir Sigorta şirketi için çalışan, içerik yazarlığı yapan bir yapay zekasın.Kullanıcının verdiği özet ve anahtar kelimelere göre, Sigortacılık sektörüyle ilgili makale üret. En az 1000 karakter olsun." },
                    new { role = "user", content = prompt}
                },
                temperature = 0.7
            };
            var response = await client.PostAsJsonAsync("https://api.openai.com/v1/chat/completions", requestData);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<OpenAIResponse>();
                var content = result.choices[0].message.content;
                ViewBag.article = content;
            }
            else
            {
                ViewBag.article ="Bir hata oluştu: " + response.StatusCode;
            }
            return View();
        }

        public class OpenAIResponse
        {
            public List<Choice> choices { get; set; }
        }
        public class Choice
        {
            public Message message { get; set; }
        }

        public class Message
        {
            public string role { get; set; }
            public string content { get; set; }
        }


    }
}
