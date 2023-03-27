namespace HospitalApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class departmentscareer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Careers", "DepartmentId", c => c.Int(nullable: false));
            AddColumn("dbo.Careers", "LocationId", c => c.Int(nullable: false));
            CreateIndex("dbo.Careers", "DepartmentId");
            CreateIndex("dbo.Careers", "LocationId");
            AddForeignKey("dbo.Careers", "DepartmentId", "dbo.Departments", "DepartmentId", cascadeDelete: true);
            AddForeignKey("dbo.Careers", "LocationId", "dbo.Locations", "LocationId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Careers", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.Careers", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Careers", new[] { "LocationId" });
            DropIndex("dbo.Careers", new[] { "DepartmentId" });
            DropColumn("dbo.Careers", "LocationId");
            DropColumn("dbo.Careers", "DepartmentId");
        }
    }
}
