using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using HairSalon;

namespace HairSalon.Models
{
    public class Stylist
    {
        public int StylistId { get; set; }
        public string StylistName { get; set; }

        public Stylist(string name, int stylistId)
        {
            StylistName = name;
            StylistId = stylistId;
        }
    }
}