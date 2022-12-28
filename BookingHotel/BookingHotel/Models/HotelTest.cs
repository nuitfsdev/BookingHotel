using System;
using System.Collections.Generic;
using System.Text;

namespace BookingHotel.Models
{
    public class HotelTest
    {
        public string _id { get; set; }
        public string maht { get; set; }
        public string tenht { get; set; }
        public string diachi { get; set; }
        public string tinh { get; set; }
        public string quan { get; set; }
        public string sosao { get; set; }
        public List<string> tienich { get; set; }
        public string mota { get; set; }
        public List<string> hinh { get; set; }
        public long giamin { get; set; }
        public long giamax { get; set; }
        public bool uudai { get; set; }
        public bool noibat { get; set; }
        public bool trangthai { get; set; }
        public string lienhe { get; set; }
        public List<string> kieudat { get; set; }
        public string createAt { get; set; }
        public string updateAt { get; set; }
    }
}
