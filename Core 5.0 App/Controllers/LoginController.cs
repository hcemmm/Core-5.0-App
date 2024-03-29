﻿using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Core_5._0_App.Controllers
{
	public class LoginController : Controller
	{
		[AllowAnonymous]
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[AllowAnonymous]
		[HttpPost]
		public async Task<IActionResult> Index(Writer w)
		{
			Context c = new Context();
			var datavalue = c.Writers.FirstOrDefault(x => x.WriterMail == w.WriterMail && x.WriterPassword == w.WriterPassword);
			if (datavalue != null)
			{
				var claims = new List<Claim>
				{
					new Claim(ClaimTypes.Name,w.WriterMail)
				};
				var useridentity = new ClaimsIdentity(claims,"a");
				ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
				await HttpContext.SignInAsync(principal);
				return RedirectToAction("Index", "DashBoard");
			}
			else
			{
				return View();
			}

		}
	}
}

//Context c = new Context();
//var datavalue = c.Writers.FirstOrDefault(x => x.WriterMail == w.WriterMail && x.WriterPassword == w.WriterPassword);
//         if(datavalue != null)
//{
//	HttpContext.Session.SetString("username", w.WriterMail);
//	return RedirectToAction("Index", "Writer");
//}
//else
//{
//             return View();
//         }