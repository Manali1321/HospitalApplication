namespace HospitalApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class locationsservices : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ServiceLocations",
                c => new
                    {
                        Service_ServiceId = c.Int(nullable: false),
                        Location_LocationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Service_ServiceId, t.Location_LocationId })
                .ForeignKey("dbo.Services", t => t.Service_ServiceId, cascadeDelete: true)
                .ForeignKey("dbo.Locations", t => t.Location_LocationId, cascadeDelete: true)
                .Index(t => t.Service_ServiceId)
                .Index(t => t.Location_LocationId);
            
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
            DropForeignKey("dbo.ServiceLocations", "Location_LocationId", "dbo.Locations");
            DropForeignKey("dbo.ServiceLocations", "Service_ServiceId", "dbo.Services");
            DropIndex("dbo.ServiceLocations", new[] { "Location_LocationId" });
            DropIndex("dbo.ServiceLocations", new[] { "Service_ServiceId" });
            DropIndex("dbo.Careers", new[] { "LocationId" });
            DropIndex("dbo.Careers", new[] { "DepartmentId" });
            DropColumn("dbo.Careers", "LocationId");
            DropColumn("dbo.Careers", "DepartmentId");
            DropTable("dbo.ServiceLocations");
        }
    }
}
