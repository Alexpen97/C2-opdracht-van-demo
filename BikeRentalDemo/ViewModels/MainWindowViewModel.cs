using BikeRentalDemo.Classes;
using BikeRentalDemo.Model;
using BikeRentalDemo.Views;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Data.Entity;

namespace BikeRentalDemo.ViewModels
{
    public class MainWindowViewModel
    {
        private BikeRentalDBModel db = new BikeRentalDBModel();
        public ObservableCollection<Bike> Bikes { get; set; } // Een centrale lijst van alle bikes die er zijn in alle stores. (later komt dit in een database)
        public ObservableCollection<Store> Stores { get; set; } // Een centrale lijst van alle stores die er zijn. (later komt dit in een database)

        public ObservableCollection<Customer> Customers { get; set; }

        public ObservableCollection<Reservation> Reservations { get; set; }

        public Store SelectedStore { get; set; }
        public Bike SelectedBike { get; set; }
        public Customer SelectedCustomer { get; set; }
        public Reservation SelectedReservation { get; set; }


       
        public ICommand DeleteStoreClick { get; set; } // De koppeling met de Command-binding van de Delete-knoppen in het Store-overzicht
        public ICommand CreateStoreClick { get; set; } // De koppeling met de Command-binding van de "+"-knop
        public ICommand EditStoresClick { get; set; }

        public ICommand DeleteCustomerClick { get; set; }
        public ICommand EditCustomersClick { get; set; }
        public ICommand CreateCustomerClick { get; set; }

        public ICommand EditBikesClick { get; set; }
        public ICommand DeleteBikeClick { get; set; }
        public ICommand CreateBikeClick { get; set; }


        public ICommand EditReservationsClick { get; set; }
        public ICommand CreateReservationClick { get; set; }
        public ICommand DeleteReservationClick { get; set; }
             
        public MainWindowViewModel() // De constructor van de Class
        {
            db.Bikes.Load();
            db.Stores.Load();
            db.Customers.Load();
            db.Reservations.Load();
            
            Bikes = db.Bikes.Local;
            Stores = db.Stores.Local;
            Customers = db.Customers.Local;
            Reservations = db.Reservations.Local;

         
         
           
            DeleteStoreClick = new RelayCommand(DeleteStore); // met behulp van RelayCommand geven we de koppeling door aan de functie hieronder            OpenBikeAdminClick = new RelayCommand(OpenBikeAdmin); // met behulp van RelayCommand geven we de koppeling door aan de functie hieronder
            DeleteCustomerClick = new RelayCommand(DeleteCustomer);
            DeleteBikeClick = new RelayCommand(DeleteBike);
            DeleteReservationClick = new RelayCommand(DeleteReservation);

            CreateCustomerClick = new RelayCommand(CreateCustomer);
            CreateReservationClick = new RelayCommand(CreateReservation);
            CreateBikeClick = new RelayCommand(CreateBike);
            CreateStoreClick = new RelayCommand(CreateStore);

           
           
            EditCustomersClick = new RelayCommand(OpenCustomerAdmin);
            EditStoresClick = new RelayCommand(OpenStoreAdmin);
            EditBikesClick = new RelayCommand(OpenBikeAdmin);
            EditReservationsClick = new RelayCommand(OpenReservationAdmin);

        }

        public void DeleteStore(object store)
        {
            if (SelectedStore != null) { 
            db.Stores.Remove(db.Stores.Find(SelectedStore.ID));
            db.SaveChanges();
        }
        }
        public void DeleteCustomer(object customer)
        {
            if(SelectedCustomer != null) { 
            db.Customers.Remove(db.Customers.Find(SelectedCustomer.ID));
            db.SaveChanges();
         }
        }
        public void DeleteReservation(object reservation)
        {
            if(SelectedReservation != null) { 
            db.Reservations.Remove(db.Reservations.Find(SelectedReservation.ID));
            db.SaveChanges();
        }
        }
        public void DeleteBike(object bike)
        {
            if (SelectedBike != null)
            {
                db.Bikes.Remove(db.Bikes.Find(SelectedBike.ID));
                db.SaveChanges();
            }
        }
        public void CreateReservation(object o)
        {
            Reservation newReservation = new Reservation();
            newReservation.Customer = SelectedCustomer;
            newReservation.Bike = SelectedBike;
            CreateReservationViewModel VM = new CreateReservationViewModel(newReservation, db);

            CreateReservation view = new CreateReservation();
            view.DataContext = VM;
            view.Show();
        }
        public void CreateCustomer(object o)
        {
            Customer newCustomer = new Customer();
            Customers.Add(newCustomer);
            db.Customers.Add(newCustomer);
            db.SaveChanges();
        }
        public void CreateBike(object o)
        {
            Bike newBike = new Bike();
            SelectedStore.Bikes.Add(newBike);
            db.SaveChanges();
        }
        public void CreateStore(object o)
        {
            Store newStore = new Store();
            Stores.Add(newStore);
            db.Stores.Add(newStore);
            db.SaveChanges();
        }
        public void OpenCustomerAdmin(object o)
        {
            CustomersEditViewModel VM = new CustomersEditViewModel(db);
            CustomersEdit view = new CustomersEdit();
            view.DataContext = VM;
            view.Show();
        }
        public void OpenStoreAdmin(object o)
        {
            StoresEditViewModel VM = new StoresEditViewModel(db);
            StoresEdit view = new StoresEdit();
            view.DataContext = VM;
            view.Show();
            
        }
        public void OpenBikeAdmin(object o)
        {
            BikesEditViewModel VM = new BikesEditViewModel(db,SelectedStore.Bikes);
            BikesEdit view = new BikesEdit();
            view.DataContext = VM;
            view.Show();
        }
        public void OpenReservationAdmin(object o)
        {
            ReservationEditViewModel VM = new ReservationEditViewModel(db);
            ReservationEdit view = new ReservationEdit();
            view.DataContext = VM;
            view.Show();
        }



            /* Functie om de applicatie alvast te vullen met test-data
             * Dit gaan we later vervangen door Databases en Database Seeding
             */

        }
}
