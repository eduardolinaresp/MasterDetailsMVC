using System.Data.Entity;
using DataModels.Stocks;
using DataModels.Sales;

namespace DataAccessLayer.Providers
{
    internal class DataContext : DbContext
    {
        private static string connString = "";

        //internal DataContext(string connString) : base(this.connString)
        //{

        //}

        public DataContext() : base("DefaultConnection")
        {
            connString = "DefaultConnection";
        }

        public DataContext(string connString) : base("DefaultConnection")
        {
            connString = "DefaultConnection";
        }
        public DbSet<Item> Items { get; set; }
        public DbSet<InvoiceMaster> Invoices { get; set; }
        //public DbSet<InvoiceChild> InvoiceChildren { get; set; }
    }
}
