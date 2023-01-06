using System;
using System.Collections.Generic;
using System.Text;

namespace BookingHotel.Models
{
    public class LoginResponse
    {
        public User user { get; set; }
        public string token { get; set; }
    }
}
