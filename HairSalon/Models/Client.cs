using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using HairSalon;
using System;

namespace HairSalon.Models
{
    public class Client
    {
        public int StylistId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int Id { get; set; }

        public Client(int stylistId, string name, string phone, string email, int id = 0)
        {
            StylistId = stylistId;
            Name = name;
            Phone = phone;
            Email = email;
            Id = id;
        }
    }
}
