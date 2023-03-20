using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_5._0_App.ViewComponents.Writer
{
	public class WriterMessageNotification : ViewComponent
    {
        MessageManager _messageManager = new MessageManager(new EfMessageRepository());
        public IViewComponentResult Invoke()
		{
			string p = "hcemmm@gmail.com";
			var values = _messageManager.GetInboxListWithByWriter(p);
			return View(values);
		}
	}
}
