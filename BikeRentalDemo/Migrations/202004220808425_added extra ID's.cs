namespace BikeRentalDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedextraIDs : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bikes", "InStore_ID", "dbo.Stores");
            DropForeignKey("dbo.Reservations", "Bike_ID", "dbo.Bikes");
            DropForeignKey("dbo.Reservations", "Customer_ID", "dbo.Customers");
            DropIndex("dbo.Bikes", new[] { "InStore_ID" });
            DropIndex("dbo.Reservations", new[] { "Bike_ID" });
            DropIndex("dbo.Reservations", new[] { "Customer_ID" });
            RenameColumn(table: "dbo.Bikes", name: "InStore_ID", newName: "InStoreID");
            RenameColumn(table: "dbo.Reservations", name: "Bike_ID", newName: "BikeID");
            RenameColumn(table: "dbo.Reservations", name: "Customer_ID", newName: "CustomerID");
            AlterColumn("dbo.Bikes", "InStoreID", c => c.Int(nullable: false, defaultValueSql:"1"));
            AlterColumn("dbo.Reservations", "BikeID", c => c.Int(nullable: false));
            AlterColumn("dbo.Reservations", "CustomerID", c => c.Int(nullable: false));
            CreateIndex("dbo.Bikes", "InStoreID");
            CreateIndex("dbo.Reservations", "CustomerID");
            CreateIndex("dbo.Reservations", "BikeID");
            AddForeignKey("dbo.Bikes", "InStoreID", "dbo.Stores", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Reservations", "BikeID", "dbo.Bikes", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Reservations", "CustomerID", "dbo.Customers", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservations", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Reservations", "BikeID", "dbo.Bikes");
            DropForeignKey("dbo.Bikes", "InStoreID", "dbo.Stores");
            DropIndex("dbo.Reservations", new[] { "BikeID" });
            DropIndex("dbo.Reservations", new[] { "CustomerID" });
            DropIndex("dbo.Bikes", new[] { "InStoreID" });
            AlterColumn("dbo.Reservations", "CustomerID", c => c.Int());
            AlterColumn("dbo.Reservations", "BikeID", c => c.Int());
            AlterColumn("dbo.Bikes", "InStoreID", c => c.Int());
            RenameColumn(table: "dbo.Reservations", name: "CustomerID", newName: "Customer_ID");
            RenameColumn(table: "dbo.Reservations", name: "BikeID", newName: "Bike_ID");
            RenameColumn(table: "dbo.Bikes", name: "InStoreID", newName: "InStore_ID");
            CreateIndex("dbo.Reservations", "Customer_ID");
            CreateIndex("dbo.Reservations", "Bike_ID");
            CreateIndex("dbo.Bikes", "InStore_ID");
            AddForeignKey("dbo.Reservations", "Customer_ID", "dbo.Customers", "ID");
            AddForeignKey("dbo.Reservations", "Bike_ID", "dbo.Bikes", "ID");
            AddForeignKey("dbo.Bikes", "InStore_ID", "dbo.Stores", "ID");
        }
    }
}
