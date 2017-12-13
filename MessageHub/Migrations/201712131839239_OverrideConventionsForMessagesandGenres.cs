namespace MessageHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OverrideConventionsForMessagesandGenres : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Messages", "Artist_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Messages", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Messages", new[] { "Artist_Id" });
            DropIndex("dbo.Messages", new[] { "Genre_Id" });
            AlterColumn("dbo.Genres", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Messages", "Venue", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Messages", "Artist_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Messages", "Genre_Id", c => c.Byte(nullable: false));
            CreateIndex("dbo.Messages", "Artist_Id");
            CreateIndex("dbo.Messages", "Genre_Id");
            AddForeignKey("dbo.Messages", "Artist_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Messages", "Genre_Id", "dbo.Genres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Messages", "Genre_Id", "dbo.Genres");
            DropForeignKey("dbo.Messages", "Artist_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Messages", new[] { "Genre_Id" });
            DropIndex("dbo.Messages", new[] { "Artist_Id" });
            AlterColumn("dbo.Messages", "Genre_Id", c => c.Byte());
            AlterColumn("dbo.Messages", "Artist_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Messages", "Venue", c => c.String());
            AlterColumn("dbo.Genres", "Name", c => c.String());
            CreateIndex("dbo.Messages", "Genre_Id");
            CreateIndex("dbo.Messages", "Artist_Id");
            AddForeignKey("dbo.Messages", "Genre_Id", "dbo.Genres", "Id");
            AddForeignKey("dbo.Messages", "Artist_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
