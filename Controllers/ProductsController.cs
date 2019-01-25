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
using BackOffice.Models;

namespace BackOffice.Controllers
{
    public class ProductsController : Controller
    {
        private TPW db = new TPW();

        // GET: Products
        public ActionResult Index()
        {
            var PModel = new ProductsViewModel();
            using (var db = new TPW())
            {
                PModel.ShortDescriptions = db.ShortDescriptions.ToList();
                PModel.FullDescriptions = db.FullDescriptions.ToList();
                PModel.Observations = db.Observations.ToList();
                PModel.Recommendations = db.Recommendations.ToList();
                PModel.Capacities = db.Capacities.ToList();
                PModel.Categories = db.Categories.ToList();
                PModel.Colors = db.Colors.ToList();
                PModel.Lines = db.Lines.ToList();
                PModel.Origins = db.Origins.ToList();
                PModel.Parts = db.Parts.ToList();
                PModel.Products = db.Products.ToList();
            }
            return View(PModel);
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            var PModel = new ProductCreateEditViewModel();
            using (var db = new TPW())
            {
                PModel.ShortDescriptions = db.ShortDescriptions.ToList();
                PModel.FullDescriptions = db.FullDescriptions.ToList();
                PModel.Observations = db.Observations.ToList();
                PModel.Recommendations = db.Recommendations.ToList();
                PModel.Capacities = db.Capacities.ToList();
                PModel.Categories = db.Categories.ToList();
                PModel.Colors = db.Colors.ToList();
                PModel.Lines = db.Lines.ToList();
                PModel.Origins = db.Origins.ToList();
                PModel.Parts = db.Parts.ToList();
                //Products = db.Products.ToList();
            }
            return View(PModel);
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,ProductName,ProductHeight,ProductWidth,ProductDeep,ProductDiameter,ProductWeight,ProductOrigin,ProductMicrowave,ProductMainIcon,OriginId")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            var PModel = new ProductCreateEditViewModel();
            using (var db = new TPW())
            {
                PModel.ShortDescriptions = db.ShortDescriptions.ToList();
                PModel.FullDescriptions = db.FullDescriptions.ToList();
                PModel.Observations = db.Observations.ToList();
                PModel.Recommendations = db.Recommendations.ToList();
                PModel.Capacities = db.Capacities.ToList();
                PModel.Categories = db.Categories.ToList();
                PModel.Colors = db.Colors.ToList();
                PModel.Lines = db.Lines.ToList();
                PModel.Origins = db.Origins.ToList();
                PModel.Parts = db.Parts.ToList();
                PModel.Product = product;
            }
            return View(PModel);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,ProductName,ProductHeight,ProductWidth,ProductDeep,ProductDiameter,ProductWeight,ProductOrigin,ProductMicrowave,ProductMainIcon,OriginId")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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
