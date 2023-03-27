namespace HospitalApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class locationsdepartments : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Careers", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Careers", "LocationId", "dbo.Locations");
            DropIndex("dbo.Careers", new[] { "DepartmentId" });
            DropIndex("dbo.Careers", new[] { "LocationId" });
            DropColumn("dbo.Careers", "DepartmentId");
            DropColumn("dbo.Careers", "LocationId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Careers", "LocationId", c => c.Int(nullable: false));
            AddColumn("dbo.Careers", "DepartmentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Careers", "LocationId");
            CreateIndex("dbo.Careers", "DepartmentId");
            AddForeignKey("dbo.Careers", "LocationId", "dbo.Locations", "LocationId", cascadeDelete: true);
            AddForeignKey("dbo.Careers", "DepartmentId", "dbo.Departments", "DepartmentId", cascadeDelete: true);
        }
    }
}
