using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using HairSalon;

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

        public static List<Client> GetAll()
        {
            List<Client> allClients = new List<Client> { };
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM clients";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                int stylistId = rdr.GetInt32(1);
                string clientName = rdr.GetString(2);
                string clientPhone = rdr.GetString(3);
                string clientEmail = rdr.GetString(4);
                int clientId = rdr.GetInt32(0);

                Client newClient = new Client(stylistId, clientName, clientPhone, clientEmail, clientId);
                allClients.Add(newClient);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allClients;
        }

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO clients (stylist_id, name, phone, email) VALUES (@ClientStylistId, @ClientName, @ClientPhone, @ClientEmail);";

            cmd.Parameters.AddWithValue("@ClientStylistId", this.StylistId);
            cmd.Parameters.AddWithValue("@ClientName", this.Name);
            cmd.Parameters.AddWithValue("@ClientPhone", this.Phone);
            cmd.Parameters.AddWithValue("@ClientEmail", this.Email);

            cmd.ExecuteNonQuery();
            this.Id = (int)cmd.LastInsertedId;

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static Client Find(int id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM `clients` WHERE id = @thisId;";

            MySqlParameter thisId = new MySqlParameter();
            thisId.ParameterName = "@thisId";
            thisId.Value = id;
            cmd.Parameters.Add(thisId);

            var rdr = cmd.ExecuteReader() as MySqlDataReader;

            int stylistId = 0;
            string clientName = "";
            string clientPhone = "";
            string clientEmail = "";
            int clientId = 0;

            while (rdr.Read())
            {
                
                stylistId = rdr.GetInt32(1);
                clientName = rdr.GetString(2);
                clientPhone = rdr.GetString(3);
                clientEmail = rdr.GetString(4);
                clientId = rdr.GetInt32(0);
            }

            Client foundClient = new Client(stylistId, clientName, clientPhone, clientEmail, clientId);

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }

            return foundClient;
        }

        public void Update(int stylistId, string clientName, string clientPhone, string clientEmail, int clientId)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"UPDATE clients SET stylist_id = @ClientStylistId, name = @ClientName, phone = @ClientPhone, email = @ClientEmail WHERE id = @ClientId;";

            cmd.Parameters.AddWithValue("@ClientId", clientId);
            cmd.Parameters.AddWithValue("@ClientStylistId", stylistId);
            cmd.Parameters.AddWithValue("@ClientName", clientName);
            cmd.Parameters.AddWithValue("@ClientPhone", clientPhone);
            cmd.Parameters.AddWithValue("@ClientEmail", clientEmail);

            cmd.ExecuteNonQuery();
            Id = clientId;
            StylistId = stylistId;
            Name = clientName;
            Phone = clientPhone;
            Email = clientEmail;

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }
    }
}
