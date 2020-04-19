using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace BikeRentalDemo.Model
{
    public class Reservation
    {
        public int ID { get; set; }
        public Customer Customer { get; set; }
        public List<Bike> Bikes { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Store PickUp { get; set; }
        public Store DropOff { get; set; }
    }
}
