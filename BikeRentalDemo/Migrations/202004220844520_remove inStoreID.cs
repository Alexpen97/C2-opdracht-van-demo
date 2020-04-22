namespace BikeRentalDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeinStoreID : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bikes", "InStoreID", "dbo.Stores");
            DropIndex("dbo.Bikes", new[] { "InStoreID" });
            RenameColumn(table: "dbo.Bikes", name: "InStoreID", newName: "InStore_ID");
            AlterColumn("dbo.Bikes", "InStore_ID", c => c.Int());
            CreateIndex("dbo.Bikes", "InStore_ID");
            AddForeignKey("dbo.Bikes", "InStore_ID", "dbo.Stores", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bikes", "InStore_ID", "dbo.Stores");
            DropIndex("dbo.Bikes", new[] { "InStore_ID" });
            AlterColumn("dbo.Bikes", "InStore_ID", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Bikes", name: "InStore_ID", newName: "InStoreID");
            CreateIndex("dbo.Bikes", "InStoreID");
            AddForeignKey("dbo.Bikes", "InStoreID", "dbo.Stores", "ID", cascadeDelete: true);
        }
    }
}
