using ProjectPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectPortfolio.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        MyPortfolioDbEntities context = new MyPortfolioDbEntities();
        [HttpGet]
        public ActionResult ProfileList()
        {
            var value=context.Profile.FirstOrDefault();
            return View(value);
        }
        [HttpPost]
        public ActionResult ProfileList(Profile profile)
        {
            var value = context.Profile.Find(profile.Profield=1);
            value.PhoneNumber = profile.PhoneNumber;
            value.Adress = profile.Adress;
            value.Title = profile.Title;
            value.Email = profile.Email;
            value.Description = profile.Description;
            value.Github = profile.Github;
            value.ImageUrl = profile.ImageUrl;
            value.MapLocation = profile.MapLocation;
            context.SaveChanges();
            return RedirectToAction("ProfileList", "Profile");
        }
    }
}