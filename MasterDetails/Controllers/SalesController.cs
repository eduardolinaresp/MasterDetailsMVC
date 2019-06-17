using MasterDetails.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MasterDetails.Controllers
{
    public class SalesController : Controller
    {
        // GET: Sales

        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult NewOrder()
        {
            OrderView _orderview = new OrderView();

            _orderview.Customer = new CustomerOrder();

            _orderview.Products = new List<ProductOrder>();

            var list = db.Customers.ToList();
            ViewBag.CustomerId = new SelectList(list, "CustomerId", "CompanyName");
            return View(_orderview);
        }

        [HttpPost]
        public ActionResult NewOrder(OrderView OrderView)
        {
            OrderView = Session["OrderView"] as OrderView;
            int idCustomer = int.Parse(Request["CustomerId"]);

            DateTime _orderDate = Convert.ToDateTime(Request["OrderDate"]);
            Order lv_order = new Order
            {
                CustomerId = idCustomer,
                OrderDate = _orderDate
            };

            db.Orders.Add(lv_order);
            db.SaveChanges();

            int lastOrderId = db.Orders.ToList().Select(o => o.OrderId).Max();

            foreach (var item in OrderView.Products)
            {
                var details = new OrderDetail()
                {

                    OrderId = lastOrderId,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice

                };

                db.OrderDetails.Add(details);
            }

            db.SaveChanges();

            return View(OrderView);
        }

        [HttpGet]
        public ActionResult AddProduct()
        {
            var listp = db.Products.ToList();
            ViewBag.ProductId = new SelectList(listp, "ProductId", "ProductName");

            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(ProductOrder productOrder)
        {

            OrderView _OrderView = new OrderView();

            var OrderView = Session["OrderView"] as OrderView;

            if (OrderView == null)
            {

                OrderView = new OrderView();
            }

            //var OrderView = new OrderView();

            //Session["OrderView"] = OrderView;

            var productId = int.Parse(Request["ProductId"]);

            var product = db.Products.Find(productId);

           var  _productOrder = new ProductOrder()
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                UnitPrice = product.UnitPrice,
                Quantity = int.Parse(Request["quantity"])

            };

            decimal multiplicacion = _productOrder.Partial;

            _OrderView.Products.Add(_productOrder);

            var list = db.Customers.ToList();
            ViewBag.CustomerId = new SelectList(list, "CustomerId", "CompanyName");

            var listp = db.Products.ToList();
            ViewBag.ProductId = new SelectList(listp, "ProductId", "ProductName");

            return View("NewOrder", _OrderView);
        }
    }
}