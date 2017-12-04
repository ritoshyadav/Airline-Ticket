using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AirLine
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Contact { get; set; }

        public string Address { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }

        public string Username { get; set; }
        public string password { get; set; }
    }
}