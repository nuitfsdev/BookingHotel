using System;
using System.Collections.Generic;
using System.Text;

namespace BookingHotel.Models
{
     public class HoaDon
    {
        public string _id { get; set; }
        public string mahd { get; set; }
        public string makh { get; set; }
        public Hotel hotel { get; set; }
        public Room room { get; set; }
        public string tenkh { get; set; }
        public string email { get; set; }
        public string sdt { get; set; }
        public string ngayhd { get; set; }
        public string tinhtrang { get; set; }
        public long trigia { get; set; }
        public long gia { get; set; }
        public string ptdatphong { get; set; }
        public string ngaynhan { get; set; }
        public string ngaytra { get; set; }
        public string gionhan { get; set; }
        public string giotra { get; set; }
        public int sogio { get; set; }
        public int songay { get; set; }
        public int slnguoilon { get; set; }
        public int sltreem { get; set; }
        public int slphong { get; set; }
        public string phuongthuc { get; set; }
        public string nganhang { get; set; }
        public string tennganhang { get; set; }
        public string sotaikhoan { get; set; }
        public string khac { get; set; }
        public string createdAt { get; set; }
        public string updatedAt { get; set; }
        public string tinhtrangColor { get; set; }
    }
}
