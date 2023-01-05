using System;
using System.Collections.Generic;
using System.Text;

namespace BookingHotel.Models
{
    public class Order
    {
        public string maht { get; set; }
        public string maroom { get; set; }
        public string hinh { get; set; }
        public string tenht { get; set; }
        public string tinh { get; set; }
        public string quan { get; set; }
        public int adult { get; set; }
        public int child { get; set; }
        public int bed { get; set; }
        public string tenphong { get; set; }
        public string checkin { get; set; }
        public string checkout { get; set; }
        public string timecheckin { get; set; }
        public string timecheckout { get; set; }
        public long total { get; set; }
        public string create { get; set; }
        public int status { get; set; }   
    }
}
