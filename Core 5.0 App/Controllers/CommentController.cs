using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Core_5._0_App.Controllers
{
	public class CommentController : Controller
	{
		CommentManager _commentManager = new CommentManager(new EfCommentRepository());

		public IActionResult Index()
		{
			return View();
		}
		[HttpGet]
		public IActionResult PartialAddComment()
		{
			return PartialView();
		}
        [HttpPost]
        public IActionResult PartialAddComment(Comment c)
        {
			c.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
			c.CommentStatus = true;
			c.BlogID = 2;
			_commentManager.CommentAdd(c);
            return PartialView();
        }
        public IActionResult CommentListByBlog(int id)
		{
			var values = _commentManager.GetList(id);
			return PartialView(values);
		}
	}
}
