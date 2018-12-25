using DataModels.Stocks;
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
    public class ItemsController : Controller
    {
        private readonly IItemsService itemsService;

        public ItemsController()
        {
            this.itemsService = ContextInit.ServicesFactory.GetItemsService();
        }

        // GET: Items
        public async Task<ActionResult> Index()
        {
            var items = await this.itemsService.Get();
            return View(items);
        }

        public async Task<ActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Item item)
        {
            try
            {
                var result = await this.itemsService.Add(item);
                return RedirectToAction("Index");
            }catch(Exception ex)
            {
                return View(item);
            }
        }


    }
}