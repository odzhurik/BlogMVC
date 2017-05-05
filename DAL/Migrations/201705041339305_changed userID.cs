namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeduserID : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "UserID", "dbo.Users");
            DropForeignKey("dbo.Posts", "UserID", "dbo.Users");
            DropIndex("dbo.Comments", new[] { "UserID" });
            DropIndex("dbo.Posts", new[] { "UserID" });
            AlterColumn("dbo.Comments", "UserID", c => c.Int());
            AlterColumn("dbo.Posts", "UserID", c => c.Int(nullable: false));
            CreateIndex("dbo.Comments", "UserID");
            CreateIndex("dbo.Posts", "UserID");
            AddForeignKey("dbo.Comments", "UserID", "dbo.Users", "ID");
            AddForeignKey("dbo.Posts", "UserID", "dbo.Users", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "UserID", "dbo.Users");
            DropForeignKey("dbo.Comments", "UserID", "dbo.Users");
            DropIndex("dbo.Posts", new[] { "UserID" });
            DropIndex("dbo.Comments", new[] { "UserID" });
            AlterColumn("dbo.Posts", "UserID", c => c.Int());
            AlterColumn("dbo.Comments", "UserID", c => c.Int(nullable: false));
            CreateIndex("dbo.Posts", "UserID");
            CreateIndex("dbo.Comments", "UserID");
            AddForeignKey("dbo.Posts", "UserID", "dbo.Users", "ID");
            AddForeignKey("dbo.Comments", "UserID", "dbo.Users", "ID", cascadeDelete: true);
        }
    }
}
