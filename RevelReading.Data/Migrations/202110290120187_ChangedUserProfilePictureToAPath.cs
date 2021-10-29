namespace RevelReading.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedUserProfilePictureToAPath : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Educator", "UserPhotoImagePath", c => c.String());
            AddColumn("dbo.School", "SchoolImagePath", c => c.String());
            DropColumn("dbo.Educator", "UserPhoto");
            DropColumn("dbo.School", "SchoolPhoto");
        }
        
        public override void Down()
        {
            AddColumn("dbo.School", "SchoolPhoto", c => c.Binary());
            AddColumn("dbo.Educator", "UserPhoto", c => c.Binary());
            DropColumn("dbo.School", "SchoolImagePath");
            DropColumn("dbo.Educator", "UserPhotoImagePath");
        }
    }
}
