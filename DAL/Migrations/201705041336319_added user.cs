namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addeduser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Comments", "UserID", c => c.Int(nullable: false));
            AddColumn("dbo.Posts", "UserID", c => c.Int());
            CreateIndex("dbo.Comments", "UserID");
            CreateIndex("dbo.Posts", "UserID");
            AddForeignKey("dbo.Comments", "UserID", "dbo.Users", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Posts", "UserID", "dbo.Users", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "UserID", "dbo.Users");
            DropForeignKey("dbo.Comments", "UserID", "dbo.Users");
            DropIndex("dbo.Posts", new[] { "UserID" });
            DropIndex("dbo.Comments", new[] { "UserID" });
            DropColumn("dbo.Posts", "UserID");
            DropColumn("dbo.Comments", "UserID");
            DropTable("dbo.Users");
        }
    }
}
