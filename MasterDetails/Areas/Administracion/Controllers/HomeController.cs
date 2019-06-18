using MasterDetails.Areas.Administracion.Models;
using MasterDetails.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MasterDetails.Areas.Administracion.Controllers
{
    public class HomeController : Controller
    {
        // GET: Administracion/Home
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult getProductCategories()
        {
            List<Category> categories = new List<Category>();
            using (ApplicationDbContext dc = new ApplicationDbContext())
            {
                categories = dc.Categories1.OrderBy(a => a.CategoryName).ToList();
            }
            return new JsonResult { Data = categories, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult getProducts(int categoryID)
        {
            List<Product1> products = new List<Product1>();
            using (ApplicationDbContext dc = new ApplicationDbContext())
            {
                products = dc.Products1.Where(a => a.CategoryID.Equals(categoryID)).OrderBy(a => a.ProductName).ToList();
            }
            return new JsonResult { Data = products, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [HttpPost]
        public JsonResult save(OrderMaster order)
        {
            bool status = false;
            DateTime dateOrg;
            var isValidDate = DateTime.TryParseExact(order.OrderDate.ToShortDateString(), "dd-mm-yyyy", null, System.Globalization.DateTimeStyles.None, out dateOrg);
            if (isValidDate)
            {
                order.OrderDate = dateOrg;
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var item in errors)
            {
                Console.WriteLine(item.ErrorMessage);
            }
            var isValidModel = TryUpdateModel(order);
            if (isValidModel)
            {
                using (ApplicationDbContext dc = new ApplicationDbContext())
                {
                    dc.OrderMasters.Add(order);
                    dc.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status } };
        }

    }
}
