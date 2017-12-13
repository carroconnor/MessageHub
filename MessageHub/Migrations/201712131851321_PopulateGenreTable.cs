namespace MessageHub.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateGenreTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id, Name) VALUES (1, 'Happy')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (2, 'Angry')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (3, 'Funny')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (4, 'Supportive')");
        }

        public override void Down()
        {
            Sql("DELETE FROM Genres WHERE Id IN (1,2,3,4");
        }
    }
}
