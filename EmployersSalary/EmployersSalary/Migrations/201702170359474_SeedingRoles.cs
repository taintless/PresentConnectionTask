namespace EmployersSalary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedingRoles : DbMigration
    {
        public override void Up()
        {

            Sql(@"

            INSERT INTO[dbo].[Employers] ([FirstName], [LastName], [NetSalary]) VALUES(N'Admin', N'Admin', NULL)
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Employer_FirstName], [Employer_LastName]) VALUES (N'866cfb64-4f60-4413-9894-b11e5bbbb4aa', N'admin@admin.com', 0, N'AB1zh9QFZxIAVmRXRAHoIAoCjMQFhFR4+AtroCksgQRV3WjaAyjPVoHeSNx++bCRaw==', N'a2f9b754-334f-4ccf-994e-55dc0d9f7b83', NULL, 0, 0, NULL, 1, 0, N'admin@admin.com', (SELECT[FirstName] FROM [dbo].[Employers] WHERE[FirstName] = 'Admin'), (SELECT[LastName] FROM[dbo].[Employers] WHERE[LastName] = 'Admin'))
            INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'800fccc7-211d-49e7-8bf6-53058e99819e', N'Admin')
            INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'866cfb64-4f60-4413-9894-b11e5bbbb4aa', N'800fccc7-211d-49e7-8bf6-53058e99819e')

            INSERT INTO[dbo].[Employers] ([FirstName], [LastName], [NetSalary]) VALUES(N'Admin', N'Manager', NULL)
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Employer_FirstName], [Employer_LastName]) VALUES (N'7b8401c4-1c07-44cb-ba03-a228def2331b', N'project@manager.com', 0, N'AKdDitQHUaq5ZoMKqTPG/yYLXOsOmQlXy3lTcxEL8U2M6Yhw+K3QnGpDwi8wtKT87Q==', N'713697a1-ea9d-40cd-99fe-1b0c593208c1', NULL, 0, 0, NULL, 1, 0, N'project@manager.com', (SELECT[FirstName] FROM [dbo].[Employers] WHERE[LastName] = 'Manager'), (SELECT[LastName] FROM[dbo].[Employers] WHERE[LastName] = 'Manager'))
            INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'6d5f5be9-4df0-47f8-8023-e41a05f93b79', N'ProjectManager')
            INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'7b8401c4-1c07-44cb-ba03-a228def2331b', N'6d5f5be9-4df0-47f8-8023-e41a05f93b79')
");
        }

        public override void Down()
        {
        }
    }
}
