using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using Core_5._0_App.Models;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;

namespace Core_5._0_App.Controllers
{
    public class WriterController : Controller
    {
        WriterManager _writerManager = new WriterManager(new EfWriterRepository());

        Context c = new Context();

        [Authorize]
        public IActionResult Index()
        {
            var usermail = User.Identity.Name;
            var writerName = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterNameSurname).FirstOrDefault();
            var writerImage = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterImage).FirstOrDefault();
            ViewBag.WriterName = writerName;
            ViewBag.WriterImage = writerImage;
            

            return View();
        }
        public IActionResult WriterProfile()
        {
            return View();
        }
        public IActionResult WriterMail()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult WriterEditProfile()
        {
            var usermail = User.Identity.Name;            
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            var writervalues = _writerManager.TGetByID(writerID);
            return View(writervalues);
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult WriterEditProfile(Writer w)
        {
            WriterValidator validationRules = new WriterValidator();
            ValidationResult results = validationRules.Validate(w);

            if (results.IsValid)
            {
                _writerManager.TUpdate(w);
                return RedirectToAction("WriterEditProfile", "Writer");
            }
            else
            {
                foreach (var x in results.Errors)
                {
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
                }
            }
            return View();
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult WriterAdd()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult WriterAdd(AddProfileImage ap)
        {
            Writer w = new Writer();

            if (ap.WriterImage != null)
            {
                var extension = Path.GetExtension(ap.WriterImage.FileName);
                var newImage = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newImage);
                var stream = new FileStream(location,FileMode.Create);
                ap.WriterImage.CopyTo(stream);
                w.WriterImage = newImage;
            }
            w.WriterMail = ap.WriterMail;
            w.WriterNameSurname = ap.WriterNameSurname;
            w.WriterPassword = ap.WriterPassword;
            w.WriterBool = ap.WriterBool;
            w.WriterAbout = ap.WriterAbout;

            _writerManager.TAdd(w);
            return RedirectToAction("Index", "Dashboard");
        }
    }
}
