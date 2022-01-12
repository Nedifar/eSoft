namespace eSoftDesktop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nn : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Demands", "Supply_idSupply", "dbo.Supplies");
            DropForeignKey("dbo.Demands", "Demand_idDemand", "dbo.Demands");
            DropIndex("dbo.Demands", new[] { "Supply_idSupply" });
            DropIndex("dbo.Demands", new[] { "Demand_idDemand" });
            DropColumn("dbo.Demands", "Supply_idSupply");
            DropColumn("dbo.Demands", "Demand_idDemand");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Demands", "Demand_idDemand", c => c.Int());
            AddColumn("dbo.Demands", "Supply_idSupply", c => c.Int());
            CreateIndex("dbo.Demands", "Demand_idDemand");
            CreateIndex("dbo.Demands", "Supply_idSupply");
            AddForeignKey("dbo.Demands", "Demand_idDemand", "dbo.Demands", "idDemand");
            AddForeignKey("dbo.Demands", "Supply_idSupply", "dbo.Supplies", "idSupply");
        }
    }
}
