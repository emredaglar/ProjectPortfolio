using ProjectPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectPortfolio.Controllers
{
    public class SocialMediaController : Controller
    {
        // GET: SocialMedia
        MyPortfolioDbEntities context= new MyPortfolioDbEntities();
        public ActionResult SocialMediaList()
        {
            var value=context.SocialMedia.ToList();
            return View(value);
        }
        public ActionResult ButtonStatusChangeToTrue(int id)
        {
            var value = context.SocialMedia.Where(x => x.SocialMediaId == id).FirstOrDefault();
            value.Status = false;
            context.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }
        public ActionResult ButtonStatusChangeToFalse(int id)
        {
            var value = context.SocialMedia.Where(x => x.SocialMediaId == id).FirstOrDefault();
            value.Status = true;
            context.SaveChanges();
            return RedirectToAction("SocialMediaList"); ;
        }
        [HttpGet]
        public ActionResult CreateSocial()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateSocial(SocialMedia socialMedia)
        {
            context.SocialMedia.Add(socialMedia);
            context.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }
        public ActionResult DeleteSocial(int id)
        {
            var value = context.SocialMedia.Find(id);
            context.SocialMedia.Remove(value);
            context.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }
    }
}