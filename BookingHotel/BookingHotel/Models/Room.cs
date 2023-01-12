using System;
using System.Collections.Generic;
using System.Text;

namespace BookingHotel.Models
{
    public class Room
    {
        public string _id { get; set; }
        public string maroom { get; set; }
        public string maht { get; set; }
        public string tenphong { get; set; }
        public string loaiphong { get; set; }
        public string loaigiuong { get; set; }
        public string dientich { get; set; }
        public int sogiuong { get; set; }
        public int soluong { get; set; }
        public bool tinhtrang { get; set; }
        public List<TienIchRoom> tienichs { get; set; }
        public string mota { get; set; }
        public List<string> hinh { get; set; }
        public long giagio { get; set; }
        public long giagio2 { get; set; }

        public long giangay { get; set; }
        public long giatreem { get; set; }
        public int slnguoilon { get; set; }
        public int sltreem { get; set; }
        public bool uudai { get; set; }
        public bool noibat { get; set; }
        public List<string> khac { get; set; }
        public string createdAt { get; set; }
        public string updatedAt { get; set; }
    }
}
