using System;
using System.Collections.Generic;
using System.Text;

namespace BookingHotel.Models
{
    public class Room
    {
        public int ID { get; set; }
        public string IDKS { get; set; }
        public string Hinh { get; set; }
        public string TenPhong { get; set; }
        public string mota { get; set; }
        public int price { get; set; }
        public int qty { get; set; }
    }
}
