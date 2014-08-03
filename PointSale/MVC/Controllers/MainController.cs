using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data3;
using System.Data.Entity;
using System.Data;




namespace MVC.Controllers
{
    public class MainController : Controller
    {
        private PointSaleEntities db = new PointSaleEntities();
        //
        // GET: /Main/

        public ActionResult Index(String Criterion = null)
        {
            var products = db.Products.Include(p => p.Brand1).Include(p => p.Category1);
            if (Request.IsAjaxRequest())
            {
                return PartialView("MainProductsParcial", products.Where(p => Criterion == null || p.Category.StartsWith(Criterion)).ToList());
            }

            return View(products.Where(p => Criterion == null || p.Category.StartsWith(Criterion)).ToList());
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







    }
}
