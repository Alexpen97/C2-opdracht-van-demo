namespace BikeRentalDemo.Model
{
    public class Bike 
    {

        public int ID { get; set; }
        public int InStoreID {get;set;}
        public Store InStore { get; set; }
        public BikeType Type { get; set; }
        public BikeGender Gender { get; set; }
        public BikeSize Size { get; set; }
        public string Brand { get; set; }
        public double HourRate { get; set; }
        public double DailyRate { get; set; }

    }

    public enum BikeType
    {
        Mimikyu, Tailow, Starly, Mewtoo, Pikachu, Fattypatty, Jumpluff, Flaafy, Applin
    }
    public enum BikeGender
    {
        Male, Female, Grandma, Grandpa
    }

    public enum BikeSize
    {
        Small, Medium, Large
    }
}
