using System;
using System.Collections.Generic;
using System.Text;

namespace BookingHotel.Models
{
    public class RoomFilter
    {
        public string tinh { get; set; }
        public string quan { get; set; }
        public List<int> sosao { get; set; }
        public long giamin { get; set; }
        public long giamax { get; set; }
        public int sogiuong { get; set; }
        public List<string> loaigiuong { get; set; }
        public List<string> loaiphong { get; set; }
        public List<string> tienichs { get; set; }
        public bool uudai { get; set; } = false;
        public bool noibat { get; set; } = false;
    }
}
