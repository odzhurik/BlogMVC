namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedcategories : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Posts", "UserID", "dbo.Users");
            DropForeignKey("dbo.Comments", "UserID", "dbo.Users");
            DropIndex("dbo.Posts", new[] { "UserID" });
            DropPrimaryKey("dbo.Users");
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        UserID = c.Int(nullable: false),
                        CategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: false)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Posts", "BlogID", c => c.Int(nullable: false));
            AddColumn("dbo.Posts", "CategoryID", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "BlogID", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "ID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Users", "ID");
            CreateIndex("dbo.Posts", "BlogID");
            CreateIndex("dbo.Posts", "CategoryID");
            CreateIndex("dbo.Users", "ID");
            AddForeignKey("dbo.Posts", "BlogID", "dbo.Blogs", "ID", cascadeDelete: false);
            AddForeignKey("dbo.Posts", "CategoryID", "dbo.Categories", "ID", cascadeDelete: false);
            AddForeignKey("dbo.Users", "ID", "dbo.Blogs", "ID");
            AddForeignKey("dbo.Comments", "UserID", "dbo.Users", "ID");
            DropColumn("dbo.Posts", "UserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "UserID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Comments", "UserID", "dbo.Users");
            DropForeignKey("dbo.Users", "ID", "dbo.Blogs");
            DropForeignKey("dbo.Posts", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Posts", "BlogID", "dbo.Blogs");
            DropForeignKey("dbo.Blogs", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Users", new[] { "ID" });
            DropIndex("dbo.Posts", new[] { "CategoryID" });
            DropIndex("dbo.Posts", new[] { "BlogID" });
            DropIndex("dbo.Blogs", new[] { "CategoryID" });
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Users", "ID", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Users", "BlogID");
            DropColumn("dbo.Posts", "CategoryID");
            DropColumn("dbo.Posts", "BlogID");
            DropTable("dbo.Categories");
            DropTable("dbo.Blogs");
            AddPrimaryKey("dbo.Users", "ID");
            CreateIndex("dbo.Posts", "UserID");
            AddForeignKey("dbo.Comments", "UserID", "dbo.Users", "ID");
            AddForeignKey("dbo.Posts", "UserID", "dbo.Users", "ID", cascadeDelete: true);
        }
    }
}
