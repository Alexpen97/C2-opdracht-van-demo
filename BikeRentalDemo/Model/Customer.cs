using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeRentalDemo.Model
{
    public class Customer 
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public CustomerGender gender { get; set; }
        public double Height { get; set; }
        public string Email { get; set; }

        public enum CustomerGender
        {
            Male, Female
        }
    }
}
