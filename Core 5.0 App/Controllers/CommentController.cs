using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_5._0_App.Controllers
{
	public class CommentController : Controller
	{
		CommentManager _commentManager = new CommentManager(new EfCommentRepository());

		public IActionResult Index()
		{
			return View();
		}
		public IActionResult PartialAddComment()
		{
			return PartialView();
		}
		public IActionResult CommentListByBlog(int id)
		{
			var values = _commentManager.GetList(id);
			return PartialView(values);
		}
	}
}
