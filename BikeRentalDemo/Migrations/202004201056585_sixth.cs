namespace BikeRentalDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sixth : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bikes", "Store_ID", c => c.Int());
            CreateIndex("dbo.Bikes", "Store_ID");
            AddForeignKey("dbo.Bikes", "Store_ID", "dbo.Stores", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bikes", "Store_ID", "dbo.Stores");
            DropIndex("dbo.Bikes", new[] { "Store_ID" });
            DropColumn("dbo.Bikes", "Store_ID");
        }
    }
}
