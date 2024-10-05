using ProjectPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectPortfolio.Controllers
{
    public class EducationController : Controller
    {
        // GET: Education
        MyPortfolioDbEntities context = new MyPortfolioDbEntities();
        public ActionResult EducationList()
        {
            var value = context.Education.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult CreateEducation()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateEducation(Education education)
        {
            context.Education.Add(education);
            context.SaveChanges();
            return RedirectToAction("EducationList");
        }

        public ActionResult DeleteEducation(int id)
        {
            var value = context.Education.Find(id);//parametreden gelen id değerini tablodan bul
            context.Education.Remove(value);//bulduğun idyi sil
            context.SaveChanges();
            return RedirectToAction("EducationList");
        }
        [HttpGet]
        public ActionResult UpdateEducation(int id)
        {
            var value = context.Education.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateEducation(Education education)
        {
            var value = context.Education.Find(education.EducationId);
            value.Title = education.Title;
            value.EducationDate = education.EducationDate;
            value.Description = education.Description;
            value.Subtitle = education.Subtitle;
            context.SaveChanges();
            return RedirectToAction("EducationList");
        }
    }
}