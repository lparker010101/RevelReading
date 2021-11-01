namespace RevelReading.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedStringToIntOnIds : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Resource", "ModifiedResource", c => c.DateTimeOffset(precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Resource", "ModifiedResource");
        }
    }
}
