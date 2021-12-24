namespace eSoftDesktop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class d : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Deals",
                c => new
                    {
                        idDeal = c.Int(nullable: false, identity: true),
                        idDemand = c.Int(nullable: false),
                        idSupply = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idDeal)
                .ForeignKey("dbo.Demands", t => t.idDemand, cascadeDelete: false)
                .ForeignKey("dbo.Supplies", t => t.idSupply, cascadeDelete: false)
                .Index(t => t.idDemand)
                .Index(t => t.idSupply);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Deals", "idSupply", "dbo.Supplies");
            DropForeignKey("dbo.Deals", "idDemand", "dbo.Demands");
            DropIndex("dbo.Deals", new[] { "idSupply" });
            DropIndex("dbo.Deals", new[] { "idDemand" });
            DropTable("dbo.Deals");
        }
    }
}
