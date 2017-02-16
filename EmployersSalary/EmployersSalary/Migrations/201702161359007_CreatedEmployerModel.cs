namespace EmployersSalary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedEmployerModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employers",
                c => new
                    {
                        FirstName = c.String(nullable: false, maxLength: 255),
                        LastName = c.String(nullable: false, maxLength: 255),
                        NetSalary = c.Single(),
                    })
                .PrimaryKey(t => new { t.FirstName, t.LastName });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Employers");
        }
    }
}
