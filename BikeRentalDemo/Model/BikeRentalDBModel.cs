using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace BikeRentalDemo.Model
{
    class BikeRentalDBModel : DbContext
    {
        public BikeRentalDBModel()
        {
            this.Configuration.ProxyCreationEnabled = false;
        }
        public virtual DbSet<Bike> Bikes { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }

        
    }
}
