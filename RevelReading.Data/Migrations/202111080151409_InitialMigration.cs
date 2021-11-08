namespace RevelReading.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        AddressId = c.Int(nullable: false, identity: true),
                        StreetAddress = c.String(nullable: false),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        Zipcode = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.AddressId);
            
            AddColumn("dbo.Educator", "AddressId", c => c.Int(nullable: false));
            AddColumn("dbo.School", "AddressId", c => c.Int(nullable: false));
            CreateIndex("dbo.Educator", "AddressId");
            CreateIndex("dbo.School", "AddressId");
            AddForeignKey("dbo.Educator", "AddressId", "dbo.Address", "AddressId", cascadeDelete: true);
            AddForeignKey("dbo.School", "AddressId", "dbo.Address", "AddressId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.School", "AddressId", "dbo.Address");
            DropForeignKey("dbo.Educator", "AddressId", "dbo.Address");
            DropIndex("dbo.School", new[] { "AddressId" });
            DropIndex("dbo.Educator", new[] { "AddressId" });
            DropColumn("dbo.School", "AddressId");
            DropColumn("dbo.Educator", "AddressId");
            DropTable("dbo.Address");
        }
    }
}
