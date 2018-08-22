namespace Vidly.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class InsertionForMovies : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies ([Name],[Genre],[ReleaseDate],[DateAdded],[NumberInStock]) VALUES('Mission: Impossible – Fallout', 'Action', '2018-07-25 00:00:00.000', GETDATE(), '10')");
            Sql("INSERT INTO Movies ([Name],[Genre],[ReleaseDate],[DateAdded],[NumberInStock]) VALUES('Christopher Robin', 'Adventure', '2018-08-03 00:00:00.000', GETDATE(), '5', '5')");
            Sql("INSERT INTO Movies ([Name],[Genre],[ReleaseDate],[DateAdded],[NumberInStock]) VALUES('The Darkest Minds', 'Sci-Fi', '2018-08-02 00:00:00.000', GETDATE(), '6', '6')");
            Sql("INSERT INTO Movies ([Name],[Genre],[ReleaseDate],[DateAdded],[NumberInStock]) VALUES('The Spy Who Dumped Me', ' Comedy', '2018-08-01 00:00:00.000', GETDATE(), '8', '8')");
            Sql("INSERT INTO Movies ([Name],[Genre],[ReleaseDate],[DateAdded],[NumberInStock]) VALUES('Death of a Nation', ' Documentary', '2018-07-31 00:00:00.000', GETDATE(), '20', '20')");
        }

        public override void Down()
        {
        }
    }
}
