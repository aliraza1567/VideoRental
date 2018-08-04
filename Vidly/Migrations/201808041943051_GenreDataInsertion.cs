namespace Vidly.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class GenreDataInsertion : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO [Genres] ([Name]) VALUES('Action')");
            Sql("INSERT INTO [Genres] ([Name]) VALUES('Adventure')");
            Sql("INSERT INTO [Genres] ([Name]) VALUES('Sci-Fi')");
            Sql("INSERT INTO [Genres] ([Name]) VALUES('Comedy')");
            Sql("INSERT INTO [Genres] ([Name]) VALUES('Documentary')");

        }

        public override void Down()
        {
        }
    }
}
