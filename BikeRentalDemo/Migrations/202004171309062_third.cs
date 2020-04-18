namespace BikeRentalDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class third : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bikes", "InStore_id", "dbo.Stores");
            DropIndex("dbo.Bikes", new[] { "InStore_id" });
            DropIndex("dbo.Reservations", new[] { "DropOff_id" });
            DropIndex("dbo.Reservations", new[] { "PickUp_id" });
            AddColumn("dbo.Bikes", "HourRate", c => c.Double(nullable: false));
            AddColumn("dbo.Bikes", "DailyRate", c => c.Double(nullable: false));
            CreateIndex("dbo.Reservations", "DropOff_ID");
            CreateIndex("dbo.Reservations", "PickUp_ID");
            DropColumn("dbo.Bikes", "Rented");
            DropColumn("dbo.Bikes", "InStore_id");
            DropColumn("dbo.Stores", "Name");
            DropColumn("dbo.Stores", "MaxCapacity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Stores", "MaxCapacity", c => c.Int(nullable: false));
            AddColumn("dbo.Stores", "Name", c => c.String());
            AddColumn("dbo.Bikes", "InStore_id", c => c.Int());
            AddColumn("dbo.Bikes", "Rented", c => c.Boolean(nullable: false));
            DropIndex("dbo.Reservations", new[] { "PickUp_ID" });
            DropIndex("dbo.Reservations", new[] { "DropOff_ID" });
            DropColumn("dbo.Bikes", "DailyRate");
            DropColumn("dbo.Bikes", "HourRate");
            CreateIndex("dbo.Reservations", "PickUp_id");
            CreateIndex("dbo.Reservations", "DropOff_id");
            CreateIndex("dbo.Bikes", "InStore_id");
            AddForeignKey("dbo.Bikes", "InStore_id", "dbo.Stores", "id");
        }
    }
}
