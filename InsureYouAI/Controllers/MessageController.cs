using InsureYouAI.Context;
using InsureYouAI.Entities;
using InsureYouAINew.Services;
using Microsoft.AspNetCore.Mvc;

namespace InsureYouAI.Controllers
{
    public class MessageController : Controller
    {
        private readonly InsureContext _context;
        private readonly AIService _aiService;

        public MessageController(InsureContext context, AIService aiService)
        {
            _context = context;
            _aiService = aiService;
        }
        

        [HttpGet]
        public ActionResult MessageList()
        {
            ViewBag.ControllerName = "Mesaj Sayfası";
            ViewBag.PageName = "İletişim Kısmından gelen Mesajlar";
            var MessageList = _context.Messages.ToList();
            return View(MessageList);
        }

        [HttpGet]
        public IActionResult CreateMessage()
        {
            ViewBag.ControllerName = "Mesaj Sayfası";
            ViewBag.PageName = "Yeni Mesaj Oluştur.";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateMessage(Message message)
        {
            var combinedText = $"{message.Subject} {message.MessageDetail}";
            var categoryTask = await _aiService.PredictCategoryAsync(combinedText);
            var priorityTask = await _aiService.PredictPriorityAsync(combinedText);
            message.AICategory = categoryTask;
            message.Priority = priorityTask;
            message.IsRead = false;
            message.SendDate = DateTime.Now;
            _context.Messages.Add(message);
            _context.SaveChanges();
            return RedirectToAction("MessageList");
        }

        [HttpGet]
        public IActionResult UpdateMessage(Guid id)
        {
            ViewBag.ControllerName = "Mesaj Sayfası";
            ViewBag.PageName = "Mesaj Güccelleme Sayfası";
            var message = _context.Messages.Find(id);
            return View(message);
        }

        [HttpPost]
        public IActionResult UpdateMessage(Message message)
        {
            _context.Messages.Update(message);
            _context.SaveChanges();
            return RedirectToAction("MessageList");
        }

        [HttpGet]
        public IActionResult DeleteMessage(Guid id)
        {
            var message = _context.Messages.Find(id);
            if (message != null)
            {
                _context.Messages.Remove(message);
                _context.SaveChanges();
            }
            return RedirectToAction("MessageList");
        }

    }
}
