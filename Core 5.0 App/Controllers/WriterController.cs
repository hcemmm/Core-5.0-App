using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core_5._0_App.Controllers
{
    public class WriterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult WriterProfile ()
        {
            return View();
        }
        public IActionResult WriterMail()
        {
            return View();
        }
		public IActionResult Test()
		{
			return View();
		}
	}
}
