namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tkon1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tokens", "TKey", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Tokens", "DeletedAt", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tokens", "DeletedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Tokens", "TKey", c => c.String(nullable: false));
        }
    }
}
