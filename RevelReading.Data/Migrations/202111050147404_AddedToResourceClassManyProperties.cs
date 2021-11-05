namespace RevelReading.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedToResourceClassManyProperties : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Resource", "Educator_EducatorId", "dbo.Educator");
            DropIndex("dbo.Resource", new[] { "Educator_EducatorId" });
            RenameColumn(table: "dbo.Resource", name: "Educator_EducatorId", newName: "EducatorId");
            AddColumn("dbo.Resource", "ResourceName", c => c.String(nullable: false));
            AddColumn("dbo.Resource", "Description", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Resource", "DateCreatedAndDownloaded", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Resource", "ModifiedResource", c => c.DateTimeOffset(precision: 7));
            AddColumn("dbo.Resource", "IsDownloadable", c => c.Boolean(nullable: false));
            AddColumn("dbo.Resource", "SchoolGradeLevel", c => c.String());
            AddColumn("dbo.Resource", "ReadingCategory", c => c.String(nullable: false, maxLength: 15));
            AddColumn("dbo.Resource", "AccessDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Resource", "EducatorId", c => c.Int(nullable: false));
            CreateIndex("dbo.Resource", "EducatorId");
            AddForeignKey("dbo.Resource", "EducatorId", "dbo.Educator", "EducatorId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Resource", "EducatorId", "dbo.Educator");
            DropIndex("dbo.Resource", new[] { "EducatorId" });
            AlterColumn("dbo.Resource", "EducatorId", c => c.Int());
            DropColumn("dbo.Resource", "AccessDate");
            DropColumn("dbo.Resource", "ReadingCategory");
            DropColumn("dbo.Resource", "SchoolGradeLevel");
            DropColumn("dbo.Resource", "IsDownloadable");
            DropColumn("dbo.Resource", "ModifiedResource");
            DropColumn("dbo.Resource", "DateCreatedAndDownloaded");
            DropColumn("dbo.Resource", "Description");
            DropColumn("dbo.Resource", "ResourceName");
            RenameColumn(table: "dbo.Resource", name: "EducatorId", newName: "Educator_EducatorId");
            CreateIndex("dbo.Resource", "Educator_EducatorId");
            AddForeignKey("dbo.Resource", "Educator_EducatorId", "dbo.Educator", "EducatorId");
        }
    }
}
