using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Windows;
using BikeRentalDemo.Model;
using BikeRentalDemo.Classes;
using BikeRentalDemo.ViewModels;


namespace BikeRentalDemo.ViewModels
{
    class ReservationEditViewModel
    {
        private BikeRentalDBModel Db;
        public ObservableCollection<Reservation> Reservations { get; set; }
        public RelayCommand SaveClick { get; set; }

       public ReservationEditViewModel( BikeRentalDBModel db)
        {
            Db = db;
            Reservations = Db.Reservations.Local;
            SaveClick = new RelayCommand(x => db.SaveChanges());
        }
    }
}
