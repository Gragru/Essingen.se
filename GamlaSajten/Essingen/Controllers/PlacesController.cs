using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Essingen.Models;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace Essingen.Views
{
    public class PlacesController : Controller
    {
        private EssingenContext db = new EssingenContext();

        // GET: Places
        public ActionResult Index()
        {
            var places = db.Places.Include(p => p.PlaceCategory);
            return View(places.ToList());
        }

        // GET: Places/Edit/5
        public ActionResult ImageAdmin(int? id)
        {
            string[] fileEntries = Directory.GetFiles(@"E:\OneDrive\Arbete\Projekt\Essingen\Essingen\Content\Streetviews");
            //var places = db.Places;
            
            foreach (string fileName in fileEntries)
            {
                string imagename = Path.GetFileName(fileName);
                var usedimage = db.Places.FirstOrDefault(pl => pl.MainImage == imagename);

                if (usedimage == null)
                {
                    ViewBag.ImageHTML += "<a href=\"/places/SaveImage/" + id + "?Imagename=" + Path.GetFileName(fileName) + "\"><img src=\"../../Content/Streetviews/" + Path.GetFileName(fileName) + "\" width=25%/></a>";
                }
                else
                {
                    ViewBag.ImageHTML += "<a href=\"/places/SaveImage/" + id + "?Imagename=" + Path.GetFileName(fileName) + "\"><img src=\"../../Content/Streetviews/" + Path.GetFileName(fileName) + "\" width=10%/></a>";
                }
            }

            ViewBag.Path = Server.MapPath("~/");


            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Place place = db.Places.Find(id);
            if (place == null)
            {
                return HttpNotFound();
            }
            ViewBag.PlaceCategoryId = new SelectList(db.PlaceCategories, "Id", "CategoryName", place.PlaceCategoryId);
            return View(place);
        }

        // GET: Places/Edit/5
        public ActionResult SaveImage(int? id, string Imagename)
        {
            Place place = db.Places.Find(id);
            place.MainImage = Imagename;
            db.SaveChanges();

            string path = @"E:\OneDrive\Arbete\Projekt\Essingen\Essingen\Content\Streetviews\";
            Image i200 = Code.Helpers.resizeImage(200, 150, path + Imagename);
            Image i300 = Code.Helpers.resizeImage(300, 225, path + Imagename);
            using (MemoryStream memoryStream = new MemoryStream())
            {
                i200.Save(path + @"WebSize200\" + Imagename, ImageFormat.Jpeg);
                //i300.Save(path + @"WebSize300\" + Imagename, ImageFormat.Jpeg);
            }

            var places = db.Places.Include(p => p.PlaceCategory);
            return View("Index", places.ToList());

        }



        // GET: Places/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Place place = db.Places.Find(id);
            if (place == null)
            {
                return HttpNotFound();
            }
            return View(place);
        }

        // GET: Places/Create
        public ActionResult Create()
        {
            ViewBag.PlaceCategoryId = new SelectList(db.PlaceCategories, "Id", "CategoryName");
            return View();
        }

        // POST: Places/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Area,SignName,CorporateName,Latitude,Longitude,PlaceCategoryId,Streetaddress,ZipCode,Phone,Email,Url,MainImage,Published")] Place place)
        {
            if (ModelState.IsValid)
            {
                db.Places.Add(place);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PlaceCategoryId = new SelectList(db.PlaceCategories, "Id", "CategoryName", place.PlaceCategoryId);
            return View(place);
        }

        // GET: Places/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Place place = db.Places.Find(id);
            if (place == null)
            {
                return HttpNotFound();
            }
            ViewBag.PlaceCategoryId = new SelectList(db.PlaceCategories, "Id", "CategoryName", place.PlaceCategoryId);
            return View(place);
        }

        // POST: Places/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Area,SignName,CorporateName,Latitude,Longitude,PlaceCategoryId,Streetaddress,ZipCode,Phone,Email,Url,MainImage,Published")] Place place)
        {
            if (ModelState.IsValid)
            {
                db.Entry(place).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PlaceCategoryId = new SelectList(db.PlaceCategories, "Id", "CategoryName", place.PlaceCategoryId);
            return View(place);
        }

        // GET: Places/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Place place = db.Places.Find(id);
            if (place == null)
            {
                return HttpNotFound();
            }
            return View(place);
        }

        // POST: Places/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Place place = db.Places.Find(id);
            db.Places.Remove(place);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
