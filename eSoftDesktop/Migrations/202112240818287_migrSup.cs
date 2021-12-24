namespace eSoftDesktop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrSup : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Supplies", "idAHL", "dbo.MainAHLs");
            DropForeignKey("dbo.Supplies", "idRealtor", "dbo.Realtors");
            DropIndex("dbo.Supplies", new[] { "idRealtor" });
            DropIndex("dbo.Supplies", new[] { "idAHL" });
            AlterColumn("dbo.Supplies", "idRealtor", c => c.Int());
            AlterColumn("dbo.Supplies", "idAHL", c => c.Int());
            CreateIndex("dbo.Supplies", "idRealtor");
            CreateIndex("dbo.Supplies", "idAHL");
            AddForeignKey("dbo.Supplies", "idAHL", "dbo.MainAHLs", "idAHL");
            AddForeignKey("dbo.Supplies", "idRealtor", "dbo.Realtors", "idRealtor");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Supplies", "idRealtor", "dbo.Realtors");
            DropForeignKey("dbo.Supplies", "idAHL", "dbo.MainAHLs");
            DropIndex("dbo.Supplies", new[] { "idAHL" });
            DropIndex("dbo.Supplies", new[] { "idRealtor" });
            AlterColumn("dbo.Supplies", "idAHL", c => c.Int(nullable: false));
            AlterColumn("dbo.Supplies", "idRealtor", c => c.Int(nullable: false));
            CreateIndex("dbo.Supplies", "idAHL");
            CreateIndex("dbo.Supplies", "idRealtor");
            AddForeignKey("dbo.Supplies", "idRealtor", "dbo.Realtors", "idRealtor", cascadeDelete: true);
            AddForeignKey("dbo.Supplies", "idAHL", "dbo.MainAHLs", "idAHL", cascadeDelete: true);
        }
    }
}
