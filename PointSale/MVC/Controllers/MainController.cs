using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data;
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
                return PartialView("MainProductsParcial", products.Where(p => Criterion == null || p.Name.StartsWith(Criterion)).ToList());
            }

            return View(products.Where(p => Criterion == null || p.Name.StartsWith(Criterion)).ToList());
        }
    }
}
