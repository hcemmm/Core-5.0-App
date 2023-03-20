using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_5._0_App.ViewComponents.Writer
{
	public class WriterNotification : ViewComponent
	{
        NotificationManager _notificationManager = new NotificationManager(new EfNotificationRepository());

        public IViewComponentResult Invoke()
        {
            var values = _notificationManager.GetList();
            return View(values);
        }
    }
}
