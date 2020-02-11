namespace CinemAPI.Data.EF
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ObjectBigBang : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservations", "MovieId", c => c.Int(nullable: false));
            AddColumn("dbo.Reservations", "RoomId", c => c.Int(nullable: false));
            AddColumn("dbo.Tickets", "MovieId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tickets", "MovieId");
            DropColumn("dbo.Reservations", "RoomId");
            DropColumn("dbo.Reservations", "MovieId");
        }
    }
}
