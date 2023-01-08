using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingHotel.Models
{
    public class User
    {
        [PrimaryKey]
        public string _id { get; set; }
        public string mauser { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string sdt { get; set; }
        public string verifyCode {get; set; }
    }
}
