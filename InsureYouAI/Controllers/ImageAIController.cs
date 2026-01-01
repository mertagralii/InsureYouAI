using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace InsureYouAI.Controllers
{
    public class ImageAIController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ImageAIController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public IActionResult CreateImageWithOpenAI()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateImageWithOpenAI(string prompt)
        {
            var apiKey = "YOUR_OPENAI_API_KEY_HERE";
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apikey);
            var requestData = new
            {
                prompt = prompt,
                n = 1,
                size = "512x512"
            };
            var content = new StringContent(JsonSerializer.Serialize(requestData),Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://api.openai.com/v1/images/generations", content);
            if (!response.IsSuccessStatusCode)
            {
                ViewBag.error = "OpenAI Hatası: " + response.Content.ReadAsStringAsync();
                return View();
            }
            var json = await response.Content.ReadAsStringAsync();
            var result = JsonDocument.Parse(json);
            var imageUrl = result.RootElement.GetProperty("data")[0].GetProperty("url").GetString();
            return View(model: imageUrl);
        }
    }
}
