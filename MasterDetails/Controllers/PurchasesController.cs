using MasterDetails.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MasterDetails.Controllers
{
    public class PurchasesController : Controller
    {
        ApplicationDbContext _db = new ApplicationDbContext();
        
        // GET: Purchases
        public ActionResult Index()
        {

            var model = _db.Purchase.ToList();

            return View(model);

        }

        public ActionResult Create()

        {
            GetTipoProductos();

            return View();
        }

        private void GetTipoProductos()
        {
            var datos = _db.TiposProducto.ToList();

            @ViewData["TiposProducto"] = datos;
        }

        public ActionResult Edit(int? id)

        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var purchase = _db.Purchase.Find(id);

            if (purchase == null)
            {
                return HttpNotFound();
            }

            var datos = _db.TiposProducto.ToList();


            var model = (from head in _db.Purchase
                         join det in _db.PurchaseDetails
                           on head.Id equals det.PurchaseId
                         where head.Id == purchase.Id
                         select new PurchaseDetailsViewModel
                         {
                             Header = head,
                             Detail = det

                         });

            PurchaseDetailsViewModel nuevo = new PurchaseDetailsViewModel();

            foreach (var item in model)
            {
               

                nuevo.Header = item.Header;
                nuevo.Detail = item.Detail;

            }


            @ViewData["TiposProducto"] = datos;

            return View(purchase);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerName,CustomerContactNo,PurchaseDetailses")] Purchase purchase)
        {

            //int idCustomer = int.Parse(Request["Header.Id"]);
            string _CustomerName = (Request["CustomerName"]);
            string _CustomerContactNo =(Request["CustomerContactNo"]);
            var _detail = Request["PurchaseDetailses"];
          
            if (ModelState.IsValid)
            {
                purchase.PurchaseDate = DateTime.Now;
                _db.Entry(purchase).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(purchase);
        }


        [HttpPost]
        public ActionResult GetDetalleRows(int? id)
        {
            //Dictionary<string, string> respuesta = new Dictionary<string, string>();
            //JavaScriptSerializer res = new JavaScriptSerializer();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var purchase = _db.Purchase.Find(id);

            if (purchase == null)
            {
                return HttpNotFound();
            }

            var detalle = _db.PurchaseDetails
                                  .Where(o => o.PurchaseId == purchase.Id)
                                  .Select(x => new {
                                      id = x.Id,
                                      Name = x.Name,
                                      Qty = x.Qty,
                                      Price = x.Price


                                  })
                                  .ToList();


            //return View();
            //return Content(res.Serialize(respuesta));

            return Json(detalle, JsonRequestBehavior.AllowGet);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Purchase purchase)
        {
            if (ModelState.IsValid && 
                purchase.PurchaseDetailses != null && purchase.PurchaseDetailses.Count > 0)
            {
                purchase.PurchaseDate = DateTime.Now;

                _db.Purchase.Add(purchase);

               var  isPurchaseAdded = _db.SaveChanges() > 0;

                if (isPurchaseAdded)
                {
                    //return View(purchase);
                    return RedirectToAction(nameof(Index));
                }
            }

            GetTipoProductos();

            return View();
        }


    }
}