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

        public override bool Equals(System.Object otherClient)
        {
            if (!(otherClient is Client))
            {
                return false;
            }
            else
            {
                Client newClient = (Client)otherClient;
                bool stylistIdEquality = (this.StylistId == newClient.StylistId);
                bool nameEquality = (this.Name == newClient.Name);
                bool phoneEquality = (this.Phone == newClient.Phone);
                bool emailEquality = (this.Email == newClient.Email);
                bool idEquality = (this.Id == newClient.Id);

                return (stylistIdEquality && nameEquality && phoneEquality && emailEquality && idEquality);
            }
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }

        public static void DeleteAll()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM clients;";

            cmd.ExecuteNonQuery();
        }
    }
}
