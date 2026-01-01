using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using InsureYouAI.Context;
using InsureYouAI.Entities;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;

namespace InsureYouAI.Controllers
{
    public class DefaultController : Controller
    {
        private readonly InsureContext _context;

        public DefaultController(InsureContext context)
        {
            _context = context;
        }
        
        public ActionResult Index()
        {
            return View();
        }
        
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }
        
        [HttpPost]
        public async Task<IActionResult> SendMessage(Message message)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            message.SendDate = DateTime.Now;
            message.IsRead = false;
            _context.Messages.Add(message);
            _context.SaveChanges();
            var cloudeApiKey ="YOUR_CLAUDE_API_KEY_HERE"; // Claude Api Anahtarı
            var prompt = $"Sen bir sigorta firmasının müşteri iletişim asistanısın.\n\nKurumsal ama samimi, net ve anlaşılır bir dille yaz.\n\nYanıtlarını 2–3 paragrafla sınırla.\n\nEksik bilgi (poliçe numarası, kimlik vb.) varsa kibarca talep et.\n\nFiyat, ödeme, teminat gibi kritik konularda kesin rakam verme, müşteri temsilcisine yönlendir.\n\nHasar ve sağlık gibi hassas durumlarda empati kur.\n\nCevaplarını teşekkür ve iyi dilekle bitir.\n\n Kullanıcının Sana Gönderdiği Mesaj Şu Şekilde:'{message.MessageDetail}.'";
            using var clientAi = new HttpClient();
            clientAi.BaseAddress = new Uri("https://api.anthropic.com/");
            clientAi.DefaultRequestHeaders.Add("x-api-key",cloudeApiKey);
            clientAi.DefaultRequestHeaders.Add("anthropic-version","2024-04-30");
            clientAi.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var requestBody = new
            {
                model = "claude-2",
                max_tokens_to_sample = 1000,
                temperature = 0.5,
                messages =  new[]
                {
                    new
                    {
                        role = "user",
                        content = prompt 
                    }
                }
            };
            var jsonContent = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");
            var response = await clientAi.PostAsync("v1/messages/completions", jsonContent);
            var responseString = await response.Content.ReadAsStringAsync();
            var json = JsonNode.Parse(responseString);
            string? textContent = json?["completion"]?[0]?["text"]?.ToString();
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAdressFrom = new MailboxAddress("InsureYouAI Admin", "mmertagrali@gmail.com");
            mimeMessage.From.Add(mailboxAdressFrom);
            MailboxAddress mailboxAddressTo = new MailboxAddress("User", message.Email);
            mimeMessage.To.Add(mailboxAddressTo);
            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = textContent;
            mimeMessage.Body = bodyBuilder.ToMessageBody();
            mimeMessage.Subject = "InsureYouAI Mesaj Yanıtı";
            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            // Burada uygulama şifresi kullanıldı bunu almak için ise Google hesabınızın güvenlik ayarlarından "Uygulama Şifreleri" kısmına gitmeniz gerekiyor.
            // Uygulama Şifresini alabilmen için google hesabınızda 2 Adımlı Doğrulama'nın aktif olması gerekmektedir.
            client.Authenticate("bymert3131@gmail.com", "ekwm yuir wtlz ilwv"); 
            client.Send(mimeMessage);
            client.Disconnect(true);
            ClaudeAIMessage claudeAIMessage = new ClaudeAIMessage()
            {
                MessageDetail = textContent,
                ReceiveEmail = message.Email,
                ReceiveNameSurname = message.NameSurname,
                SendDate = DateTime.Now
            };
            _context.ClaudeAIMessages.Add(claudeAIMessage);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public PartialViewResult SubscribeEmail()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult SubscribeEmail(string email)
        {
            return View();
        }

    }
}
