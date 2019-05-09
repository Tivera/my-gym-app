using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyGymApplication.Data;
using MyGymApplication.Models.GymModels;

namespace MyGymApplication.Controllers
{
    public class TrackMyWeightsController : Controller
    {
        private MyGymContext db = new MyGymContext();

        // GET: TrackMyWeights
        public ActionResult Index()
        {
            return View(db.TrackMyWeights.ToList());
        }

        // GET: TrackMyWeights/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrackMyWeight trackMyWeight = db.TrackMyWeights.Find(id);
            if (trackMyWeight == null)
            {
                return HttpNotFound();
            }
            return View(trackMyWeight);
        }

        // GET: TrackMyWeights/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TrackMyWeights/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,week,weight,MembershipNumber")] TrackMyWeight trackMyWeight)
        {
            if (ModelState.IsValid)
            {
                db.TrackMyWeights.Add(trackMyWeight);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trackMyWeight);
        }

        // GET: TrackMyWeights/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrackMyWeight trackMyWeight = db.TrackMyWeights.Find(id);
            if (trackMyWeight == null)
            {
                return HttpNotFound();
            }
            return View(trackMyWeight);
        }

        // POST: TrackMyWeights/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,week,weight,MembershipNumber")] TrackMyWeight trackMyWeight)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trackMyWeight).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trackMyWeight);
        }

        // GET: TrackMyWeights/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrackMyWeight trackMyWeight = db.TrackMyWeights.Find(id);
            if (trackMyWeight == null)
            {
                return HttpNotFound();
            }
            return View(trackMyWeight);
        }

        // POST: TrackMyWeights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TrackMyWeight trackMyWeight = db.TrackMyWeights.Find(id);
            db.TrackMyWeights.Remove(trackMyWeight);
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
