using ProjectPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectPortfolio.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        MyPortfolioDbEntities context=new MyPortfolioDbEntities();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult PartialHead()
        {
            return PartialView();
        }
        public PartialViewResult PartialSideBar()
        {
            ViewBag.imageUrll = context.Image.Select(x => x.ImageUrll).FirstOrDefault();
            return PartialView();
        }
        public PartialViewResult PartialNavbar()
        {
            return PartialView();
        }
    }
}