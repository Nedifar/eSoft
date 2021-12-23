namespace eSoftDesktop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApartamentDemands",
                c => new
                    {
                        idApartamentDemand = c.Int(nullable: false, identity: true),
                        idDemand = c.Int(nullable: false),
                        minArea = c.Int(nullable: false),
                        maxArea = c.Int(nullable: false),
                        minRooms = c.Int(nullable: false),
                        maxRooms = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idApartamentDemand)
                .ForeignKey("dbo.Demands", t => t.idDemand, cascadeDelete: true)
                .Index(t => t.idDemand);
            
            CreateTable(
                "dbo.Demands",
                c => new
                    {
                        idDemand = c.Int(nullable: false, identity: true),
                        idClient = c.Int(nullable: false),
                        idRealtor = c.Int(nullable: false),
                        typeEstate = c.String(),
                        address = c.String(),
                        minPrice = c.Int(nullable: false),
                        maxPrice = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idDemand)
                .ForeignKey("dbo.Clients", t => t.idClient, cascadeDelete: true)
                .ForeignKey("dbo.Realtors", t => t.idRealtor, cascadeDelete: true)
                .Index(t => t.idClient)
                .Index(t => t.idRealtor);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        idClient = c.Int(nullable: false, identity: true),
                        lastName = c.String(),
                        Name = c.String(),
                        middleName = c.String(),
                        Telephone = c.String(),
                        eMail = c.String(),
                    })
                .PrimaryKey(t => t.idClient);
            
            CreateTable(
                "dbo.Supplies",
                c => new
                    {
                        idSupply = c.Int(nullable: false, identity: true),
                        idClient = c.Int(nullable: false),
                        idRealtor = c.Int(nullable: false),
                        idAHL = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idSupply)
                .ForeignKey("dbo.Clients", t => t.idClient, cascadeDelete: true)
                .ForeignKey("dbo.MainAHLs", t => t.idAHL, cascadeDelete: true)
                .ForeignKey("dbo.Realtors", t => t.idRealtor, cascadeDelete: true)
                .Index(t => t.idClient)
                .Index(t => t.idRealtor)
                .Index(t => t.idAHL);
            
            CreateTable(
                "dbo.MainAHLs",
                c => new
                    {
                        idAHL = c.Int(nullable: false, identity: true),
                        adressCity = c.String(),
                        adressStreet = c.String(),
                        addressHouse = c.String(),
                        addressNumber = c.String(),
                        coordinateLatitude = c.String(),
                        coordinateLongitude = c.String(),
                        totalArea = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.idAHL);
            
            CreateTable(
                "dbo.Apartaments",
                c => new
                    {
                        idApartament = c.Int(nullable: false, identity: true),
                        idAHL = c.Int(nullable: false),
                        Rooms = c.Int(nullable: false),
                        Floor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idApartament)
                .ForeignKey("dbo.MainAHLs", t => t.idAHL, cascadeDelete: true)
                .Index(t => t.idAHL);
            
            CreateTable(
                "dbo.Houses",
                c => new
                    {
                        idHouse = c.Int(nullable: false, identity: true),
                        idAHL = c.Int(nullable: false),
                        Floor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idHouse)
                .ForeignKey("dbo.MainAHLs", t => t.idAHL, cascadeDelete: true)
                .Index(t => t.idAHL);
            
            CreateTable(
                "dbo.Lands",
                c => new
                    {
                        idLand = c.Int(nullable: false, identity: true),
                        idAHL = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idLand)
                .ForeignKey("dbo.MainAHLs", t => t.idAHL, cascadeDelete: true)
                .Index(t => t.idAHL);
            
            CreateTable(
                "dbo.Realtors",
                c => new
                    {
                        idRealtor = c.Int(nullable: false, identity: true),
                        lastName = c.String(),
                        Name = c.String(),
                        middleName = c.String(),
                        comissionPart = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idRealtor);
            
            CreateTable(
                "dbo.HouseDemands",
                c => new
                    {
                        idHouseDemand = c.Int(nullable: false, identity: true),
                        idDemand = c.Int(nullable: false),
                        minArea = c.Int(nullable: false),
                        maxArea = c.Int(nullable: false),
                        minRooms = c.Int(nullable: false),
                        maxRooms = c.Int(nullable: false),
                        minFloors = c.Int(nullable: false),
                        maxFloors = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idHouseDemand)
                .ForeignKey("dbo.Demands", t => t.idDemand, cascadeDelete: true)
                .Index(t => t.idDemand);
            
            CreateTable(
                "dbo.LandDemands",
                c => new
                    {
                        idLandDemand = c.Int(nullable: false, identity: true),
                        idDemand = c.Int(nullable: false),
                        minArea = c.Int(nullable: false),
                        maxArea = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idLandDemand)
                .ForeignKey("dbo.Demands", t => t.idDemand, cascadeDelete: true)
                .Index(t => t.idDemand);
            
            CreateTable(
                "dbo.Districts",
                c => new
                    {
                        districtId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        area = c.String(),
                    })
                .PrimaryKey(t => t.districtId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LandDemands", "idDemand", "dbo.Demands");
            DropForeignKey("dbo.HouseDemands", "idDemand", "dbo.Demands");
            DropForeignKey("dbo.Supplies", "idRealtor", "dbo.Realtors");
            DropForeignKey("dbo.Demands", "idRealtor", "dbo.Realtors");
            DropForeignKey("dbo.Supplies", "idAHL", "dbo.MainAHLs");
            DropForeignKey("dbo.Lands", "idAHL", "dbo.MainAHLs");
            DropForeignKey("dbo.Houses", "idAHL", "dbo.MainAHLs");
            DropForeignKey("dbo.Apartaments", "idAHL", "dbo.MainAHLs");
            DropForeignKey("dbo.Supplies", "idClient", "dbo.Clients");
            DropForeignKey("dbo.Demands", "idClient", "dbo.Clients");
            DropForeignKey("dbo.ApartamentDemands", "idDemand", "dbo.Demands");
            DropIndex("dbo.LandDemands", new[] { "idDemand" });
            DropIndex("dbo.HouseDemands", new[] { "idDemand" });
            DropIndex("dbo.Lands", new[] { "idAHL" });
            DropIndex("dbo.Houses", new[] { "idAHL" });
            DropIndex("dbo.Apartaments", new[] { "idAHL" });
            DropIndex("dbo.Supplies", new[] { "idAHL" });
            DropIndex("dbo.Supplies", new[] { "idRealtor" });
            DropIndex("dbo.Supplies", new[] { "idClient" });
            DropIndex("dbo.Demands", new[] { "idRealtor" });
            DropIndex("dbo.Demands", new[] { "idClient" });
            DropIndex("dbo.ApartamentDemands", new[] { "idDemand" });
            DropTable("dbo.Districts");
            DropTable("dbo.LandDemands");
            DropTable("dbo.HouseDemands");
            DropTable("dbo.Realtors");
            DropTable("dbo.Lands");
            DropTable("dbo.Houses");
            DropTable("dbo.Apartaments");
            DropTable("dbo.MainAHLs");
            DropTable("dbo.Supplies");
            DropTable("dbo.Clients");
            DropTable("dbo.Demands");
            DropTable("dbo.ApartamentDemands");
        }
    }
}
