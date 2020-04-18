namespace BikeRentalDemo.Model
{
    /* Inheritance hebben we (nog) niet behandeld, maar hier gebruiken we inheritance om
     * alle INotifyPropertyChanged rotzooi weg te stoppen in de class BikeRentalModel
     */
    public class Bike : BikeRentalModel
    {
        #region Attributes
        /* Attributes om de Properties voluit te schrijven en INotifyPropertyChanged te kunnen gebruiken 
         * Met regions kun je oninteressante code dichtklappen
         */
        private Store _inStore;
        private int _size;
        private string _brand;
        private BikeType _type;
        private BikeGender _gender;
        private bool _rented;
        #endregion
        public int ID { get; set; }
        public BikeType Type { get; set; }
        public BikeGender Gender { get; set; }
        public BikeSize Size { get; set; }
        public string Brand { get; set; }
        public double HourRate { get; set; }
        public double DailyRate { get; set; }

    }

    public enum BikeType
    {
        Mimikyu, Tailow, Starly, Mewtoo
    }
    public enum BikeGender
    {
        Male, Female, Grandma
    }

    public enum BikeSize
    {
        Small, Medium, Large
    }
}
