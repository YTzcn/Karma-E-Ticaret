﻿using Microsoft.AspNetCore.Mvc;

namespace Karma.MvcUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}