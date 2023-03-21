using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_5._0_App.ViewComponents.Writer
{
	public class WriterMessageNotification : ViewComponent
    {
        MessageTwoManager _messageTwoManager = new MessageTwoManager(new EfMessageTwoRepository());
        public IViewComponentResult Invoke()
		{
			int id = 2;
			var values = _messageTwoManager.GetInboxListWithByWriter(id);
			return View(values);
		}
	}
}
