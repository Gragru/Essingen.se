using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Essingen.Models;

namespace Essingen.Views
{
    public class PlacesScaffoldController : Controller
    {
        private EssingenContext db = new EssingenContext();

        // GET: PlacesScaffold
        public ActionResult Index()
        {
            var places = db.Places.Include(p => p.PlaceCategory);
            return View(places.ToList());
        }

        // GET: PlacesScaffold/Details/5
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

        // GET: PlacesScaffold/Create
        public ActionResult Create()
        {
            ViewBag.PlaceCategoryId = new SelectList(db.PlaceCategories, "Id", "CategoryName");
            return View();
        }

        // POST: PlacesScaffold/Create
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

        // GET: PlacesScaffold/Edit/5
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

        // POST: PlacesScaffold/Edit/5
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

        // GET: PlacesScaffold/Delete/5
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

        // POST: PlacesScaffold/Delete/5
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
