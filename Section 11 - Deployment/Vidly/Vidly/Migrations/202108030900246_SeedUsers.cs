namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'33e5e80a-724d-45e6-9012-d9217195f0f1', N'admin@vidly.com', 0, N'AFOZirZIzHqg1sH2/imWy26tSSAcn2FAM3NLsyG/WRZ8XOGaMW5UlclmwmiYPhsrKQ==', N'27b34575-45eb-40f1-b7d0-221246559732', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'f4dfad02-bc49-4b72-bd80-228fa428dfcf', N'guest@vidly.com', 0, N'ADR0zmizOW3mr3i76gJNybEbPdZ6PDbCCCBZx/WlUdcrlVyiROV+pm5AAyRfMCjRbg==', N'84b34113-46c4-4db5-9857-ea965728df2c', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')

                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'8cd2eebf-6f7b-4dc3-8338-d86606ea81ef', N'CanManageMovies')

                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'33e5e80a-724d-45e6-9012-d9217195f0f1', N'8cd2eebf-6f7b-4dc3-8338-d86606ea81ef')
            ");
        }
        
        public override void Down()
        {
        }
    }
}
