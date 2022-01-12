namespace eSoftDesktop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewVegas : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Supplies", "idAHL", "dbo.MainAHLs");
            DropForeignKey("dbo.Supplies", "idRealtor", "dbo.Realtors");
            DropIndex("dbo.Supplies", new[] { "idRealtor" });
            DropIndex("dbo.Supplies", new[] { "idAHL" });
            DropIndex("dbo.Deals", new[] { "idDemand" });
            DropIndex("dbo.Deals", new[] { "idSupply" });
            AddColumn("dbo.Demands", "Supply_idSupply", c => c.Int());
            AddColumn("dbo.Demands", "Demand_idDemand", c => c.Int());
            AlterColumn("dbo.Supplies", "idRealtor", c => c.Int(nullable: false));
            AlterColumn("dbo.Supplies", "idAHL", c => c.Int(nullable: false));
            CreateIndex("dbo.Demands", "Supply_idSupply");
            CreateIndex("dbo.Demands", "Demand_idDemand");
            CreateIndex("dbo.Supplies", "idRealtor");
            CreateIndex("dbo.Supplies", "idAHL");
            CreateIndex("dbo.Deals", "IdDemand");
            CreateIndex("dbo.Deals", "IdSupply");
            AddForeignKey("dbo.Demands", "Supply_idSupply", "dbo.Supplies", "idSupply");
            AddForeignKey("dbo.Demands", "Demand_idDemand", "dbo.Demands", "idDemand");
            AddForeignKey("dbo.Supplies", "idAHL", "dbo.MainAHLs", "idAHL", cascadeDelete: true);
            AddForeignKey("dbo.Supplies", "idRealtor", "dbo.Realtors", "idRealtor", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Supplies", "idRealtor", "dbo.Realtors");
            DropForeignKey("dbo.Supplies", "idAHL", "dbo.MainAHLs");
            DropForeignKey("dbo.Demands", "Demand_idDemand", "dbo.Demands");
            DropForeignKey("dbo.Demands", "Supply_idSupply", "dbo.Supplies");
            DropIndex("dbo.Deals", new[] { "IdSupply" });
            DropIndex("dbo.Deals", new[] { "IdDemand" });
            DropIndex("dbo.Supplies", new[] { "idAHL" });
            DropIndex("dbo.Supplies", new[] { "idRealtor" });
            DropIndex("dbo.Demands", new[] { "Demand_idDemand" });
            DropIndex("dbo.Demands", new[] { "Supply_idSupply" });
            AlterColumn("dbo.Supplies", "idAHL", c => c.Int());
            AlterColumn("dbo.Supplies", "idRealtor", c => c.Int());
            DropColumn("dbo.Demands", "Demand_idDemand");
            DropColumn("dbo.Demands", "Supply_idSupply");
            CreateIndex("dbo.Deals", "idSupply");
            CreateIndex("dbo.Deals", "idDemand");
            CreateIndex("dbo.Supplies", "idAHL");
            CreateIndex("dbo.Supplies", "idRealtor");
            AddForeignKey("dbo.Supplies", "idRealtor", "dbo.Realtors", "idRealtor");
            AddForeignKey("dbo.Supplies", "idAHL", "dbo.MainAHLs", "idAHL");
        }
    }
}
