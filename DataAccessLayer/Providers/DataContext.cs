using System.Data.Entity;
using DataModels.Stocks;
using DataModels.Sales;

namespace DataAccessLayer.Providers
{
    internal class DataContext : DbContext
    {
        internal DataContext(string connString) : base(connString)
        {

        }
        public DbSet<Item> Items { get; set; }
        public DbSet<InvoiceMaster> Invoices { get; set; }
        //public DbSet<InvoiceChild> InvoiceChildren { get; set; }
    }
}
