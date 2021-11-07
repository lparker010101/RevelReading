namespace RevelReading.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TodaysMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Educator", "OwnerId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Educator", "OwnerId");
        }
    }
}
