using Karma.Business.Abstract;
using Karma.DataAccess.Migrations;
using Karma.MvcUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Karma.Entities.Concrete;
namespace Karma.MvcUI.Controllers
{
    public class HomeController : Controller
    {

        public HomeController(ICouponService couponService)
        {

        }
        public IActionResult Index()
        {
           

            return View();
        }
    }
}
