using ProjectPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace ProjectPortfolio.Controllers
{
    public class ServicessController : Controller
    {
        // GET: Services
        MyPortfolioDbEntities context= new MyPortfolioDbEntities();
        public ActionResult ServicessList()
        {
            var value = context.Servicess.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult CreateServicess()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateServicess(Servicess servicess)
        {
            context.Servicess.Add(servicess);
            context.SaveChanges();
            return RedirectToAction("ServicessList");
        }

        public ActionResult DeleteServicess(int id)
        {
            var value = context.Servicess.Find(id);//parametreden gelen id değerini tablodan bul
            context.Servicess.Remove(value);//bulduğun idyi sil
            context.SaveChanges();
            return RedirectToAction("ServicessList");
        }
        [HttpGet]
        public ActionResult UpdateServicess(int id)
        {
            var value = context.Servicess.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateServicess(Servicess servicess)
        {
            var value = context.Servicess.Find(servicess.ServiceId);
            value.Title = servicess.Title;
            value.Description = servicess.Description;
            value.feature = servicess.feature;          
            context.SaveChanges();
            return RedirectToAction("ServicessList");
        }
    }
}