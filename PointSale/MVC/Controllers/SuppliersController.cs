using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data3;

namespace MVC.Controllers
{
    public class SuppliersController : Controller
    {
        private PointSaleEntities db = new PointSaleEntities();

        //
        // GET: /Suppliers/

        public ActionResult Index(String Criterion = null)
        {
            if (Request.IsAjaxRequest())
            {
                return PartialView("SuppliersParcial", db.Suppliers.Where(b => Criterion == null || b.Name.StartsWith(Criterion)).ToList());
            }

            return View(db.Suppliers.Where(p => Criterion == null || p.Name.StartsWith(Criterion)).ToList());
        }

        //
        // GET: /Suppliers/Details/5

        public ActionResult Details(string id = null)
        {
            Suppliers suppliers = db.Suppliers.Find(id);
            if (suppliers == null)
            {
                return HttpNotFound();
            }
            return View(suppliers);
        }

        //
        // GET: /Suppliers/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Suppliers/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Suppliers suppliers)
        {
            if (ModelState.IsValid)
            {
                db.Suppliers.Add(suppliers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(suppliers);
        }

        //
        // GET: /Suppliers/Edit/5

        public ActionResult Edit(string id = null)
        {
            Suppliers suppliers = db.Suppliers.Find(id);
            if (suppliers == null)
            {
                return HttpNotFound();
            }
            return View(suppliers);
        }

        //
        // POST: /Suppliers/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Suppliers suppliers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(suppliers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(suppliers);
        }

        //
        // GET: /Suppliers/Delete/5

        public ActionResult Delete(string id = null)
        {
            Suppliers suppliers = db.Suppliers.Find(id);
            if (suppliers == null)
            {
                return HttpNotFound();
            }
            return View(suppliers);
        }

        //
        // POST: /Suppliers/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Suppliers suppliers = db.Suppliers.Find(id);
            db.Suppliers.Remove(suppliers);
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