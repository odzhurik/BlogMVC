namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedblog : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "BlogID", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "BlogID", c => c.Int(nullable: false));
        }
    }
}
