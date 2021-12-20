namespace eSoftDesktop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Distinct : DbMigration
    {
        public override void Up()
        {
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
            DropTable("dbo.Districts");
        }
    }
}
