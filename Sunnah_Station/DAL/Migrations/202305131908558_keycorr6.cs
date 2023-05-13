namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class keycorr6 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Orders", "ProductId");
            AddForeignKey("dbo.Orders", "ProductId", "dbo.Products", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "ProductId", "dbo.Products");
            DropIndex("dbo.Orders", new[] { "ProductId" });
        }
    }
}
