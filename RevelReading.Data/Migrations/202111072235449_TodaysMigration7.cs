namespace RevelReading.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TodaysMigration7 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Educator", "AddressId", "dbo.Address");
            DropForeignKey("dbo.School", "AddressId", "dbo.Address");
            DropForeignKey("dbo.District", "AddressId", "dbo.Address");
            DropIndex("dbo.Educator", new[] { "AddressId" });
            DropIndex("dbo.School", new[] { "AddressId" });
            DropIndex("dbo.District", new[] { "AddressId" });
            DropColumn("dbo.Educator", "AddressId");
            DropColumn("dbo.School", "AddressId");
            DropColumn("dbo.District", "AddressId");
            DropTable("dbo.Address");
        }
        
        public override void Down()
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
            
            AddColumn("dbo.District", "AddressId", c => c.Int(nullable: false));
            AddColumn("dbo.School", "AddressId", c => c.Int(nullable: false));
            AddColumn("dbo.Educator", "AddressId", c => c.Int(nullable: false));
            CreateIndex("dbo.District", "AddressId");
            CreateIndex("dbo.School", "AddressId");
            CreateIndex("dbo.Educator", "AddressId");
            AddForeignKey("dbo.District", "AddressId", "dbo.Address", "AddressId", cascadeDelete: true);
            AddForeignKey("dbo.School", "AddressId", "dbo.Address", "AddressId", cascadeDelete: true);
            AddForeignKey("dbo.Educator", "AddressId", "dbo.Address", "AddressId", cascadeDelete: true);
        }
    }
}
