using System.Collections.ObjectModel;

namespace BikeRentalDemo.Model
{
    /* Inheritance hebben we (nog) niet behandeld, maar hier gebruiken we inheritance om
     * alle INotifyPropertyChanged rotzooi weg te stoppen in de class BikeRentalModel
     */
    public class Store : BikeRentalModel
    {
        #region Attributes
        /* Attributes om de Properties voluit te schrijven en INotifyPropertyChanged te kunnen gebruiken 
         * Met regions kun je oninteressante code dichtklappen
         */
        private int _maxCapacity;
        private string _name;
        #endregion
        public int ID { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
    }
}
