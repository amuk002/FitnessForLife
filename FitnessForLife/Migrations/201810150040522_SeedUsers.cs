namespace FitnessForLife.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'cf229fe9-eef0-4b71-8cbf-162154601ba5', N'amuk0002@student.monash.edu', 0, N'AFC1aSZOFLggGGPpqm0lOWnZN97fzkRsZf1JNeOScIUNh6I37aMz3h5GAEHjVSN9Zg==', N'658497a7-2a30-4a78-a7d6-7faf6af99fcf', NULL, 0, 0, NULL, 1, 0, N'amuk0002@student.monash.edu')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'56436fa0-e4e8-45f4-922d-19db73987cb8', N'FitnessManager')                
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'cf229fe9-eef0-4b71-8cbf-162154601ba5', N'56436fa0-e4e8-45f4-922d-19db73987cb8')
");
        }
        
        public override void Down()
        {
        }
    }
}
