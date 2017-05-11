namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedentities1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Posts", "BlogID", "dbo.Blogs");
            DropIndex("dbo.Blogs", new[] { "ID" });
            DropPrimaryKey("dbo.Blogs");
            AlterColumn("dbo.Blogs", "ID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Blogs", "ID");
            CreateIndex("dbo.Blogs", "ID");
            AddForeignKey("dbo.Posts", "BlogID", "dbo.Blogs", "ID", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "BlogID", "dbo.Blogs");
            DropIndex("dbo.Blogs", new[] { "ID" });
            DropPrimaryKey("dbo.Blogs");
            AlterColumn("dbo.Blogs", "ID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Blogs", "ID");
            CreateIndex("dbo.Blogs", "ID");
            AddForeignKey("dbo.Posts", "BlogID", "dbo.Blogs", "ID", cascadeDelete: false);
        }
    }
}
