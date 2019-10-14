using Essingen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Essingen.Controllers
{
    public class HomeController : Controller
    {
        private EssingenContext db = new EssingenContext();

        // GET: Places
        public ActionResult Index()
        {
            ViewBag.SLEssingetorget = Code.Helpers.GetSL("1280", "", "bus", "35", 4);
            ViewBag.SLTvarbanan += Code.Helpers.GetSL("9811", "", "tram", "35", 4);
            ViewBag.SLLillaEssingen += Code.Helpers.GetSL("9811", "", "bus", "35", 4);
            ViewBag.Date = DateTime.Now.ToShortDateString();


            //var places = db.Places.Include(p => p.PlaceCategory);
            //return View(places.ToList());
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}