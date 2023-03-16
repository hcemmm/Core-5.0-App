﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core_5._0_App.Controllers
{
    public class AboutController : Controller
    {
		[AllowAnonymous]
		public IActionResult Index()
        {
            return View();
        }
    }
}
