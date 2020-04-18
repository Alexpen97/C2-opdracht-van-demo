using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Windows;
using BikeRentalDemo.Model;
using BikeRentalDemo.Classes;

namespace BikeRentalDemo.ViewModels
{
    class StoresEditViewModel
    {
        private BikeRentalDBModel Db;
        public ObservableCollection<Store> Stores { get; set; }
        public RelayCommand SaveClick { get; set; }

        public StoresEditViewModel(BikeRentalDBModel db)
        {
            Db = db;
            Stores = Db.Stores.Local;
            SaveClick = new RelayCommand(x => Db.SaveChanges());

        }
    }
}
