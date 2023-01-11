using System;
using System.Collections.Generic;
using System.Text;

namespace BookingHotel.Models
{
    public class Hotel
    {



        //public string MAKH { get; set; }
        //public string TenKH { get; set; }
        //public string DiaChiChiTiet { get; set; }
        //public string Tinh { get; set; }
        //public string QuanHuyen { get; set; }
        //public string PhuongXa { get; set; }
        //public int RateKH { get; set; }
        //public string HinhAnhKH { get; set; }
        //public string Mota { get; set; }
        //public string ChuongTrinh { get; set; }
        //public string GiaMin { get; set; }
        //public string GiaMax { get; set; }

        public string _id { get; set; }
        public string maht { get; set; }
        public string tenht { get; set; }
        public string diachi { get; set; }
        public string tinh { get; set; }
        public string quan { get; set; }
        public string sosao { get; set; }
        public List<Tienich> tienichs { get; set; }
        public string mota { get; set; }
        public List<string> hinh { get; set; }
        public long giamin { get; set; }
        public long giamax { get; set; }
        public long giamgia { get; set; }

        public bool uudai { get; set; }
        public bool noibat { get; set; }
        public bool trangthai { get; set; }
        public string lienhe { get; set; }
        public List<string> kieudat { get; set; }
        public string map { get; set; }
        public string createAt { get; set; }
        public string updateAt { get; set; }
    }
}
