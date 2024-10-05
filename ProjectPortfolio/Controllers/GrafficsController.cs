using ProjectPortfolio.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace ProjectPortfolio.Controllers
{
    public class GrafficsController : Controller
    {
        // GET: Graffics
        MyPortfolioDbEntities context = new MyPortfolioDbEntities();
        public ActionResult PartialGraffic()
        {
            ArrayList xvalue = new ArrayList();
            ArrayList yvalue = new ArrayList();
            var values = context.Skill.ToList();
            values.ToList().ForEach(x => xvalue.Add(x.Title));
            values.ToList().ForEach(y => yvalue.Add(y.Value));
            var graffic = new Chart(width: 1100, height: 420).AddTitle("Yetenek").AddSeries(chartType: "Column", name: "Yetenek", xValue: xvalue, yValues: yvalue);

            return File(graffic.Write().GetBytes(), "image/jpeg");
        }
        public PartialViewResult PartialGrafficc()
        {
            return PartialView();
        }
    }
}