namespace RevelReading.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesMadeToTypeForGradeLevels : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Resource", "SchoolGradeLevel", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Resource", "SchoolGradeLevel", c => c.Int(nullable: false));
        }
    }
}
