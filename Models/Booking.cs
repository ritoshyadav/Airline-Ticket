using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AirLine
{
    public class Booking
    {
        [Key]
        public int bookingId { get; set; }
        public User UserID { get; set; }

        public Flight FlightId { get; set; }
        public string SeatType { get; set; }

        [Display(Name="Day of Journay")]
        public DateTime DayofJry { get; set; }

        public Double Amt { get; set; }



    }
}