using InsureYouAI.Context;
using InsureYouAI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace InsureYouAI.Controllers
{
    public class ContactController : Controller
    {
        private readonly InsureContext _context;

        public ContactController(InsureContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult ContactList()
        {
            var contactList = _context.Contacts.ToList();
            return View(contactList);
        }

        [HttpGet]
        public IActionResult CreateContact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateContact(Contact contact)
        {
            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return RedirectToAction("ContactList");
        }

        [HttpGet]
        public IActionResult UpdateContact(Guid id)
        {
            var contact = _context.Contacts.Find(id);
            return View(contact);
        }

        [HttpPost]
        public IActionResult UpdateContact(Contact contact)
        {
            _context.Contacts.Update(contact);
            _context.SaveChanges();
            return RedirectToAction("ContactList");
        }

        [HttpGet]
        public IActionResult DeleteContact(Guid id)
        {
            var contact = _context.Contacts.Find(id);
            if (contact != null)
            {
                _context.Contacts.Remove(contact);
                _context.SaveChanges();
            }

            return RedirectToAction("ContactList");
        }
    }
}
