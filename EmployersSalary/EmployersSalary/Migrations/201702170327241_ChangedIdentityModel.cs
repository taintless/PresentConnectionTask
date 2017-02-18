namespace EmployersSalary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class ChangedIdentityModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Employer_FirstName", c => c.String(nullable: false, maxLength: 225));
            AddColumn("dbo.AspNetUsers", "Employer_LastName", c => c.String(nullable: false, maxLength: 225));
            CreateIndex("dbo.AspNetUsers", new[] { "Employer_FirstName", "Employer_LastName" });
            AddForeignKey("dbo.AspNetUsers", new[] { "Employer_FirstName", "Employer_LastName" }, "dbo.Employers", new[] { "FirstName", "LastName" }, cascadeDelete: true);
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropColumn("dbo.AspNetUsers", "LastName");
        }

        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String(nullable: false, maxLength: 225));
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String(nullable: false, maxLength: 225));
            DropForeignKey("dbo.AspNetUsers", new[] { "Employer_FirstName", "Employer_LastName" }, "dbo.Employers");
            DropIndex("dbo.AspNetUsers", new[] { "Employer_FirstName", "Employer_LastName" });
            DropColumn("dbo.AspNetUsers", "Employer_LastName");
            DropColumn("dbo.AspNetUsers", "Employer_FirstName");
        }
    }
}
