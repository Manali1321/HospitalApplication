namespace HospitalApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class locations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
               "dbo.Locations",
               l => new
               {
                   LocationId = l.Int(nullable: false, identity: true),
                   LocationName = l.String(),
                   LocationAddress= l.String(),
               })
               .PrimaryKey(l => l.LocationId);
        }

        public override void Down()
        {
        }
    }
}
