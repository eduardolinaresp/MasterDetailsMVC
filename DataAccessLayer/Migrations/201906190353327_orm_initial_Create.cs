namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orm_initial_Create : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InvoiceMasters",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        CustomerName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.InvoiceChilds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InvoiceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.InvoiceMasters", t => t.InvoiceId, cascadeDelete: true)
                .ForeignKey("dbo.Items", t => t.ItemId, cascadeDelete: true)
                .Index(t => t.ItemId)
                .Index(t => t.InvoiceId);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        Unit = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InvoiceChilds", "ItemId", "dbo.Items");
            DropForeignKey("dbo.InvoiceChilds", "InvoiceId", "dbo.InvoiceMasters");
            DropIndex("dbo.InvoiceChilds", new[] { "InvoiceId" });
            DropIndex("dbo.InvoiceChilds", new[] { "ItemId" });
            DropTable("dbo.Items");
            DropTable("dbo.InvoiceChilds");
            DropTable("dbo.InvoiceMasters");
        }
    }
}
