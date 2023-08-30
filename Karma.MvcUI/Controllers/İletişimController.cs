using Karma.Business.Abstract;
using Karma.Entities.Concrete;
using Karma.MvcUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Karma.MvcUI.Controllers
{
    public class İletişimController : Controller
    {
        private readonly IContactService _contactService;
        public İletişimController(IContactService contactService)
        {
            _contactService = contactService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddContactMessage(ContactFormViewModel contactMessage)
        {
            _contactService.Add(contactMessage.ContactMessage);
            return RedirectToAction("Index");
        }
    }
}
