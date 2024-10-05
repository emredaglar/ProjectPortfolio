using ProjectPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace ProjectPortfolio.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        MyPortfolioDbEntities context=new MyPortfolioDbEntities();
        public PartialViewResult PartialContactSideBar()
        {
            return PartialView();
        }
        public PartialViewResult PartialContactAdress()
        {
            ViewBag.description=context.Profile.Select(x => x.Description).FirstOrDefault();
            ViewBag.adress=context.Profile.Select(x => x.Adress).FirstOrDefault();
            ViewBag.email=context.Profile.Select(x => x.Email).FirstOrDefault();
            ViewBag.phone=context.Profile.Select(x => x.PhoneNumber).FirstOrDefault();
            
            return PartialView();
        }
        public PartialViewResult PartialContactLocation()
        {
            ViewBag.mapLocation=context.Profile.Select(x=>x.MapLocation).FirstOrDefault();
            return PartialView();
        }
    }
}