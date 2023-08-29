using Karma.Business.Abstract;
using Karma.DataAccess.Migrations;
using Karma.MvcUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Karma.Entities.Concrete;
using Karma.Core.Tools;

namespace Karma.MvcUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMailService _mailService;
        public HomeController(IMailService mailService)
        {
            _mailService = mailService;
        }
        public IActionResult Index()
        {
            _mailService.SendRegisterConfirmMail("yahyatezcan.yahya@gmail.com", "http://bombabomba.com/");
            return View();
        }
    }
}
