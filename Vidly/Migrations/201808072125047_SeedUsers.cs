namespace Vidly.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], 
                [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'060a576c-85f2-420c-9094-a4a4b08d3006', 
                N'admin@vidly.com', 0, N'AKHIoAzQYNMo0IF50j7jXbJ7WwNCKjIgjZ4HZes7Mg1/+vZUNblGh10m91vdiFPemg==', N'213ffcfd-ab8a-45b3-82c8-1a463a7b2654', NULL, 0, 0, NULL, 1, 
                0, N'admin@vidly.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], 
                [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'b7b95a09-1548-4b97-b939-3c4bf167c0e7', N'aliraza1567@gmail.com', 
                0, N'AFmMdghSto5DFeUq6ZTrJxlf9kUbvidbUwTcFBnqEBXeWLdfSXtwWybRbd9WELsQ9w==', N'fd53101d-a845-4c38-b043-8948d116b292', NULL, 0, 0, NULL, 1, 0, N'aliraza1567@gmail.com')
                ");
            Sql(@"INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'7fbc85de-6b56-41c9-b870-35f305c2789e', N'CanManageMovies')");

            Sql(@"INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'060a576c-85f2-420c-9094-a4a4b08d3006', N'7fbc85de-6b56-41c9-b870-35f305c2789e')");
        }

        public override void Down()
        {
        }
    }
}
