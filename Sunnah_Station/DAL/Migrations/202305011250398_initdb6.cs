namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initdb6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Feedbacks", "Pid", "dbo.Products");
            DropIndex("dbo.Feedbacks", new[] { "Pid" });
            AlterColumn("dbo.Feedbacks", "Pid", c => c.Int());
            CreateIndex("dbo.Feedbacks", "Pid");
            AddForeignKey("dbo.Feedbacks", "Pid", "dbo.Products", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Feedbacks", "Pid", "dbo.Products");
            DropIndex("dbo.Feedbacks", new[] { "Pid" });
            AlterColumn("dbo.Feedbacks", "Pid", c => c.Int(nullable: false));
            CreateIndex("dbo.Feedbacks", "Pid");
            AddForeignKey("dbo.Feedbacks", "Pid", "dbo.Products", "Id", cascadeDelete: true);
        }
    }
}
