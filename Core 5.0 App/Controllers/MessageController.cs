using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System;
using DataAccessLayer.Concrete;

namespace Core_5._0_App.Controllers
{
    public class MessageController : Controller
    {
        MessageTwoManager _messageTwoManager = new MessageTwoManager(new EfMessageTwoRepository());
        Context c = new Context();

        public IActionResult InBox()
        {
            var usermail = User.Identity.Name;
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();

            var values = _messageTwoManager.GetInboxListWithByWriter(writerID);
            return View(values);
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult MessageDetail(int id)
        {
            var value = _messageTwoManager.TGetByID(id);
            return View(value);
        }
        [HttpPost]
        [AllowAnonymous]
        public IActionResult MessageDetail(MessageTwo mt)
        {
            mt.MessageStatus = false;
            _messageTwoManager.TUpdate(mt);
            return RedirectToAction("InBox", "Message");
        }
    }
}
