namespace EmployersSalary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedEmployersPrimaryKey : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Employers");
            AddPrimaryKey("dbo.Employers", new[] { "FirstName", "LastName" });
            DropColumn("dbo.Employers", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employers", "Id", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Employers");
            AddPrimaryKey("dbo.Employers", "Id");
        }
    }
}
