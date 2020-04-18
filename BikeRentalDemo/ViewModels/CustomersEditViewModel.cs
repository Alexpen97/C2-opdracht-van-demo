using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Windows;
using BikeRentalDemo.Model;
using BikeRentalDemo.Classes;
using BikeRentalDemo.ViewModels;

namespace BikeRentalDemo.ViewModels
{
    class CustomersEditViewModel
    {
        private BikeRentalDBModel Db;
        public ObservableCollection<Customer> Customers { get; set; }
        public RelayCommand SaveClick { get; set; }
    public CustomersEditViewModel(BikeRentalDBModel db)
        {
            Db = db;
            Customers = Db.Customers.Local;
            SaveClick = new RelayCommand(x => Db.SaveChanges());
        }
    }

}
