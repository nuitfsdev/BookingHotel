using System;
using System.Collections.Generic;
using System.Text;

namespace BookingHotel.Models
{
    public class HotelFilter
    {
        public string tinh { get; set; }
        public string huyen { get; set; }
        public List<int> sosao { get; set; }
        public long giamin { get; set; }    
        public long giamax { get; set; }
        public List<string> tienichs { get; set; }

    }
}
