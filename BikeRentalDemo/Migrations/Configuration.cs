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
                new Model.Store {ID = 1, Address = "testadress1", City = "testcity1", Bikes = new System.Collections.ObjectModel.ObservableCollection<Model.Bike> {
                new Model.Bike { ID = 1 , Brand = "coolbrand", DailyRate = 10, HourRate = 10 , Gender = Model.BikeGender.Male, Size = Model.BikeSize.Large, Type = Model.BikeType.Flaafy},
                new Model.Bike { ID = 2 , Brand = "coolbrand2", DailyRate = 10, HourRate = 10 , Gender = Model.BikeGender.Grandpa, Size = Model.BikeSize.Small, Type = Model.BikeType.Pikachu},
                new Model.Bike { ID = 3 , Brand = "coolbrand3", DailyRate = 10, HourRate = 10 , Gender = Model.BikeGender.Grandma, Size = Model.BikeSize.Medium, Type = Model.BikeType.Starly}
                } },
                 new Model.Store { Address = "testadress1", City = "testcity1", ID = 1, Bikes = new System.Collections.ObjectModel.ObservableCollection<Model.Bike> { } }
                );
            context.Customers.AddOrUpdate(
                new Model.Customer {ID=1, Email = "testemail1", gender = Model.Customer.CustomerGender.Female, Height = 14, Name="testname1"},
                new Model.Customer { ID = 2, Email = "testemail2", gender = Model.Customer.CustomerGender.Female, Height = 14, Name = "testname2" },
                new Model.Customer { ID = 3, Email = "testemail3", gender = Model.Customer.CustomerGender.Female, Height = 14, Name = "testname3" }
                );
        }
    }
}
