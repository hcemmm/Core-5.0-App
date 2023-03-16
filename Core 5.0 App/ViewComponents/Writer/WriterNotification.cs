using Microsoft.AspNetCore.Mvc;

namespace Core_5._0_App.ViewComponents.Writer
{
	public class WriterNotification : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
