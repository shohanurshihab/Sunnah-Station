namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Dob = c.DateTime(nullable: false),
                        Password = c.String(nullable: false),
                        Pic = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        Cid = c.Int(nullable: false),
                        Pic = c.Binary(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Cid, cascadeDelete: true)
                .Index(t => t.Cid);
            
            CreateTable(
                "dbo.Feedbacks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Comment = c.String(nullable: false, maxLength: 500),
                        Pid = c.Int(nullable: false),
                        Cus_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Cus_Id, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Pid, cascadeDelete: true)
                .Index(t => t.Pid)
                .Index(t => t.Cus_Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false, maxLength: 100),
                        Phone = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Blood = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Pic = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cus_Id = c.Int(nullable: false),
                        Pid = c.Int(nullable: false),
                        Status = c.String(nullable: false, maxLength: 20),
                        Message = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Cus_Id, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Pid, cascadeDelete: true)
                .Index(t => t.Cus_Id)
                .Index(t => t.Pid);
            
            CreateTable(
                "dbo.OrderedProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Pid = c.Int(nullable: false),
                        Oid = c.Int(nullable: false),
                        Order_Id = c.Int(),
                        Product_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.Order_Id)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .Index(t => t.Order_Id)
                .Index(t => t.Product_Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Email = c.String(nullable: false, maxLength: 100),
                        Blood = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Pic = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Managers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Phone = c.String(nullable: false, maxLength: 20),
                        Email = c.String(nullable: false, maxLength: 100),
                        Blood = c.String(nullable: false, maxLength: 10),
                        Password = c.String(nullable: false),
                        Pic = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Feedbacks", "Pid", "dbo.Products");
            DropForeignKey("dbo.Orders", "Pid", "dbo.Products");
            DropForeignKey("dbo.OrderedProducts", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.OrderedProducts", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.Orders", "Cus_Id", "dbo.Customers");
            DropForeignKey("dbo.Feedbacks", "Cus_Id", "dbo.Customers");
            DropForeignKey("dbo.Products", "Cid", "dbo.Categories");
            DropIndex("dbo.OrderedProducts", new[] { "Product_Id" });
            DropIndex("dbo.OrderedProducts", new[] { "Order_Id" });
            DropIndex("dbo.Orders", new[] { "Pid" });
            DropIndex("dbo.Orders", new[] { "Cus_Id" });
            DropIndex("dbo.Feedbacks", new[] { "Cus_Id" });
            DropIndex("dbo.Feedbacks", new[] { "Pid" });
            DropIndex("dbo.Products", new[] { "Cid" });
            DropTable("dbo.Managers");
            DropTable("dbo.Employees");
            DropTable("dbo.OrderedProducts");
            DropTable("dbo.Orders");
            DropTable("dbo.Customers");
            DropTable("dbo.Feedbacks");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
            DropTable("dbo.Admins");
        }
    }
}
