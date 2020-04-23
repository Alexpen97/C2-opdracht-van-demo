namespace BikeRentalDemo.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

   

    internal sealed class Configuration : DbMigrationsConfiguration<BikeRentalDemo.Model.BikeRentalDBModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BikeRentalDemo.Model.BikeRentalDBModel context)
        {
            context.Stores.AddOrUpdate(
                new Model.Store { ID = 1, Address = "testadress1", City = "testcity1" },
                 new Model.Store { Address = "testadress1", City = "testcity1", ID = 2 }
                );
            context.Customers.AddOrUpdate(
                new Model.Customer { ID = 1, Email = "testemail1", gender = Model.Customer.CustomerGender.Female, Height = 14, Name = "testname1" },
                new Model.Customer { ID = 2, Email = "testemail2", gender = Model.Customer.CustomerGender.Female, Height = 14, Name = "testname2" },
                new Model.Customer { ID = 3, Email = "testemail3", gender = Model.Customer.CustomerGender.Female, Height = 14, Name = "testname3" }
                );
            context.Bikes.AddOrUpdate(
                new Model.Bike { ID = 1, Brand = "testbrand", DailyRate = 10, HourRate = 10, Gender = Model.BikeGender.Female, Size = Model.BikeSize.Large, Type = Model.BikeType.Flaafy, InStore = context.Stores.Find(1), InStoreID = 1 },
                new Model.Bike { ID = 2, Brand = "testbrand", DailyRate = 10, HourRate = 10, Gender = Model.BikeGender.Female, Size = Model.BikeSize.Large, Type = Model.BikeType.Flaafy, InStore = context.Stores.Find(1), InStoreID = 1 });
            context.Reservations.AddOrUpdate(
                new Model.Reservation { Bike = context.Bikes.Find(1), BikeID = 1, Customer = context.Customers.Find(1), CustomerID = 1, DropOff = context.Stores.Find(1), PickUp = context.Stores.Find(2), EndDate = new DateTime(2020,11,11), StartDate = new DateTime(2020,11,11), ID=1,TotalPrice=20}
                );

        }
    }
}
