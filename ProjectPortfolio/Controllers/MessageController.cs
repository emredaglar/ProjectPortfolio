using ProjectPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectPortfolio.Controllers
{
    public class MessageController : Controller
    {
        // GET: Mesaj
        MyPortfolioDbEntities context=new MyPortfolioDbEntities();
        public ActionResult Inbox()
        {
            var values=context.Message.ToList();
            return View(values);
        }
        public ActionResult MessageDetails(int id)
        {
            var value = context.Message.FirstOrDefault(x => x.MessageId == id);//find yerine kullandık.wher yerine FOD içine koşul yazılabilir
            value.IsRead = true;
            context.SaveChanges();
            return View(value);
        }
        public ActionResult MessageStatusChangeToTrue(int id)
        {
            var value = context.Message.Where(x => x.MessageId == id).FirstOrDefault();
            value.IsRead=true;
            context.SaveChanges();
            return RedirectToAction("Inbox");
        }
        public ActionResult MessageStatusChangeToFalse(int id)
        {
            var value = context.Message.Where(x => x.MessageId == id).FirstOrDefault();
            value.IsRead = false;
            context.SaveChanges();
            return RedirectToAction("Inbox"); ;
        }
        public ActionResult DeleteMessage(int id)
        {
            var value = context.Message.Find(id);
            context.Message.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Inbox");
        }

    }
}