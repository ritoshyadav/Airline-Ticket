namespace AirLine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ne : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Username = c.String(),
                        password = c.String(),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        bookingId = c.Int(nullable: false, identity: true),
                        SeatType = c.String(),
                        DayofJry = c.DateTime(nullable: false),
                        Amt = c.Double(nullable: false),
                        FlightId_FlightId = c.Int(),
                        UserID_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.bookingId)
                .ForeignKey("dbo.Flights", t => t.FlightId_FlightId)
                .ForeignKey("dbo.Users", t => t.UserID_UserID)
                .Index(t => t.FlightId_FlightId)
                .Index(t => t.UserID_UserID);
            
            CreateTable(
                "dbo.Flights",
                c => new
                    {
                        FlightId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Day = c.Int(nullable: false),
                        Seat = c.Int(nullable: false),
                        Source = c.String(),
                        Destination = c.String(),
                        Distance = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FlightId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Contact = c.String(),
                        Address = c.String(),
                        Gender = c.String(),
                        Email = c.String(),
                        Username = c.String(),
                        password = c.String(),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "UserID_UserID", "dbo.Users");
            DropForeignKey("dbo.Bookings", "FlightId_FlightId", "dbo.Flights");
            DropIndex("dbo.Bookings", new[] { "UserID_UserID" });
            DropIndex("dbo.Bookings", new[] { "FlightId_FlightId" });
            DropTable("dbo.Users");
            DropTable("dbo.Flights");
            DropTable("dbo.Bookings");
            DropTable("dbo.Admins");
        }
    }
}
