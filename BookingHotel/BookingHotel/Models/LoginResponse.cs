﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingHotel.Models
{
    public class LoginResponse
    {
        public int Id { get; set; }
        public User user { get; set; }
        public string token { get; set; }
    }
}
