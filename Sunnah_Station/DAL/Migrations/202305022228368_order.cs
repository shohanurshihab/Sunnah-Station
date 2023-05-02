namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class order : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "ProductId", "dbo.Products");
            AddColumn("dbo.Products", "Order_Id", c => c.Int());
            AddColumn("dbo.Orders", "Product_Id", c => c.Int());
            CreateIndex("dbo.Products", "Order_Id");
            CreateIndex("dbo.Orders", "Product_Id");
            AddForeignKey("dbo.Products", "Order_Id", "dbo.Orders", "Id");
            AddForeignKey("dbo.Orders", "Product_Id", "dbo.Products", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Products", "Order_Id", "dbo.Orders");
            DropIndex("dbo.Orders", new[] { "Product_Id" });
            DropIndex("dbo.Products", new[] { "Order_Id" });
            DropColumn("dbo.Orders", "Product_Id");
            DropColumn("dbo.Products", "Order_Id");
            AddForeignKey("dbo.Orders", "ProductId", "dbo.Products", "Id");
        }
    }
}
