using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MasterDetails.Areas.Administracion.Models;
using MasterDetails.Models;

namespace MasterDetails.Areas.Administracion.Controllers
{
    public class Product1Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Administracion/Product1
        public ActionResult Index()
        {
            return View(db.Products1.ToList());
        }

        // GET: Administracion/Product1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product1 product1 = db.Products1.Find(id);
            if (product1 == null)
            {
                return HttpNotFound();
            }
            return View(product1);
        }

        // GET: Administracion/Product1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administracion/Product1/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,CategoryID,ProductName")] Product1 product1)
        {
            if (ModelState.IsValid)
            {
                db.Products1.Add(product1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product1);
        }

        // GET: Administracion/Product1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product1 product1 = db.Products1.Find(id);
            if (product1 == null)
            {
                return HttpNotFound();
            }
            return View(product1);
        }

        // POST: Administracion/Product1/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,CategoryID,ProductName")] Product1 product1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product1);
        }

        // GET: Administracion/Product1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product1 product1 = db.Products1.Find(id);
            if (product1 == null)
            {
                return HttpNotFound();
            }
            return View(product1);
        }

        // POST: Administracion/Product1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product1 product1 = db.Products1.Find(id);
            db.Products1.Remove(product1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
