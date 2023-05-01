namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initdb5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Feedbacks", "Cus_Id", "dbo.Customers");
            DropIndex("dbo.Feedbacks", new[] { "Cus_Id" });
            AlterColumn("dbo.Feedbacks", "Cus_Id", c => c.Int());
            CreateIndex("dbo.Feedbacks", "Cus_Id");
            AddForeignKey("dbo.Feedbacks", "Cus_Id", "dbo.Customers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Feedbacks", "Cus_Id", "dbo.Customers");
            DropIndex("dbo.Feedbacks", new[] { "Cus_Id" });
            AlterColumn("dbo.Feedbacks", "Cus_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Feedbacks", "Cus_Id");
            AddForeignKey("dbo.Feedbacks", "Cus_Id", "dbo.Customers", "Id", cascadeDelete: true);
        }
    }
}
