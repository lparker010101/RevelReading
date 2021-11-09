namespace RevelReading.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.School", "DistrictId", "dbo.District");
            DropIndex("dbo.School", new[] { "DistrictId" });
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
            
            AddColumn("dbo.School", "OwnerId", c => c.Guid(nullable: false));
            AddColumn("dbo.School", "EducatorId", c => c.Int(nullable: false));
            AddColumn("dbo.School", "Address_AddressId", c => c.Int());
            AlterColumn("dbo.School", "HighestGradeLevel", c => c.String());
            CreateIndex("dbo.School", "Address_AddressId");
            AddForeignKey("dbo.School", "Address_AddressId", "dbo.Address", "AddressId");
            DropColumn("dbo.School", "DistrictId");
            DropTable("dbo.District");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.District",
                c => new
                    {
                        DistrictId = c.Int(nullable: false, identity: true),
                        DistrictName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.DistrictId);
            
            AddColumn("dbo.School", "DistrictId", c => c.Int(nullable: false));
            DropForeignKey("dbo.School", "Address_AddressId", "dbo.Address");
            DropIndex("dbo.School", new[] { "Address_AddressId" });
            AlterColumn("dbo.School", "HighestGradeLevel", c => c.Int(nullable: false));
            DropColumn("dbo.School", "Address_AddressId");
            DropColumn("dbo.School", "EducatorId");
            DropColumn("dbo.School", "OwnerId");
            DropTable("dbo.Address");
            CreateIndex("dbo.School", "DistrictId");
            AddForeignKey("dbo.School", "DistrictId", "dbo.District", "DistrictId", cascadeDelete: true);
        }
    }
}
