using Microsoft.AspNetCore.Mvc;

namespace Core_5._0_App.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
