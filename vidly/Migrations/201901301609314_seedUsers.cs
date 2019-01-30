namespace vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'1042f9bd-62a2-46d2-8b62-b533bb94c14f', N'shanu@yahoo.com', 0, N'AKtQpquXIKfH3qB3VYeFY/D2hsOPeq6MtbyQBqpe81HGq30F7gnvoKofACFcOMi9QA==', N'dad5f052-8b5a-4a1b-8238-15f1e723dec1', NULL, 0, 0, NULL, 1, 0, N'shanu@yahoo.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'e2193e29-6059-4a42-9c5a-803abc56d33f', N'uchenna@yahoo.com', 0, N'ABpKx2f3boXY+WwyzI3M37PvyQPoXhtALgt4Ru0mCnedpUBt8EIGO9aSYgBQUGDoMA==', N'3eb8c67d-798b-44fd-a0b0-e5eaf4748d65', NULL, 0, 0, NULL, 1, 0, N'uchenna@yahoo.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'ee7bc129-748c-46ef-8eff-d5af311fd850', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'1042f9bd-62a2-46d2-8b62-b533bb94c14f', N'ee7bc129-748c-46ef-8eff-d5af311fd850')
");
                
        }

    public override void Down()
        {
        }
    }
}
