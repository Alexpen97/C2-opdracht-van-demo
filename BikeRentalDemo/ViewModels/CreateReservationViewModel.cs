﻿using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Windows;
using BikeRentalDemo.Model;
using BikeRentalDemo.Classes;
using BikeRentalDemo.ViewModels;
using System.Collections.Generic;

namespace BikeRentalDemo.ViewModels
{
    class CreateReservationViewModel
    {
        private BikeRentalDBModel Db;
        public ObservableCollection<Bike> Bikes { get; set; } 
        public ObservableCollection<Store> Stores { get; set; }
        public ObservableCollection<Reservation> Reservations { get; set; }
        public IList<Bike> BikesList { get; set; }

        public Reservation Reservation;

        public Store DropOffStore { get; set; }
        public Store PickUpStore { get; set; }
        public Bike SelectedBike { get; set; }
       
        public DateTime EndDate { get; set; }
        public DateTime StartDate { get; set; }

        public RelayCommand CreateReservationClick { get; set; }

        public CreateReservationViewModel(Reservation res,BikeRentalDBModel db)
        {
            Db = db;
            CreateReservationClick = new RelayCommand(CreateReservation);
            Reservation = res;
            Db.Bikes.Load();
            Db.Stores.Load();
            Db.Reservations.Load();


            Bikes = Db.Bikes.Local;
            Stores = Db.Stores.Local;
            Reservations = Db.Reservations.Local;
        }

        private void CreateReservation(object o)
        {
            Reservation.DropOff = DropOffStore;
            Reservation.PickUp = PickUpStore;
            Reservation.StartDate = new DateTime(StartDate.ToShortDateString);
            Reservation.EndDate = new DateTime(2015, 11, 25);
            Reservation.Bikes = BikesList;

            Db.Reservations.Add(Reservation);
            Db.SaveChanges();


        }

    }
}
