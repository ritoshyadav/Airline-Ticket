using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AirLine
{
    public class Admin
    {
        [Key]
        public int UserID { get; set; }
        public string Name { get; set; }
       
        public string Username { get; set; }
        public string password { get; set; }
    }
}