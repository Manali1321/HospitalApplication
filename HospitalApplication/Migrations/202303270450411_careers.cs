namespace HospitalApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class careers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Careers",
                c => new
                    {
                        CareerId = c.Int(nullable: false, identity: true),
                        JobName = c.String(),
                        JobId = c.Int(nullable: false),
                        JobDescription = c.String(),
                    })
                .PrimaryKey(t => t.CareerId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Careers");
        }
    }
}
