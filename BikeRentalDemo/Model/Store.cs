using System.Collections.ObjectModel;

namespace BikeRentalDemo.Model
{
    /* Inheritance hebben we (nog) niet behandeld, maar hier gebruiken we inheritance om
     * alle INotifyPropertyChanged rotzooi weg te stoppen in de class BikeRentalModel
     */
    public class Store
    {
        public int ID { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public virtual ObservableCollection<Bike> Bikes { get; set; }
    
    public Store()
    {
            Bikes = new ObservableCollection<Bike>();
            Address = "newStore";
    }
    
    }
}
