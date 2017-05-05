namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeduser : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Comments", new[] { "UserID" });
            AlterColumn("dbo.Comments", "UserID", c => c.Int(nullable: false));
            CreateIndex("dbo.Comments", "UserID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Comments", new[] { "UserID" });
            AlterColumn("dbo.Comments", "UserID", c => c.Int());
            CreateIndex("dbo.Comments", "UserID");
        }
    }
}
