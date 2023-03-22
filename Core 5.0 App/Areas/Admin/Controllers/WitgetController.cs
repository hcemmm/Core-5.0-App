using Microsoft.AspNetCore.Mvc;

namespace Core_5._0_App.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WitgetController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
