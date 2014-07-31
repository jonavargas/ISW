using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data2;
using MVC.Models;

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
            //var products = db.Products.Include(p => p.Brand1).Include(p => p.Category1);
            //return View(products.ToList());

            var products = db.Products.ToList();
            var model = new MainModels();
            model.Products = products;
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(MainModels model)
        {
            var search = model.SearchText;

            if (string.IsNullOrEmpty(search))
            {
                model.Products = db.Products.ToList();
            }
            else
            {
                model.Products = db.Products.Where(x => x.Category1.Name.Contains(search)).ToList();
            }

            return View(model);
        }      
    }
}
