using ProjectPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectPortfolio.Controllers
{
    public class StatisticsController : Controller
    {
        // GET: Statistics
        MyPortfolioDbEntities context=new MyPortfolioDbEntities();
        public ActionResult Index()
        {
            //Count :bir tablo içerisindeki kaç tane kayıt olduğunu getirir.
            int messageCount=context.Message.Count();
            //Okunan ve okunmayan mesaj sayıları
            int messageCountIsReadByTrue=context.Message.Where(x=>x.IsRead==true).Count();
            int messageCountIsReadByFalse=context.Message.Where(x=>x.IsRead==false).Count();
            //Yetenek sayısı
            int skillCount=context.Skill.Count();
            //yetenek değer toplamları
            var totalSkillValue=context.Skill.Sum(x=>x.Value);
            //yetenek değerlerinin ortalaması
            var avarageSkillValue=context.Skill.Average(x=>x.Value);
            //hangi mailden geldiği
            var getEmailFromProfile=context.Profile.Select(x=>x.Email).FirstOrDefault();
            var getLastCategoryId=context.Category.Max(x=>x.CategoryId);
            var getLastCategoryName=context.Category.Where(x=>x.CategoryId==getLastCategoryId).Select(y=>y.CategoryName).FirstOrDefault();

            ViewBag.messageCount = messageCount;
            ViewBag.messageCountIsReadByTrue = messageCountIsReadByTrue;
            ViewBag.messageCountIsReadByFalse = messageCountIsReadByFalse;
            ViewBag.skillCount = skillCount;
            ViewBag.totalSkillValue = totalSkillValue;
            ViewBag.avarageSkillValue = avarageSkillValue;
            ViewBag.getEmailFromProfile = getEmailFromProfile;
            ViewBag.getLastCategoryName= getLastCategoryName;
            
            return View();
        }
    }
}