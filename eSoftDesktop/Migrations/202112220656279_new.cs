namespace eSoftDesktop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApartamentDemands",
                c => new
                    {
                        demandId = c.Int(nullable: false, identity: true),
                        minArea = c.Int(nullable: false),
                        maxArea = c.Int(nullable: false),
                        minRooms = c.Int(nullable: false),
                        maxRooms = c.Int(nullable: false),
                        typeEstate = c.String(),
                        address = c.String(),
                        minPrice = c.Int(nullable: false),
                        maxPrice = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.demandId);
            
            CreateTable(
                "dbo.HouseDemands",
                c => new
                    {
                        demandId = c.Int(nullable: false, identity: true),
                        minArea = c.Int(nullable: false),
                        maxArea = c.Int(nullable: false),
                        minRooms = c.Int(nullable: false),
                        maxRooms = c.Int(nullable: false),
                        minFloors = c.Int(nullable: false),
                        maxFloors = c.Int(nullable: false),
                        typeEstate = c.String(),
                        address = c.String(),
                        minPrice = c.Int(nullable: false),
                        maxPrice = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.demandId);
            
            CreateTable(
                "dbo.LandDemands",
                c => new
                    {
                        demandId = c.Int(nullable: false, identity: true),
                        minArea = c.Int(nullable: false),
                        maxArea = c.Int(nullable: false),
                        typeEstate = c.String(),
                        address = c.String(),
                        minPrice = c.Int(nullable: false),
                        maxPrice = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.demandId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LandDemands");
            DropTable("dbo.HouseDemands");
            DropTable("dbo.ApartamentDemands");
        }
    }
}
