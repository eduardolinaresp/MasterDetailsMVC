using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataModels.Sales;

namespace Services.Providers
{
    public class InvoicesService : IInvoicesService
    {
        private readonly IInvoicesRepo invoicesRepo;

        public InvoicesService(IInvoicesRepo invoicesRepo)
        {
            this.invoicesRepo = invoicesRepo;
        }

        public async Task<int> Add(InvoiceMaster invoice)
        {
            return await this.invoicesRepo.Add(invoice);
        }

        public async Task<ICollection<InvoiceMaster>> Get()
        {
            return await this.invoicesRepo.Get();
        }

        public async Task<InvoiceMaster> Get(int id)
        {
            return await this.invoicesRepo.Get(id);
        }

        public Task<int> Update(InvoiceMaster invoice)
        {
            throw new NotImplementedException();
        }
    }
}
