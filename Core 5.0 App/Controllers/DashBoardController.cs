using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Core_5._0_App.Controllers
{
    public class DashBoardController : Controller
    {
        BlogManager _blogManager = new BlogManager(new EfBlogRepository());
        Context c = new Context();

        [AllowAnonymous]
        public IActionResult Index()
        {
            var usermail = User.Identity.Name;
            Context c = new Context();
            var writerName = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterNameSurname).FirstOrDefault();
            var writerImage = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterImage).FirstOrDefault();
            ViewBag.WriterName = writerName;
            ViewBag.WriterImage = writerImage;

            ViewBag.v1 = c.Blogs.Count().ToString();
            ViewBag.v2 = c.Blogs.Where(x=> x.WriterID == 1).Count().ToString();
            ViewBag.v3 = c.Blogs.Where(x => x.BlogCreateDate >= DateTime.Now.AddDays(-7)).Count();
            return View();
        }
    }
}
