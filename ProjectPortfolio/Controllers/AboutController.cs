using ProjectPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectPortfolio.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        MyPortfolioDbEntities context= new MyPortfolioDbEntities();
        [HttpGet]
        public ActionResult AboutList()
        {

            var value = context.About.FirstOrDefault();
            return View(value);
        }
        [HttpPost]
        public ActionResult AboutList(About about)
        {

            var value = context.About.Find(about.AboutId=1);
            value.ImageUrl=about.ImageUrl;
            value.Title=about.Title;
            value.Detail=about.Detail;
            context.SaveChanges();
            return RedirectToAction("AboutList", "About");
        }
    }
}