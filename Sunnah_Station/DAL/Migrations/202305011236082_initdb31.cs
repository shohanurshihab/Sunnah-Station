namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initdb31 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Cid", "dbo.Categories");
            DropForeignKey("dbo.Orders", "Pid", "dbo.Products");
            DropForeignKey("dbo.Orders", "Cus_Id", "dbo.Customers");
            DropIndex("dbo.Products", new[] { "Cid" });
            DropIndex("dbo.Orders", new[] { "Cus_Id" });
            DropIndex("dbo.Orders", new[] { "Pid" });
            AlterColumn("dbo.Products", "Cid", c => c.Int());
            AlterColumn("dbo.Orders", "Cus_Id", c => c.Int());
            AlterColumn("dbo.Orders", "Pid", c => c.Int());
            CreateIndex("dbo.Products", "Cid");
            CreateIndex("dbo.Orders", "Cus_Id");
            CreateIndex("dbo.Orders", "Pid");
            AddForeignKey("dbo.Products", "Cid", "dbo.Categories", "Id");
            AddForeignKey("dbo.Orders", "Pid", "dbo.Products", "Id");
            AddForeignKey("dbo.Orders", "Cus_Id", "dbo.Customers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Cus_Id", "dbo.Customers");
            DropForeignKey("dbo.Orders", "Pid", "dbo.Products");
            DropForeignKey("dbo.Products", "Cid", "dbo.Categories");
            DropIndex("dbo.Orders", new[] { "Pid" });
            DropIndex("dbo.Orders", new[] { "Cus_Id" });
            DropIndex("dbo.Products", new[] { "Cid" });
            AlterColumn("dbo.Orders", "Pid", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "Cus_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "Cid", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "Pid");
            CreateIndex("dbo.Orders", "Cus_Id");
            CreateIndex("dbo.Products", "Cid");
            AddForeignKey("dbo.Orders", "Cus_Id", "dbo.Customers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "Pid", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Products", "Cid", "dbo.Categories", "Id", cascadeDelete: true);
        }
    }
}
