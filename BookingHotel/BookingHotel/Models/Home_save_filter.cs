using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingHotel.Models
{
    public class Home_save_filter
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string tinh { get; set; }
        public string quan { get; set; }
        public string checkin_day { get; set; }
        public string checkout_day { get; set; }
    }
}
