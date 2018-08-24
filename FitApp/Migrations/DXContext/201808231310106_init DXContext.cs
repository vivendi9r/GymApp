namespace FitApp.Migrations.DXContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initDXContext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activities",
                c => new
                    {
                        ActivityId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Start_time = c.DateTime(nullable: false),
                        End_time = c.DateTime(nullable: false),
                        RoomId = c.Int(nullable: false),
                        CoachId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ActivityId);
            
            CreateTable(
                "dbo.ActivityUsers",
                c => new
                    {
                        ActivitiesUsersId = c.Int(nullable: false, identity: true),
                        ActivityId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ActivitiesUsersId);
            
            CreateTable(
                "dbo.Coaches",
                c => new
                    {
                        CoachId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CoachId);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        RoomId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.RoomId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Rooms");
            DropTable("dbo.Coaches");
            DropTable("dbo.ActivityUsers");
            DropTable("dbo.Activities");
        }
    }
}
