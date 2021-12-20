namespace eSoftDesktop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secondMigration : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Clients");
            DropPrimaryKey("dbo.Realtors");
            AddColumn("dbo.Clients", "clientId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Realtors", "realtorId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Clients", "lastName", c => c.String());
            AlterColumn("dbo.Realtors", "lastName", c => c.String());
            AddPrimaryKey("dbo.Clients", "clientId");
            AddPrimaryKey("dbo.Realtors", "realtorId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Realtors");
            DropPrimaryKey("dbo.Clients");
            AlterColumn("dbo.Realtors", "lastName", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Clients", "lastName", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Realtors", "realtorId");
            DropColumn("dbo.Clients", "clientId");
            AddPrimaryKey("dbo.Realtors", "lastName");
            AddPrimaryKey("dbo.Clients", "lastName");
        }
    }
}
