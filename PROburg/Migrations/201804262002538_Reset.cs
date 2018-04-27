namespace PROburg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Reset : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Tagline = c.String(),
                        LongDescription = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zip = c.Int(nullable: false),
                        AgeLimit = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        DateHappening = c.DateTime(nullable: false),
                        CityId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EventAttendees",
                c => new
                    {
                        Event_Id = c.Int(nullable: false),
                        Attendee_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Event_Id, t.Attendee_Id })
                .ForeignKey("dbo.Events", t => t.Event_Id, cascadeDelete: true)
                .ForeignKey("dbo.Attendees", t => t.Attendee_Id, cascadeDelete: true)
                .Index(t => t.Event_Id)
                .Index(t => t.Attendee_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "CityId", "dbo.Cities");
            DropForeignKey("dbo.EventAttendees", "Attendee_Id", "dbo.Attendees");
            DropForeignKey("dbo.EventAttendees", "Event_Id", "dbo.Events");
            DropIndex("dbo.EventAttendees", new[] { "Attendee_Id" });
            DropIndex("dbo.EventAttendees", new[] { "Event_Id" });
            DropIndex("dbo.Events", new[] { "CityId" });
            DropTable("dbo.EventAttendees");
            DropTable("dbo.Cities");
            DropTable("dbo.Events");
            DropTable("dbo.Attendees");
        }
    }
}
