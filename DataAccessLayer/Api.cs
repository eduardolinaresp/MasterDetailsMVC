using DataAccessLayer.Providers;
using DataModels.Sales;
using DataModels.Stocks;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DataAccessFactory
    {
        private readonly IItemsRepo itemsRepo;
        private readonly IInvoicesRepo invoicesRepo;

        public DataAccessFactory(string connString)
        {
            var dataContext = new DataContext(connString);

            this.itemsRepo = new ItemsRepo(dataContext);
            this.invoicesRepo = new InvoicesRepo(dataContext);
        }

        public IItemsRepo GetItemsRepo()
        {
            return this.itemsRepo;
        }

        public IInvoicesRepo GetInvoicesRepo()
        {
            return this.invoicesRepo;
        }
    }

    public interface IItemsRepo
    {
        Task<ICollection<Item>> Get();

        Task<Item> Get(int id);

        Task<int> Add(Item item);

        Task<int> Update(Item item);
    }

    public interface IInvoicesRepo
    {
        Task<ICollection<InvoiceMaster>> Get();

        Task<InvoiceMaster> Get(int id);

        Task<int> Add(InvoiceMaster item);

        Task<int> Update(InvoiceMaster item);

    }
}