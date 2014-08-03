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
    public class BillController : Controller
    {
        private PointSaleEntities db = new PointSaleEntities();

        //
        // GET: /Bill/

        public ActionResult Index(String Criterion = null)
        {
            var bill = db.Bill.Include(b => b.Client1).Include(b => b.Employee1).Include(b => b.BillDetail);

            if (Request.IsAjaxRequest())
            {
                return PartialView("BillParcial", bill.Where(p => Criterion == null || p.Client1.Name.StartsWith(Criterion)).ToList());
            }

            return View(bill.Where(p => Criterion == null || p.Client1.Name.StartsWith(Criterion)).ToList());


        }

        //
        // GET: /Bill/Details/5

        public ActionResult Details(int id = 0)
        {
            Bill bill = db.Bill.Find(id);
            if (bill == null)
            {
                return HttpNotFound();
            }
            return View(bill);
        }

        //
        // GET: /Bill/Create

        public ActionResult Create()
        {
            ViewBag.Client = new SelectList(db.Client, "Id", "Name");
            ViewBag.Employee = new SelectList(db.Employee, "Id", "Name");
            ViewBag.Id = new SelectList(db.BillDetail, "Bill", "Product");
            return View();
        }

        //
        // POST: /Bill/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Bill bill)
        {
            if (ModelState.IsValid)
            {
                db.Bill.Add(bill);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Client = new SelectList(db.Client, "Id", "Name", bill.Client);
            ViewBag.Employee = new SelectList(db.Employee, "Id", "Name", bill.Employee);
            ViewBag.Id = new SelectList(db.BillDetail, "Bill", "Product", bill.Id);
            return View(bill);
        }

        //
        // GET: /Bill/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Bill bill = db.Bill.Find(id);
            if (bill == null)
            {
                return HttpNotFound();
            }
            ViewBag.Client = new SelectList(db.Client, "Id", "Name", bill.Client);
            ViewBag.Employee = new SelectList(db.Employee, "Id", "Name", bill.Employee);
            ViewBag.Id = new SelectList(db.BillDetail, "Bill", "Product", bill.Id);
            return View(bill);
        }

        //
        // POST: /Bill/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Bill bill)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bill).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Client = new SelectList(db.Client, "Id", "Name", bill.Client);
            ViewBag.Employee = new SelectList(db.Employee, "Id", "Name", bill.Employee);
            ViewBag.Id = new SelectList(db.BillDetail, "Bill", "Product", bill.Id);
            return View(bill);
        }

        //
        // GET: /Bill/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Bill bill = db.Bill.Find(id);
            if (bill == null)
            {
                return HttpNotFound();
            }
            return View(bill);
        }

        //
        // POST: /Bill/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bill bill = db.Bill.Find(id);
            db.Bill.Remove(bill);
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