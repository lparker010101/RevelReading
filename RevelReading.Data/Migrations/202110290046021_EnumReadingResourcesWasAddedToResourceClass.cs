namespace RevelReading.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EnumReadingResourcesWasAddedToResourceClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Resource", "Comprehension", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Resource", "Comprehension");
        }
    }
}
