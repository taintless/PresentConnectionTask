namespace EmployersSalary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedEmployerPKLenght : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Employers");
            AlterColumn("dbo.Employers", "FirstName", c => c.String(nullable: false, maxLength: 225));
            AlterColumn("dbo.Employers", "LastName", c => c.String(nullable: false, maxLength: 225));
            AddPrimaryKey("dbo.Employers", new[] { "FirstName", "LastName" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Employers");
            AlterColumn("dbo.Employers", "LastName", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Employers", "FirstName", c => c.String(nullable: false, maxLength: 255));
            AddPrimaryKey("dbo.Employers", new[] { "FirstName", "LastName" });
        }
    }
}
