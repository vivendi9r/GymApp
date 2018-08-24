namespace FitApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class connections : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicationUserActivities",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        Activity_ActivityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.Activity_ActivityId })
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .ForeignKey("dbo.Activities", t => t.Activity_ActivityId, cascadeDelete: true)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.Activity_ActivityId);
            
            CreateIndex("dbo.Activities", "RoomId");
            CreateIndex("dbo.Activities", "CoachId");
            AddForeignKey("dbo.Activities", "CoachId", "dbo.Coaches", "CoachId", cascadeDelete: true);
            AddForeignKey("dbo.Activities", "RoomId", "dbo.Rooms", "RoomId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Activities", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.Activities", "CoachId", "dbo.Coaches");
            DropForeignKey("dbo.ApplicationUserActivities", "Activity_ActivityId", "dbo.Activities");
            DropForeignKey("dbo.ApplicationUserActivities", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.ApplicationUserActivities", new[] { "Activity_ActivityId" });
            DropIndex("dbo.ApplicationUserActivities", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Activities", new[] { "CoachId" });
            DropIndex("dbo.Activities", new[] { "RoomId" });
            DropTable("dbo.ApplicationUserActivities");
        }
    }
}
