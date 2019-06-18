namespace MasterDetails.Migrations
{
    using MasterDetails.Areas.Administracion.Models;
    using MasterDetails.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MasterDetails.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MasterDetails.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Products1.AddOrUpdate(
               p => p.ProductName,
            new Product1 { ProductName = "Andrew Peters", CategoryID = 1 },
            new Product1 { ProductName = "Brice Lambson", CategoryID = 2 },
            new Product1 { ProductName = "Rowan Miller", CategoryID = 3 }


              );


            context.Categories1.AddOrUpdate(
                 p => p.CategoryName,
              new Category { CategoryName = "Andrew Peters" },
              new Category { CategoryName = "Brice Lambson" },
              new Category { CategoryName = "Rowan Miller" }


                );
        }
    }
}
