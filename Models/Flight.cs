using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AirLine
{
    public class Flight
    {
        [Key]
        public int FlightId { get; set; }
        public string Name { get; set; }
        public int Day { get; set; }
        public int Seat { get; set; }

        public string Source { get; set; }
        public string Destination { get; set; }
        public int Distance { get; set; }




    }
}