using Microsoft.AspNetCore.Mvc;

namespace Core_5._0_App.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
