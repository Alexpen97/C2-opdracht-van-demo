namespace BikeRentalDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Final : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bikes", "Reservation_ID", "dbo.Reservations");
            DropIndex("dbo.Bikes", new[] { "Reservation_ID" });
            RenameColumn(table: "dbo.Bikes", name: "Store_ID", newName: "InStore_ID");
            RenameIndex(table: "dbo.Bikes", name: "IX_Store_ID", newName: "IX_InStore_ID");
            AddColumn("dbo.Reservations", "Bike_ID", c => c.Int());
            CreateIndex("dbo.Reservations", "Bike_ID");
            AddForeignKey("dbo.Reservations", "Bike_ID", "dbo.Bikes", "ID");
            DropColumn("dbo.Bikes", "Reservation_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bikes", "Reservation_ID", c => c.Int());
            DropForeignKey("dbo.Reservations", "Bike_ID", "dbo.Bikes");
            DropIndex("dbo.Reservations", new[] { "Bike_ID" });
            DropColumn("dbo.Reservations", "Bike_ID");
            RenameIndex(table: "dbo.Bikes", name: "IX_InStore_ID", newName: "IX_Store_ID");
            RenameColumn(table: "dbo.Bikes", name: "InStore_ID", newName: "Store_ID");
            CreateIndex("dbo.Bikes", "Reservation_ID");
            AddForeignKey("dbo.Bikes", "Reservation_ID", "dbo.Reservations", "ID");
        }
    }
}
