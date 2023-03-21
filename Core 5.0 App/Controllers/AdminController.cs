using Microsoft.AspNetCore.Mvc;

namespace Core_5._0_App.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
