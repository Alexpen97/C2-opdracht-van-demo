using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Windows;
using BikeRentalDemo.Model;
using BikeRentalDemo.Classes;
using BikeRentalDemo.ViewModels;


namespace BikeRentalDemo.ViewModels
{
    class BikesEditViewModel
    {
        private BikeRentalDBModel Db;
        public ObservableCollection<Bike> Bikes { get; set; }
        public RelayCommand SaveClick { get; set; }
        public RelayCommand CreateBike { get; set; }
        public RelayCommand DeleteBike { get; set; }
        public Store store { get; set; }
        public Bike SelectedBike { get; set; }

        public BikesEditViewModel(BikeRentalDBModel db,ObservableCollection<Bike> bikes,Store currentstore)
        {
            Db = db;
            Bikes = bikes;
            store = currentstore;
            SaveClick = new RelayCommand(x => db.SaveChanges());
            CreateBike = new RelayCommand(CreateNewBike);
            DeleteBike = new RelayCommand(Delete);

            
        }
        public void CreateNewBike(Object O)
        {
            Bike newBike = new Bike();
            newBike.InStore = store;
            newBike.InStoreID = store.ID;
            Db.Bikes.Add(newBike);
            Bikes.Add(newBike);
            Db.SaveChanges();
          

        }
        public void Delete(Object o)
        {
            Db.Bikes.Remove(Db.Bikes.Find(SelectedBike.ID));
            Bikes.Remove(SelectedBike);
            Db.SaveChanges();
           
        }
    }
}
