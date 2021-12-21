namespace eSoftDesktop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Home2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Houses", "Rooms");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Houses", "Rooms", c => c.Int(nullable: false));
        }
    }
}
