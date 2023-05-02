namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyUser : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Dob", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Dob", c => c.DateTime(nullable: false));
        }
    }
}
