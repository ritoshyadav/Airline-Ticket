using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace AirLine
{
    public class Ado:DbContext
    {
        public Ado()
            : base("name=ConnectionString")
        {


        }

        public DbSet<Admin> Admindb { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<User> Users { get; set; }

    }
}