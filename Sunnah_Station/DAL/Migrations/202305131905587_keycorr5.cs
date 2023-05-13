namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class keycorr5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "ProductId", "dbo.Products");
            DropIndex("dbo.Orders", new[] { "ProductId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Orders", "ProductId");
            AddForeignKey("dbo.Orders", "ProductId", "dbo.Products", "Id");
        }
    }
}
