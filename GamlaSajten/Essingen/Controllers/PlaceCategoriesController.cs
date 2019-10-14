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
    public class PlaceCategoriesController : Controller
    {
        private EssingenContext db = new EssingenContext();

        // GET: PlaceCategories
        public ActionResult Index()
        {
            return View(db.PlaceCategories.ToList());
        }

        // GET: PlaceCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlaceCategory placeCategory = db.PlaceCategories.Find(id);
            if (placeCategory == null)
            {
                return HttpNotFound();
            }
            return View(placeCategory);
        }

        // GET: PlaceCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PlaceCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CategoryName")] PlaceCategory placeCategory)
        {
            if (ModelState.IsValid)
            {
                db.PlaceCategories.Add(placeCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(placeCategory);
        }

        // GET: PlaceCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlaceCategory placeCategory = db.PlaceCategories.Find(id);
            if (placeCategory == null)
            {
                return HttpNotFound();
            }
            return View(placeCategory);
        }

        // POST: PlaceCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CategoryName")] PlaceCategory placeCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(placeCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(placeCategory);
        }

        // GET: PlaceCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlaceCategory placeCategory = db.PlaceCategories.Find(id);
            if (placeCategory == null)
            {
                return HttpNotFound();
            }
            return View(placeCategory);
        }

        // POST: PlaceCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlaceCategory placeCategory = db.PlaceCategories.Find(id);
            db.PlaceCategories.Remove(placeCategory);
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
