using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingHotel.Models
{
    public class Token
    {
        [PrimaryKey]
        public string mauser { get; set; }
        public string token { get; set; }
    }
}
