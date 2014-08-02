using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data2;

using System.Data.Entity;

namespace MVC.Controllers
{
    public class MainController : Controller
    {
        private PointSaleEntities db = new PointSaleEntities();
        //
        // GET: /Main/

        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Brand1).Include(p => p.Category1);
            return View(products.ToList());
        }

    }
}
