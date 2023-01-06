using System;
using System.Collections.Generic;
using System.Text;

namespace BookingHotel.Models
{
    public class ForgotPassword
    {
        public string email { get; set; }
        public string password { get; set; }
        public string verifyCode { get; set; }
    }
}
