namespace CinemAPI.Data.EF
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BigBang : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProjectionStartDate = c.DateTime(nullable: false),
                        MovieName = c.String(nullable: false),
                        CinemaName = c.String(nullable: false),
                        RoomNumber = c.Short(nullable: false),
                        Row = c.Short(nullable: false),
                        Column = c.Short(nullable: false),
                        ProjectionId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projections", t => t.ProjectionId, cascadeDelete: true)
                .Index(t => t.ProjectionId);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProjectionStartDate = c.DateTime(nullable: false),
                        MovieName = c.String(nullable: false),
                        CinemaName = c.String(nullable: false),
                        RoomNumber = c.Short(nullable: false),
                        Row = c.Short(nullable: false),
                        Column = c.Short(nullable: false),
                        ProjectionId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projections", t => t.ProjectionId, cascadeDelete: true)
                .Index(t => t.ProjectionId);
            
            AlterColumn("dbo.Rooms", "Number", c => c.Short(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "ProjectionId", "dbo.Projections");
            DropForeignKey("dbo.Reservations", "ProjectionId", "dbo.Projections");
            DropIndex("dbo.Tickets", new[] { "ProjectionId" });
            DropIndex("dbo.Reservations", new[] { "ProjectionId" });
            AlterColumn("dbo.Rooms", "Number", c => c.Int(nullable: false));
            DropTable("dbo.Tickets");
            DropTable("dbo.Reservations");
        }
    }
}
