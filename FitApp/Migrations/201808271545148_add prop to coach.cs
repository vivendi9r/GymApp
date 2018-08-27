namespace FitApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addproptocoach : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Coaches", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Coaches", "Name");
        }
    }
}
