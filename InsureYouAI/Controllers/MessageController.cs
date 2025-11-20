using InsureYouAI.Context;
using InsureYouAI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace InsureYouAI.Controllers
{
    public class MessageController : Controller
    {
        private readonly InsureContext _context;

        public MessageController(InsureContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult MessageList()
        {
            var MessageList = _context.Messages.ToList();
            return View(MessageList);
        }

        [HttpGet]
        public IActionResult CreateMessage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateMessage(Message message)
        {
            message.SendDate = DateTime.Now;
            message.IsRead = false;
            _context.Messages.Add(message);
            _context.SaveChanges();
            return RedirectToAction("MessageList");
        }

        [HttpGet]
        public IActionResult UpdateMessage(Guid id)
        {
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
