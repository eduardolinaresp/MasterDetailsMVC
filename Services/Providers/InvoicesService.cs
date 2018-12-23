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

        public Task<int> Add(InvoiceMaster invoice)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<InvoiceMaster>> Get()
        {
            return await this.invoicesRepo.Get();
        }

        public Task<InvoiceMaster> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(InvoiceMaster invoice)
        {
            throw new NotImplementedException();
        }
    }
}
