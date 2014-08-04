using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data;

namespace MVC.Controllers
{
    public class BrandController : Controller
    {
        private PointSaleEntities db = new PointSaleEntities();

        //
        // GET: /Brand/

        public ActionResult Index(String Criterion = null)
        {
            if (Request.IsAjaxRequest())
            {
                return PartialView("BrandParcial", db.Brand.Where(b => Criterion == null || b.Name.StartsWith(Criterion)).ToList());
            }

            return View(db.Brand.Where(p => Criterion == null || p.Name.StartsWith(Criterion)).ToList());




        }

        //
        // GET: /Brand/Details/5

        public ActionResult Details(int id = 0)
        {
            Brand brand = db.Brand.Find(id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            return View(brand);
        }

        //
        // GET: /Brand/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Brand/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Brand brand)
        {
            if (ModelState.IsValid)
            {
                db.Brand.Add(brand);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(brand);
        }

        //
        // GET: /Brand/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Brand brand = db.Brand.Find(id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            return View(brand);
        }

        //
        // POST: /Brand/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Brand brand)
        {
            if (ModelState.IsValid)
            {
                db.Entry(brand).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(brand);
        }

        //
        // GET: /Brand/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Brand brand = db.Brand.Find(id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            return View(brand);
        }

        //
        // POST: /Brand/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Brand brand = db.Brand.Find(id);
            db.Brand.Remove(brand);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}