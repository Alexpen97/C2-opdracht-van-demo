namespace BikeRentalDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bikes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Size = c.Int(nullable: false),
                        Brand = c.String(),
                        Type = c.Int(nullable: false),
                        Gender = c.Int(nullable: false),
                        Rented = c.Boolean(nullable: false),
                        InStore_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Stores", t => t.InStore_id)
                .Index(t => t.InStore_id);
            
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        MaxCapacity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bikes", "InStore_id", "dbo.Stores");
            DropIndex("dbo.Bikes", new[] { "InStore_id" });
            DropTable("dbo.Stores");
            DropTable("dbo.Bikes");
        }
    }
}
