using PagedList;
using ProjectPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectPortfolio.Controllers
{
    public class SkillController : Controller
    {
        MyPortfolioDbEntities context = new MyPortfolioDbEntities();
        public ActionResult SkillList(int page=1)//yeteneklistesi
        {
            var values = context.Skill.ToList().ToPagedList(page, 5);
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateSkill()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateSkill(Skill skill)
        {
            context.Skill.Add(skill);
            context.SaveChanges();
            return RedirectToAction("SkillList");
        }

        public ActionResult DeleteSkill(int id)
        {
            var value = context.Skill.Find(id);//parametreden gelen id değerini tablodan bul
            context.Skill.Remove(value);//bulduğun idyi sil
            context.SaveChanges();
            return RedirectToAction("SkillList");
        }
        [HttpGet]
        public ActionResult UpdateSkill(int id)
        {
            var value = context.Skill.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateSkill(Skill skill)
        {
            var value = context.Skill.Find(skill.SkillId);
            value.Title = skill.Title;
            value.Value = skill.Value;
            context.SaveChanges();
            return RedirectToAction("SkillList");
        }
    }
}