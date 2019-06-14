namespace MasterDetails.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tipoproducto : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TipoProductoes",
                c => new
                    {
                        TipoProductoId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.TipoProductoId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TipoProductoes");
        }
    }
}
