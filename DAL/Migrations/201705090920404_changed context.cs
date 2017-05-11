namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedcontext : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Blogs", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Posts", "BlogID", "dbo.Blogs");
            DropForeignKey("dbo.Posts", "CategoryID", "dbo.Categories");
            AddForeignKey("dbo.Blogs", "CategoryID", "dbo.Categories", "ID", cascadeDelete: false);
            AddForeignKey("dbo.Posts", "BlogID", "dbo.Blogs", "ID", cascadeDelete: false);
            AddForeignKey("dbo.Posts", "CategoryID", "dbo.Categories", "ID", cascadeDelete: true);
            DropColumn("dbo.Blogs", "UserID");
            DropColumn("dbo.Users", "BlogID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "BlogID", c => c.Int());
            AddColumn("dbo.Blogs", "UserID", c => c.Int());
            DropForeignKey("dbo.Posts", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Posts", "BlogID", "dbo.Blogs");
            DropForeignKey("dbo.Blogs", "CategoryID", "dbo.Categories");
            AddForeignKey("dbo.Posts", "CategoryID", "dbo.Categories", "ID");
            AddForeignKey("dbo.Posts", "BlogID", "dbo.Blogs", "ID");
            AddForeignKey("dbo.Blogs", "CategoryID", "dbo.Categories", "ID");
        }
    }
}
