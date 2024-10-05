using ProjectPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectPortfolio.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        MyPortfolioDbEntities context = new MyPortfolioDbEntities();
        [HttpGet]
        public ActionResult Index()
        {
            List<SelectListItem> values=(from x in context.Category.ToList()
                                         select new SelectListItem
                                         {
                                             Text=x.CategoryName,
                                             Value=x.CategoryId.ToString()
                                         }).ToList();
            ViewBag.v=values;
            return View();
        }
        [HttpPost]
        public ActionResult Index(Message message)
        {
            message.SendDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            message.IsRead = false;
            context.Message.Add(message);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public PartialViewResult PartialHead()
        {
            return PartialView();

        }
        public PartialViewResult PartialNavbar()
        {
            return PartialView();

        }
        public PartialViewResult PartialHeader()
        {
            ViewBag.title = context.About.Select(a => a.Title).FirstOrDefault();
            ViewBag.detail = context.About.Select(a => a.Detail).FirstOrDefault();
            ViewBag.imageUrl = context.About.Select(a => a.ImageUrl).FirstOrDefault();

            ViewBag.adress = context.Profile.Select(a => a.Adress).FirstOrDefault();
            ViewBag.email = context.Profile.Select(a => a.Email).FirstOrDefault();
            ViewBag.phone = context.Profile.Select(a => a.PhoneNumber).FirstOrDefault();
            ViewBag.github = context.Profile.Select(a => a.Github).FirstOrDefault();

            return PartialView(context);

        }
        public PartialViewResult PartialAbout()
        {
            ViewBag.title = context.About.Select(a => a.Title).FirstOrDefault();
            ViewBag.description = context.Profile.Select(a => a.Description).FirstOrDefault();
            ViewBag.email = context.Profile.Select(a => a.Email).FirstOrDefault();
            ViewBag.phone = context.Profile.Select(a => a.PhoneNumber).FirstOrDefault();
            ViewBag.imageUrl = context.Profile.Select(a => a.ImageUrl).FirstOrDefault();
            return PartialView();

        }
        public PartialViewResult PartialEducation()
        {
            var values = context.Education.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialScript()
        {
            return PartialView();
        }
        public PartialViewResult PartialSkill()
        {
            var values=context.Skill.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialSocialMedia()
        {
            var values = context.SocialMedia.Where(x=>x.Status==true).ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialTestimonial()
        {
            var values = context.Testimonial.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialService()
        {
            var values = context.Servicess.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialExperience() 
        {
            var values = context.Experience.ToList();
            return PartialView(values);
        }
    }
}