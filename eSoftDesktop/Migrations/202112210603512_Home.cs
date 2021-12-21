namespace eSoftDesktop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Home : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Apartaments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rooms = c.Int(nullable: false),
                        Floor = c.Int(nullable: false),
                        adressStreet = c.String(),
                        addressHouse = c.String(),
                        addressNumber = c.String(),
                        coordinateLatitude = c.String(),
                        coordinateLongitude = c.String(),
                        totalArea = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Houses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rooms = c.Int(nullable: false),
                        Floor = c.Int(nullable: false),
                        adressStreet = c.String(),
                        addressHouse = c.String(),
                        addressNumber = c.String(),
                        coordinateLatitude = c.String(),
                        coordinateLongitude = c.String(),
                        totalArea = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Lands",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        adressStreet = c.String(),
                        addressHouse = c.String(),
                        addressNumber = c.String(),
                        coordinateLatitude = c.String(),
                        coordinateLongitude = c.String(),
                        totalArea = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Lands");
            DropTable("dbo.Houses");
            DropTable("dbo.Apartaments");
        }
    }
}
