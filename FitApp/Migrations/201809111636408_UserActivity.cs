namespace FitApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserActivity : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ActivityUsers", "UserId");
            AddColumn("dbo.ActivityUsers", "UserId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DownloadTokens", "UserId");
            AddColumn("dbo.DownloadTokens", "UserId", c => c.Int(nullable: false));

        }
    }
}
