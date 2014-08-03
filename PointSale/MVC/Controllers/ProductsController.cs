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
    public class ProductsController : Controller
    {
        private PointSaleEntities db = new PointSaleEntities();

        //
        // GET: /Products/

        public ActionResult Index(String Criterion = null)
        {
            var products = db.Products.Include(p => p.Brand1).Include(p => p.Category1);
            if (Request.IsAjaxRequest())
            {
                return PartialView("ProductsParcial", products.Where(p => Criterion == null || p.Name.StartsWith(Criterion)).ToList());
            }

            return View(products.Where(p => Criterion == null || p.Name.StartsWith(Criterion)).ToList());
        }

        //
        // GET: /Products/Details/5

        public ActionResult Details(int id = 0)
        {
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        //
        // GET: /Products/Create

        public ActionResult Create()
        {
            ViewBag.Brand = new SelectList(db.Brand, "Name", "Name");
            ViewBag.Category = new SelectList(db.Category, "Name", "Name");
            return View();
        }

        //
        // POST: /Products/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Products products)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(products);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Brand = new SelectList(db.Brand, "Name", "Name", products.Brand);
            ViewBag.Category = new SelectList(db.Category, "Name", "Name", products.Category);
            return View(products);
        }

        //
        // GET: /Products/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            ViewBag.Brand = new SelectList(db.Brand, "Name", "Name", products.Brand);
            ViewBag.Category = new SelectList(db.Category, "Name", "Name", products.Category);
            return View(products);
        }

        //
        // POST: /Products/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Products products)
        {
            if (ModelState.IsValid)
            {
                db.Entry(products).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Brand = new SelectList(db.Brand, "Name", "Name", products.Brand);
            ViewBag.Category = new SelectList(db.Category, "Name", "Name", products.Category);
            return View(products);
        }

        //
        // GET: /Products/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        //
        // POST: /Products/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WarehouseProducts warehouseproducts = db.WarehouseProducts.Find(id);
            db.WarehouseProducts.Remove(warehouseproducts);



            Products products = db.Products.Find(id);
            db.Products.Remove(products);
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