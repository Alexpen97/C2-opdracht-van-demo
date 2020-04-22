namespace BikeRentalDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addinstoreID : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bikes", "InStore_ID", "dbo.Stores");
            DropIndex("dbo.Bikes", new[] { "InStore_ID" });
            RenameColumn(table: "dbo.Bikes", name: "InStore_ID", newName: "InStoreID");
            AlterColumn("dbo.Bikes", "InStoreID", c => c.Int(nullable: false,defaultValue:1));
            CreateIndex("dbo.Bikes", "InStoreID");
            AddForeignKey("dbo.Bikes", "InStoreID", "dbo.Stores", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bikes", "InStoreID", "dbo.Stores");
            DropIndex("dbo.Bikes", new[] { "InStoreID" });
            AlterColumn("dbo.Bikes", "InStoreID", c => c.Int());
            RenameColumn(table: "dbo.Bikes", name: "InStoreID", newName: "InStore_ID");
            CreateIndex("dbo.Bikes", "InStore_ID");
            AddForeignKey("dbo.Bikes", "InStore_ID", "dbo.Stores", "ID");
        }
    }
}
