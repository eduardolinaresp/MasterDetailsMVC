using MasterDetails.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MasterDetails.Controllers
{
    public class PurchasesController : Controller
    {
        ApplicationDbContext _db = new ApplicationDbContext();
        
        // GET: Purchases
        public ActionResult Create()
        {
            return View();
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