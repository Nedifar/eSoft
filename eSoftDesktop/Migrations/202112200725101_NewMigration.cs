namespace eSoftDesktop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        lastName = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        middleName = c.String(),
                        Telephone = c.String(),
                        eMail = c.String(),
                    })
                .PrimaryKey(t => t.lastName);
            
            CreateTable(
                "dbo.Realtors",
                c => new
                    {
                        lastName = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        middleName = c.String(),
                        comissionPart = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.lastName);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Realtors");
            DropTable("dbo.Clients");
        }
    }
}
