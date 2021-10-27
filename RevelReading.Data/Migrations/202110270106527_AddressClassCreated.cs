namespace RevelReading.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddressClassCreated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Educator",
                c => new
                    {
                        EducatorId = c.Int(nullable: false, identity: true),
                        SchoolId = c.Int(nullable: false),
                        AddressId = c.Int(nullable: false),
                        UserPhoto = c.Binary(),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        EmailAddress = c.String(nullable: false),
                        SchoolGradeLevel = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EducatorId)
                .ForeignKey("dbo.Address", t => t.AddressId, cascadeDelete: true)
                .ForeignKey("dbo.School", t => t.SchoolId, cascadeDelete: true)
                .Index(t => t.SchoolId)
                .Index(t => t.AddressId);
            
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
            
            CreateTable(
                "dbo.Resource",
                c => new
                    {
                        ResourceId = c.Int(nullable: false, identity: true),
                        ResourceName = c.String(nullable: false),
                        Description = c.String(nullable: false, maxLength: 100),
                        DateCreatedAndDownloaded = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDownloadable = c.Boolean(nullable: false),
                        SchoolGradeLevel = c.Int(nullable: false),
                        ReadingCategory = c.String(nullable: false, maxLength: 15),
                        EducatorId = c.Int(nullable: false),
                        AccessDate = c.DateTime(nullable: false),
                        MyProperty = c.Int(nullable: false),
                        Fluency = c.Int(),
                        PhonemicAwareness = c.Int(),
                        Phonics = c.Int(),
                        Vocabulary = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ResourceId)
                .ForeignKey("dbo.Educator", t => t.EducatorId, cascadeDelete: true)
                .Index(t => t.EducatorId);
            
            CreateTable(
                "dbo.School",
                c => new
                    {
                        SchoolId = c.Int(nullable: false, identity: true),
                        SchoolName = c.String(nullable: false),
                        SchoolPhoto = c.Binary(),
                        SchoolGradeLevels = c.String(),
                        LowestGradeLevel = c.String(),
                        HighestGradeLevel = c.Int(nullable: false),
                        DistrictId = c.Int(nullable: false),
                        AddressId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SchoolId)
                .ForeignKey("dbo.Address", t => t.AddressId, cascadeDelete: false)
                .ForeignKey("dbo.District", t => t.DistrictId, cascadeDelete: true)
                .Index(t => t.DistrictId)
                .Index(t => t.AddressId);
            
            CreateTable(
                "dbo.District",
                c => new
                    {
                        DistrictId = c.Int(nullable: false, identity: true),
                        DistrictName = c.String(nullable: false),
                        AddressId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DistrictId)
                .ForeignKey("dbo.Address", t => t.AddressId, cascadeDelete: false)
                .Index(t => t.AddressId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Educator", "SchoolId", "dbo.School");
            DropForeignKey("dbo.School", "DistrictId", "dbo.District");
            DropForeignKey("dbo.District", "AddressId", "dbo.Address");
            DropForeignKey("dbo.School", "AddressId", "dbo.Address");
            DropForeignKey("dbo.Resource", "EducatorId", "dbo.Educator");
            DropForeignKey("dbo.Educator", "AddressId", "dbo.Address");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.District", new[] { "AddressId" });
            DropIndex("dbo.School", new[] { "AddressId" });
            DropIndex("dbo.School", new[] { "DistrictId" });
            DropIndex("dbo.Resource", new[] { "EducatorId" });
            DropIndex("dbo.Educator", new[] { "AddressId" });
            DropIndex("dbo.Educator", new[] { "SchoolId" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.District");
            DropTable("dbo.School");
            DropTable("dbo.Resource");
            DropTable("dbo.Address");
            DropTable("dbo.Educator");
        }
    }
}
