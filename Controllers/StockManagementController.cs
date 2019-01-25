using Data;
using Data.StockManagement;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BackOffice;
using BackOffice.Models;

namespace BackOffice.Controllers
{
    public class StockManagementController : Controller
    {
        private TPW db = new TPW();

        // GET: StockManagement
        public ActionResult Index()
        {
            var PMModel = new StockManagementViewModel();
            using (var db = new TPW())
            {
                PMModel.ShortDescriptions = db.ShortDescriptions.ToList();
                PMModel.FullDescriptions = db.FullDescriptions.ToList();
                PMModel.Observations = db.Observations.ToList();
                PMModel.Recommendations = db.Recommendations.ToList();
                PMModel.Capacities = db.Capacities.ToList();
                PMModel.Categories = db.Categories.ToList();
                PMModel.Colors = db.Colors.ToList();
                PMModel.Lines = db.Lines.ToList();
                PMModel.Origins = db.Origins.ToList();
                PMModel.Parts = db.Parts.ToList();
            }
                return View(PMModel);
        }


        // GET: ShortDescriptions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShortDescription shortDescription = db.ShortDescriptions.Find(id);
            if (shortDescription == null)
            {
                return HttpNotFound();
            }
            return View(shortDescription);
        }

        // GET: ShortDescriptions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShortDescriptions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShortDescriptionId,ShortTextDescription")] ShortDescription shortDescription)
        {
            if (ModelState.IsValid)
            {
                db.ShortDescriptions.Add(shortDescription);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(shortDescription);
        }

        // GET: ShortDescriptions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShortDescription shortDescription = db.ShortDescriptions.Find(id);
            if (shortDescription == null)
            {
                return HttpNotFound();
            }
            return View(shortDescription);
        }

        // POST: ShortDescriptions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShortDescriptionId,ShortTextDescription")] ShortDescription shortDescription)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shortDescription).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shortDescription);
        }

        // GET: ShortDescriptions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShortDescription shortDescription = db.ShortDescriptions.Find(id);
            if (shortDescription == null)
            {
                return HttpNotFound();
            }
            return View(shortDescription);
        }

        // POST: ShortDescriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ShortDescription shortDescription = db.ShortDescriptions.Find(id);
            db.ShortDescriptions.Remove(shortDescription);
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