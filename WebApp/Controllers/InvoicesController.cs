using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApp.App_Start;

namespace WebApp.Controllers
{
    public class InvoicesController : Controller
    {
        private readonly IInvoicesService invoicesService;
        private readonly IItemsService itemsService;

        public InvoicesController()
        {
            this.invoicesService = ContextInit.ServicesFactory.GetInvoicesService();
            this.itemsService = ContextInit.ServicesFactory.GetItemsService();

        }
        // GET: Invoices
        public async Task<ActionResult> Index()
        {
            var invoices = await this.invoicesService.Get();
            return View(invoices);
        }

        // GET: Invoices/1
        public async Task<ActionResult> Details(int id)
        {
            var invoice = await this.invoicesService.Get(id);
            return View(invoice);
        }

        public async Task<ActionResult> Create()
        {
            var items = await this.itemsService.Get();
            ViewBag.items = items;
            return View();
        }
    }
}