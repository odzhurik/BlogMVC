namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedblog1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Blogs", "UserID", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Blogs", "UserID", c => c.Int(nullable: false));
        }
    }
}
