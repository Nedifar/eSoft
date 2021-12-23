namespace eSoftDesktop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApartamentDemands", "minFloors", c => c.Int());
            AddColumn("dbo.ApartamentDemands", "maxFloors", c => c.Int());
            AddColumn("dbo.Demands", "addressCity", c => c.String());
            AddColumn("dbo.Demands", "addressStreet", c => c.String());
            AddColumn("dbo.Demands", "addressHouse", c => c.String());
            AddColumn("dbo.Demands", "addressNumber", c => c.String());
            AlterColumn("dbo.ApartamentDemands", "minArea", c => c.Int());
            AlterColumn("dbo.ApartamentDemands", "maxArea", c => c.Int());
            AlterColumn("dbo.ApartamentDemands", "minRooms", c => c.Int());
            AlterColumn("dbo.ApartamentDemands", "maxRooms", c => c.Int());
            AlterColumn("dbo.HouseDemands", "minArea", c => c.Int());
            AlterColumn("dbo.HouseDemands", "maxArea", c => c.Int());
            AlterColumn("dbo.HouseDemands", "minRooms", c => c.Int());
            AlterColumn("dbo.HouseDemands", "maxRooms", c => c.Int());
            AlterColumn("dbo.HouseDemands", "minFloors", c => c.Int());
            AlterColumn("dbo.HouseDemands", "maxFloors", c => c.Int());
            AlterColumn("dbo.LandDemands", "minArea", c => c.Int());
            AlterColumn("dbo.LandDemands", "maxArea", c => c.Int());
            DropColumn("dbo.Demands", "address");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Demands", "address", c => c.String());
            AlterColumn("dbo.LandDemands", "maxArea", c => c.Int(nullable: false));
            AlterColumn("dbo.LandDemands", "minArea", c => c.Int(nullable: false));
            AlterColumn("dbo.HouseDemands", "maxFloors", c => c.Int(nullable: false));
            AlterColumn("dbo.HouseDemands", "minFloors", c => c.Int(nullable: false));
            AlterColumn("dbo.HouseDemands", "maxRooms", c => c.Int(nullable: false));
            AlterColumn("dbo.HouseDemands", "minRooms", c => c.Int(nullable: false));
            AlterColumn("dbo.HouseDemands", "maxArea", c => c.Int(nullable: false));
            AlterColumn("dbo.HouseDemands", "minArea", c => c.Int(nullable: false));
            AlterColumn("dbo.ApartamentDemands", "maxRooms", c => c.Int(nullable: false));
            AlterColumn("dbo.ApartamentDemands", "minRooms", c => c.Int(nullable: false));
            AlterColumn("dbo.ApartamentDemands", "maxArea", c => c.Int(nullable: false));
            AlterColumn("dbo.ApartamentDemands", "minArea", c => c.Int(nullable: false));
            DropColumn("dbo.Demands", "addressNumber");
            DropColumn("dbo.Demands", "addressHouse");
            DropColumn("dbo.Demands", "addressStreet");
            DropColumn("dbo.Demands", "addressCity");
            DropColumn("dbo.ApartamentDemands", "maxFloors");
            DropColumn("dbo.ApartamentDemands", "minFloors");
        }
    }
}
