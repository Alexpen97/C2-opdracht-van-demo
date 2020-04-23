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
        public ObservableCollection<Bike> Bikes { get; set; } 
        public ObservableCollection<Store> Stores { get; set; }

        public ObservableCollection<Customer> Customers { get; set; }

        public ObservableCollection<Reservation> Reservations { get; set; }

        public ObservableCollection<Bike> SelectedBikeList { get; set; }

        public Store SelectedStore { get; set; }
        public Bike SelectedBike { get; set; }
        public Customer SelectedCustomer { get; set; }
        public Reservation SelectedReservation { get; set; }


       
        public ICommand DeleteStoreClick { get; set; }
        public ICommand CreateStoreClick { get; set; } 
        public ICommand EditStoresClick { get; set; }

        public ICommand DeleteCustomerClick { get; set; }
        public ICommand EditCustomersClick { get; set; }
        public ICommand CreateCustomerClick { get; set; }

        public ICommand EditBikesClick { get; set; }
        public ICommand DeleteBikeClick { get; set; }

        public ICommand CreateReservationClick { get; set; }
        public ICommand DeleteReservationClick { get; set; }
             
        public MainWindowViewModel()
        {
            db.Bikes.Load();
            db.Stores.Load();
            db.Customers.Load();
            db.Reservations.Load();
            
            Bikes = db.Bikes.Local;
            Stores = db.Stores.Local;
            Customers = db.Customers.Local;
            Reservations = db.Reservations.Local;
           
            DeleteStoreClick = new RelayCommand(DeleteStore);
            DeleteCustomerClick = new RelayCommand(DeleteCustomer);
            DeleteBikeClick = new RelayCommand(DeleteBike);
            DeleteReservationClick = new RelayCommand(DeleteReservation);

            CreateCustomerClick = new RelayCommand(CreateCustomer);
            CreateReservationClick = new RelayCommand(CreateReservation);
            CreateStoreClick = new RelayCommand(CreateStore);

            EditCustomersClick = new RelayCommand(OpenCustomerAdmin);
            EditStoresClick = new RelayCommand(OpenStoreAdmin);
            EditBikesClick = new RelayCommand(OpenBikeAdmin);

            
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
            SelectedBikeList = new ObservableCollection<Bike>();

            foreach (Bike bike in Bikes){
                if(SelectedStore == bike.InStore){

                SelectedBikeList.Add(bike);
                }
            }
            BikesEditViewModel VM = new BikesEditViewModel(db,SelectedBikeList,SelectedStore);

            BikesEdit view = new BikesEdit();
            view.DataContext = VM;
            view.Show();
        }
        }
}
