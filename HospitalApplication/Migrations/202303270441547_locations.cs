namespace HospitalApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class locations : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Departments", "Department_DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Careers", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Departments", "Location_LocationId", "dbo.Locations");
            DropIndex("dbo.Careers", new[] { "DepartmentId" });
            DropIndex("dbo.Departments", new[] { "Department_DepartmentId" });
            DropIndex("dbo.Departments", new[] { "Location_LocationId" });
            DropTable("dbo.Careers");
            DropTable("dbo.Departments");
            DropTable("dbo.Services");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        ServiceId = c.Int(nullable: false, identity: true),
                        ServiceName = c.String(),
                    })
                .PrimaryKey(t => t.ServiceId);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(),
                        Department_DepartmentId = c.Int(),
                        Location_LocationId = c.Int(),
                    })
                .PrimaryKey(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Careers",
                c => new
                    {
                        CareerId = c.Int(nullable: false, identity: true),
                        JobName = c.String(),
                        JobDescription = c.String(),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CareerId);
            
            CreateIndex("dbo.Departments", "Location_LocationId");
            CreateIndex("dbo.Departments", "Department_DepartmentId");
            CreateIndex("dbo.Careers", "DepartmentId");
            AddForeignKey("dbo.Departments", "Location_LocationId", "dbo.Locations", "LocationId");
            AddForeignKey("dbo.Careers", "DepartmentId", "dbo.Departments", "DepartmentId", cascadeDelete: true);
            AddForeignKey("dbo.Departments", "Department_DepartmentId", "dbo.Departments", "DepartmentId");
        }
    }
}
