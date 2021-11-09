namespace RevelReading.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Educator", "SchoolId", "dbo.School");
            DropIndex("dbo.Educator", new[] { "SchoolId" });
            RenameColumn(table: "dbo.Educator", name: "SchoolId", newName: "School_SchoolId");
            AlterColumn("dbo.Educator", "School_SchoolId", c => c.Int());
            CreateIndex("dbo.Educator", "School_SchoolId");
            AddForeignKey("dbo.Educator", "School_SchoolId", "dbo.School", "SchoolId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Educator", "School_SchoolId", "dbo.School");
            DropIndex("dbo.Educator", new[] { "School_SchoolId" });
            AlterColumn("dbo.Educator", "School_SchoolId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Educator", name: "School_SchoolId", newName: "SchoolId");
            CreateIndex("dbo.Educator", "SchoolId");
            AddForeignKey("dbo.Educator", "SchoolId", "dbo.School", "SchoolId", cascadeDelete: true);
        }
    }
}
