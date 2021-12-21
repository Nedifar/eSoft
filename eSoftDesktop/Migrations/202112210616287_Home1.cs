namespace eSoftDesktop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Home1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Apartaments", "adressCity", c => c.String());
            AddColumn("dbo.Houses", "adressCity", c => c.String());
            AddColumn("dbo.Lands", "adressCity", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Lands", "adressCity");
            DropColumn("dbo.Houses", "adressCity");
            DropColumn("dbo.Apartaments", "adressCity");
        }
    }
}
