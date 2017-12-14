namespace MessageHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKeyPropertiesToMessage : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Messages", name: "Artist_Id", newName: "ArtistId");
            RenameColumn(table: "dbo.Messages", name: "Genre_Id", newName: "GenreId");
            RenameIndex(table: "dbo.Messages", name: "IX_Artist_Id", newName: "IX_ArtistId");
            RenameIndex(table: "dbo.Messages", name: "IX_Genre_Id", newName: "IX_GenreId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Messages", name: "IX_GenreId", newName: "IX_Genre_Id");
            RenameIndex(table: "dbo.Messages", name: "IX_ArtistId", newName: "IX_Artist_Id");
            RenameColumn(table: "dbo.Messages", name: "GenreId", newName: "Genre_Id");
            RenameColumn(table: "dbo.Messages", name: "ArtistId", newName: "Artist_Id");
        }
    }
}
