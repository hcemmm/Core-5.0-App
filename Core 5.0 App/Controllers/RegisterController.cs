using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Core_5._0_App.Controllers
{
    public class RegisterController : Controller
	{
		WriterManager _writerManager = new WriterManager(new EfWriterRepository());

		[HttpGet]
		public IActionResult Index()
        {
            return View();
        }
		[HttpPost]
		public IActionResult Index(Writer w)
		{
			WriterValidator validationRules = new WriterValidator();
			ValidationResult results = validationRules.Validate(w);
			
			if(results.IsValid)
			{
				w.WriterBool = true;
				w.WriterAbout = "test";
				_writerManager.WriterAdd(w);
				return RedirectToAction("Index", "Blog");
			}
			else
			{
				foreach(var x in results.Errors)
				{
					ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
				}
			}
			return View();
			
		}
	}
}
