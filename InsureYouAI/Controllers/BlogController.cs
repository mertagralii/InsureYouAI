using System.Net.Http.Headers;
using System.Text.Json;
using InsureYouAI.Context;
using InsureYouAI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InsureYouAI.Controllers
{
    public class BlogController : Controller
    {
        private readonly InsureContext _context;

        public BlogController(InsureContext context)
        {
            _context = context;
        }
        public IActionResult BlogList()
        {
            return View();
        }
        public IActionResult GetBlogByCategory(Guid id)
        { 
            ViewBag.CategoryId = id;
            return View();
        }
        public IActionResult BlogDetail(Guid id)
        {
            ViewBag.i = id;
            return View();
        }

        [HttpGet]
        public PartialViewResult GetBlog()
        {
            return PartialView();
        }
        [HttpPost]
        public IActionResult GetBlog(string keyword)
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult AddComment()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(Comment comment)
        {
            // Buradaki çalışma mantığı şu şekil olucak, kullanıcı yorum eklediğinde eğer yorum türkçe ise bunu huggingface api ile ingilizceye çevireceğiz
            // ardından ingilizceye çevirilen yorumu tekrar huggingface'ye gönderip yorumun toxic olup olmadığını kontrol edeceğiz.
            // Eğer yorum toxic ise kullanıcıya uyarı vereceğiz ve yorumu eklemeyeceğiz.
            // Eğer yorum toxic değil ise yorumu direkt olarak ekleyeceğiz.
            comment.CommentDate = DateTime.Now;
            comment.AppUserId = "0fcf8801-058c-4fe8-9d48-1913e38e088a";
            using (var client = new HttpClient())
            {
                var apiKey ="YOUR_HUGGINFACE_API_KEY"; // Hugginface APİ Anahtarı
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
                try
                {
                    var translateRequestBody = new
                    {
                        inputs = comment.CommentDetail,
                    };
                    var translateJson = JsonSerializer.Serialize(translateRequestBody);
                    var translateContent = new StringContent(translateJson, System.Text.Encoding.UTF8, "application/json");
                    var translateResponse = await client.PostAsync("https://api-inference.huggingface.co/models/Helsinki-NLP/opus-mt-tr-en", translateContent);
                    var translateResponseString = await translateResponse.Content.ReadAsStringAsync();
                    string englishText = comment.CommentDetail;
                    if (translateResponseString.TrimStart().StartsWith("["))
                    {
                        var translateDoc = JsonDocument.Parse(translateResponseString);
                        englishText = translateDoc.RootElement[0].GetProperty("translation_text").GetString();
                    }
                    var toxicityRequestBody = new
                    {
                        inputs = englishText,
                    };
                    var toxicJson = JsonSerializer.Serialize(toxicityRequestBody);
                    var toxicContent = new StringContent(toxicJson, System.Text.Encoding.UTF8, "application/json");
                    var toxicResponse = await client.PostAsync("https://api-inference.huggingface.co/models/unitary/toxic-bert", toxicContent);
                    var toxicResponseString = await toxicResponse.Content.ReadAsStringAsync();
                    if (toxicResponseString.TrimStart().StartsWith("["))
                    {
                        var toxicityDoc = JsonDocument.Parse(toxicResponseString);
                        foreach (var item in toxicityDoc.RootElement[0].EnumerateArray() )
                        {
                          string label =  item.GetProperty("label").GetString();  
                          double score = item.GetProperty("score").GetDouble();
                          if (score > 0.5)
                          {
                              comment.CommentStatus = "Toxic Yorum";
                              break;
                          }
                        }
                    }
                    if (string.IsNullOrEmpty(comment.CommentStatus))
                    {
                        comment.CommentStatus = "Yorum Onaylandı";
                    }
                }
                catch (Exception ex)
                {
                   comment.CommentStatus = "Onay Bekliyor";
                }
            }
            _context.Comments.Add(comment);
            _context.SaveChanges();
            return RedirectToAction("BlogList");
        }
    }
}
