using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Tracker.WebAPIClient;

namespace Week82022.MVC.Controllers
{
    public class ClubEventsController : Controller
    {

        ClubModels.ClubsContext db = new ClubModels.ClubsContext();

        private List<SelectListItem> FillClubs()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            {
                var clubs = db.Clubs.ToList();
                foreach (var item in clubs)
                    items.Add(new SelectListItem()
                    { Value = item.ClubId.ToString(), Text = item.ClubName });
            }
            return items;
        }


        public ActionResult Index()
        {
            ActivityAPIClient.Track(StudentID: "S00211628",
                StudentName: "Martin Melody",
                activityName: "RAD 301 Lab 2022",
                Task: "Implementing Partial View");

            List<SelectListItem> items = FillClubs();
            items.First().Selected = true;
            ViewBag.Clubs = items;
            int cid = Int32.Parse(items.First().Value);
            return View(db.Clubs.FirstOrDefault(c => c.ClubId == cid));
        }

        [HttpPost]
        public ActionResult Index(ClubModels.Club model)
        {
            List<SelectListItem> items = FillClubs();
            items.First(s => s.Value == model.ClubId.ToString());
            ViewBag.Clubs = items;
            return View(db.Clubs.FirstOrDefault(c => c.ClubId == model.ClubId));
        }




    }
}