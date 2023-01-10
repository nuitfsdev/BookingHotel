using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingHotel.Models
{
    public class Intro
    {
        [PrimaryKey]
        public int Id { get; set; }
        public int skip { get; set; } = 0;
    }
}
