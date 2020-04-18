namespace BikeRentalDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        gender = c.Int(nullable: false),
                        Height = c.Double(nullable: false),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Customer_ID = c.Int(),
                        DropOff_id = c.Int(),
                        PickUp_id = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Customers", t => t.Customer_ID)
                .ForeignKey("dbo.Stores", t => t.DropOff_id)
                .ForeignKey("dbo.Stores", t => t.PickUp_id)
                .Index(t => t.Customer_ID)
                .Index(t => t.DropOff_id)
                .Index(t => t.PickUp_id);
            
            AddColumn("dbo.Bikes", "Reservation_ID", c => c.Int());
            CreateIndex("dbo.Bikes", "Reservation_ID");
            AddForeignKey("dbo.Bikes", "Reservation_ID", "dbo.Reservations", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservations", "PickUp_id", "dbo.Stores");
            DropForeignKey("dbo.Reservations", "DropOff_id", "dbo.Stores");
            DropForeignKey("dbo.Reservations", "Customer_ID", "dbo.Customers");
            DropForeignKey("dbo.Bikes", "Reservation_ID", "dbo.Reservations");
            DropIndex("dbo.Reservations", new[] { "PickUp_id" });
            DropIndex("dbo.Reservations", new[] { "DropOff_id" });
            DropIndex("dbo.Reservations", new[] { "Customer_ID" });
            DropIndex("dbo.Bikes", new[] { "Reservation_ID" });
            DropColumn("dbo.Bikes", "Reservation_ID");
            DropTable("dbo.Reservations");
            DropTable("dbo.Customers");
        }
    }
}
