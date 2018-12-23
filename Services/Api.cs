using DataAccessLayer;
using DataModels.Sales;
using DataModels.Stocks;
using Services.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServicesFactory
    {
        private readonly IItemsService itemsService;
        private readonly IInvoicesService invoicesService;

        public ServicesFactory(string connString)
        {
            var daFactory = new DataAccessFactory(connString);

            this.itemsService = new ItemsService(daFactory.GetItemsRepo());
            this.invoicesService = new InvoicesService(daFactory.GetInvoicesRepo());
        }

        public IItemsService GetItemsService()
        {
            return this.itemsService;
        }

        public IInvoicesService GetInvoicesService()
        {
            return this.invoicesService;
        }
    }

    public interface IItemsService
    {
        Task<ICollection<Item>> Get();

        Task<Item> Get(int id);

        Task<int> Add(Item item);

        Task<int> Update(Item item);

    }

    public interface IInvoicesService
    {
        Task<ICollection<InvoiceMaster>> Get();

        Task<InvoiceMaster> Get(int id);

        Task<int> Add(InvoiceMaster invoice);

        Task<int> Update(InvoiceMaster invoice);
    }
}
