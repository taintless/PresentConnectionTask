namespace EmployersSalary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedEmployerModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employers", "NetSalary", c => c.Single());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employers", "NetSalary", c => c.Single(nullable: false));
        }
    }
}
