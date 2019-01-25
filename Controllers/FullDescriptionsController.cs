using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Data;
using Data.StockManagement;

namespace BackOffice.Controllers
{
    public class FullDescriptionsController : Controller
    {
        private TPW db = new TPW();

        // GET: FullDescriptions
        public ActionResult Index()
        {
            return View(db.FullDescriptions.ToList());
        }

        // GET: FullDescriptions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FullDescription fullDescription = db.FullDescriptions.Find(id);
            if (fullDescription == null)
            {
                return HttpNotFound();
            }
            return View(fullDescription);
        }

        // GET: FullDescriptions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FullDescriptions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FullDescriptionId,FullTextDescription")] FullDescription fullDescription)
        {
            if (ModelState.IsValid)
            {
                db.FullDescriptions.Add(fullDescription);
                db.SaveChanges();
                return RedirectToAction("../StockManagement/Index");
            }

            return View(fullDescription);
        }

        // GET: FullDescriptions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FullDescription fullDescription = db.FullDescriptions.Find(id);
            if (fullDescription == null)
            {
                return HttpNotFound();
            }
            return View(fullDescription);
        }

        // POST: FullDescriptions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FullDescriptionId,FullTextDescription")] FullDescription fullDescription)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fullDescription).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("../StockManagement/Index");
            }
            return View(fullDescription);
        }

        // GET: FullDescriptions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FullDescription fullDescription = db.FullDescriptions.Find(id);
            if (fullDescription == null)
            {
                return HttpNotFound();
            }
            return View(fullDescription);
        }

        // POST: FullDescriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FullDescription fullDescription = db.FullDescriptions.Find(id);
            db.FullDescriptions.Remove(fullDescription);
            db.SaveChanges();
            return RedirectToAction("../StockManagement/Index");
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
