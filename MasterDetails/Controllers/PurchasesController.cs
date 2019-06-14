using MasterDetails.Models;
using System;
using System.Collections.Generic;
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
            var datos = _db.TiposProducto.ToList();

            @ViewData["TiposProducto"] = datos;

            return View();
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
                           on head.Id equals det.Id
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


          var   x = "--------";

            //PurchaseDetailsViewModel  model = (from head in _db.Purchase
            //                                       join det in _db.PurchaseDetails
            //                                         on head.Id equals det.Id
            //                                       where head.Id == purchase.Id
            //                                       select new
            //                                       {
            //                                           Header = head,
            //                                           Detail = det

            //                                       });

            @ViewData["TiposProducto"] = datos;

            return View(nuevo);

        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Purchase purchase)
        {
            if (ModelState.IsValid && 
                purchase.PurchaseDetailses != null && purchase.PurchaseDetailses.Count > 0)
            {
                _db.Purchase.Add(purchase);

               var  isPurchaseAdded = _db.SaveChanges() > 0;

                if (isPurchaseAdded)
                {
                    return View(purchase);
                }
            }

            return View();
        }


    }
}