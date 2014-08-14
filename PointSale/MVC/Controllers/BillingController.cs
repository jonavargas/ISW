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
    public class BillingController : Controller
    {


        private PointSaleEntities db = new PointSaleEntities();
        static List<BillDetail> listaDetalle = new List<BillDetail>();
        //
        // GET: /Main/


        public ActionResult Index(String Criterion = null)
        {
            var products = db.Products.Include(p => p.Brand1).Include(p => p.Category1);
            if (Request.IsAjaxRequest())
            {
                return PartialView("BillingParcial", products.Where(p => Criterion == null || p.Name.StartsWith(Criterion)).ToList());
            }
            ViewBag.Employee = new SelectList(db.Employee, "Id", "Name");
            ViewBag.Subtotal = this.calcularSubtotal();

            return View(products.Where(p => Criterion == null || p.Name.StartsWith(Criterion)).ToList());
        }

       public Boolean ValidarDetalle(BillDetail billDetail){

            var estado=false;
            for (int cont = 0; cont < listaDetalle.Count;cont++ )
            {
                if(billDetail.Code==listaDetalle[cont].Code){
                    estado = true;
                }
            }
            return estado;     
        }


        

        public int incrementoCantidad(BillDetail billDetail){
             var qty=0;
            for (int cont = 0; cont < listaDetalle.Count; cont++)
            {
                if (billDetail.Code == listaDetalle[cont].Code)
                {
                   
                   qty+=listaDetalle[cont].Qty.Value;
                   listaDetalle.RemoveAt(cont);
                   return (qty);
                   
                }
            }
            return (qty);
        }



        public Boolean ValidarConsulta(int number)
        {

            var estado = false;
            if(number==-1){
                estado = true;
            }
            return estado;
        }

        public int calcularSubtotal()
        {
            int cantidad = 0;
            int precio = 0;
            int resultado = 0;

            for (int cont = 0; cont < listaDetalle.Count; cont++)
            {
                cantidad= listaDetalle[cont].Qty.Value;
                precio = listaDetalle[cont].UnitCost.Value;
                resultado += cantidad * precio;

            }



            return (resultado);
        }


        public int calcularTotal(int discount)
        { 
            int descuento = 0;
            int subtotal = this.calcularSubtotal();
            descuento = subtotal * discount;
            int resultado = this.calcularSubtotal() - descuento;
            return (resultado);
        }
        public void insertarDatosDetalle()
        {
            BillDetail detalle = new BillDetail();
            int bill = 0;
            int code = 0;
            string producto = "";
            int cantidad = 0;
            int costo = 0;

            
            for (int cont = 0; cont < listaDetalle.Count; cont++)
            {
                bill = listaDetalle[cont].Bill;
               
                code = listaDetalle[cont].Code.Value;
                producto = listaDetalle[cont].Product;
                cantidad = listaDetalle[cont].Qty.Value;
                costo = listaDetalle[cont].UnitCost.Value;
                detalle.Bill = bill;
                
                detalle.Code = code;
                detalle.Product = producto;
                detalle.Qty = cantidad;
                detalle.UnitCost = costo;
                db.BillDetail.Add(detalle);
                db.SaveChanges();
                listaDetalle.RemoveAt(cont);



            }


        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Bill bill)
        {
            this.insertarDatosDetalle();
            if(ViewBag.Discount==null){

                if (ModelState.IsValid)
                {
                    db.Bill.Add(bill);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.Employee = new SelectList(db.Employee, "Id", "Name", bill.Employee);
            }
            else
            {
               int total= this.calcularTotal(ViewBag.Discount);
               bill.Total = total;
            }
           

            return View(bill);
        }




        public ActionResult ListDetail(int id=0)
        {
            var bill = db.Bill.SqlQuery("SELECT MAX(Id) AS Id FROM Bill").ToString();
            var billresult= db.Database.ExecuteSqlCommand(bill).ToString();
            var bill2= Int32.Parse(billresult);
            if(this.ValidarConsulta(bill2)==true){
                bill2 = Int32.Parse(billresult) + 2;
            }
            else
            {
                bill2 = Int32.Parse(billresult) + 1;
            }
          

            Products products = db.Products.Find(id);
            
            var name= products.Name;
            int code= Int32.Parse(products.Code);
            var cost=Int32.Parse(products.CostPrice);
           

            BillDetail detalle = new BillDetail();
            detalle.Bill = bill2;
            detalle.Code = code;
            detalle.Product = name;
            detalle.UnitCost = cost;
           
            
            if(this.ValidarDetalle(detalle)==false){
                detalle.Qty = 1;
                listaDetalle.Add(detalle);
            }
            else
            {
                     var qty= this.incrementoCantidad(detalle);
                     qty += 1;
                      detalle.Qty = qty;
                      listaDetalle.Add(detalle);
                      
                
            }
            

            return View(listaDetalle);
        }
     }
  }

