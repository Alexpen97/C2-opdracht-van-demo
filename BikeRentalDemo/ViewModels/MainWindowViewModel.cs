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


        public ICommand OpenStoreClick { get; set; } // De koppeling met de Command-binding van de click op een Store in het overzicht
        public ICommand DeleteStoreClick { get; set; } // De koppeling met de Command-binding van de Delete-knoppen in het Store-overzicht
        public ICommand OpenNewStoreClick { get; set; } // De koppeling met de Command-binding van de "+"-knop
        public ICommand OpenBikeAdminClick { get; set; } // De koppeling met de Command-binding van de "fietsenbeheer"-knop

        public ICommand OpenCustomerClick { get; set; }
        public ICommand DeleteCustomerClick { get; set; }

        public ICommand CreateNewCustomerClick { get; set; }

        public ICommand CustomersAdminClick { get; set; }
        public ICommand StoresAdminClick { get; set; }
        public ICommand BikesAdminClick { get; set; }
        public ICommand ReservationsAdminClick { get; set; }

        public ICommand CreateReservationClick { get; set; }
             
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

            CreateNewCustomerClick = new RelayCommand(CreateNewCustomer);
            CreateReservationClick = new RelayCommand(CreateReservation);
           
           
            CustomersAdminClick = new RelayCommand(OpenCustomerAdmin);
            StoresAdminClick = new RelayCommand(OpenStoreAdmin);
            BikesAdminClick = new RelayCommand(OpenBikeAdmin);
            ReservationsAdminClick = new RelayCommand(OpenReservationAdmin);

        }

        public void DeleteStore(object store)
        {
            /* In de View hebben we naast de DeleteCommand-binding ook een DeleteCommandParameter-binding. 
             * Die hebben we gebind aan de store waar op geklikt wordt. Die wordt dan als Parameter meegegeven 
             * aan deze functie (in "object store"). Wij weten dat het een Store is,
             * dus we moeten 'm nog casten van Object naar Store
             */
            Store clickedStore = store as Store;

            db.Stores.Remove(db.Stores.Find(clickedStore.ID));
            Stores.Remove(clickedStore); // Haal de Store weg uit de lijst met Stores
            db.SaveChanges();
        }
        public void OpenCustomer(object customer)
        {
            /*
            Customer clickedCustomer = customer as Customer;

            CustomerEditViewModel vm = new CustomerEditViewModel { customer = clickedCustomer };
            CustomerEdit view = new CustomerEdit { DataContext = vm };
            view.Show();

           */

        }
        public void DeleteCustomer(object customer)
        {
            Customer clickedCustomer = customer as Customer;
           db.Customers.Remove(db.Customers.Find(clickedCustomer.ID));
            Customers.Remove(clickedCustomer);
            db.SaveChanges();

        }
        public void CreateNewCustomer(object o)
        {
            Customer newcustomer = new Customer();
            Customers.Add(newcustomer);
            db.Customers.Add(newcustomer);
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
            BikesEditViewModel VM = new BikesEditViewModel(db);
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
        public void CreateReservation(object o)
        {
            Reservation reservation = new Reservation();
            reservation.Customer = SelectedCustomer;
            CreateReservationViewModel VM = new CreateReservationViewModel(reservation,db);

            CreateReservation view = new CreateReservation();
            view.DataContext = VM;
            view.Show();
            


        }

            /* Functie om de applicatie alvast te vullen met test-data
             * Dit gaan we later vervangen door Databases en Database Seeding
             */

        }
}
