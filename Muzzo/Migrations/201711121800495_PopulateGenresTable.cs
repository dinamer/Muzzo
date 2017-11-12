namespace Muzzo.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateGenresTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id, Name) VALUES (1, 'Avant-Garde')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (2, 'Blues')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (3, 'Children''s')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (4, 'Classical')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (5, 'Country')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (6, 'Electronic')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (7, 'Jazz')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (8, 'Pop/Rock')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (9, 'R&B')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (10, 'Rap')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (11, 'Reggae')");
        }

        public override void Down()
        {
        }
    }
}
