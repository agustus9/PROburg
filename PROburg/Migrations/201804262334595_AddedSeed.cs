namespace PROburg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSeed : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.EventAttendees", newName: "EventsAttendees");
            RenameColumn(table: "dbo.EventsAttendees", name: "Event_Id", newName: "Events_Id");
            RenameIndex(table: "dbo.EventsAttendees", name: "IX_Event_Id", newName: "IX_Events_Id");
            AlterColumn("dbo.Events", "AgeLimit", c => c.Int());
            AlterColumn("dbo.Events", "Price", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Events", "Price", c => c.Double(nullable: false));
            AlterColumn("dbo.Events", "AgeLimit", c => c.Int(nullable: false));
            RenameIndex(table: "dbo.EventsAttendees", name: "IX_Events_Id", newName: "IX_Event_Id");
            RenameColumn(table: "dbo.EventsAttendees", name: "Events_Id", newName: "Event_Id");
            RenameTable(name: "dbo.EventsAttendees", newName: "EventAttendees");
        }
    }
}
