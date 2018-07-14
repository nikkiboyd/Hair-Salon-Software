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

        public Stylist(int stylistId, string stylistName)
        {
            StylistName = stylistName;
            StylistId = stylistId;
        }

        public override bool Equals(System.Object otherStylist)
        {
            if (!(otherStylist is Stylist))
            {
                return false;
            }
            else
            {
                Stylist newStylist = (Stylist)otherStylist;
                bool stylistIdEquality = (this.StylistId == newStylist.StylistId);
                bool nameEquality = (this.StylistName == newStylist.StylistName);

                return (stylistIdEquality && nameEquality);
            }
        }

        public override int GetHashCode()
        {
            return this.StylistName.GetHashCode();
        }

        public static void DeleteAll()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM stylists;";

            cmd.ExecuteNonQuery();
        }

        public static List<Client> GetClientsByStylist(int sId)
        {
            List<Client> allClientsByStylist = new List<Client> { };
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM clients WHERE stylist_id = @StylistId;";
            cmd.Parameters.AddWithValue("@StylistId", sId);

            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                int stylistId = rdr.GetInt32(1);
                string clientName = rdr.GetString(2);
                string clientPhone = rdr.GetString(3);
                string clientEmail = rdr.GetString(4);
                int clientId = rdr.GetInt32(0);

                Client newClient = new Client(stylistId, clientName, clientPhone, clientEmail, clientId);
                allClientsByStylist.Add(newClient);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allClientsByStylist;
        }

        public static List<Stylist> GetAll()
        {
            List<Stylist> allStylists = new List<Stylist> { };
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM stylists;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                int stylistId = rdr.GetInt32(0);
                string stylistName = rdr.GetString(1);
                Stylist newStylist = new Stylist(stylistId, stylistName);
                allStylists.Add(newStylist);
            }

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allStylists;
        }

        public static Stylist Find(int sId)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM stylists WHERE id = (@searchId);";

            MySqlParameter searchId = new MySqlParameter();
            searchId.ParameterName = "@searchId";
            searchId.Value = sId;
            cmd.Parameters.Add(searchId);

            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            int StylistId = 0;
            string StylistName = "";

            while (rdr.Read())
            {
                StylistId = rdr.GetInt32(0);
                StylistName = rdr.GetString(1);
            }
            Stylist newStylist = new Stylist(StylistId, StylistName);
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return newStylist;
        }

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO stylists (name) VALUES (@StylistName);";

            cmd.Parameters.AddWithValue("@StylistName", this.StylistName);

            cmd.ExecuteNonQuery();
            this.StylistId = (int)cmd.LastInsertedId;

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public void Delete()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM stylists WHERE id = @StylistId;";

            cmd.Parameters.AddWithValue("@StylistId", this.StylistId);

            cmd.ExecuteNonQuery();

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }
        
        public void Update(int stylistId, string stylistName)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"UPDATE stylists SET name = @StylistName WHERE id = @StylistId;";

            cmd.Parameters.AddWithValue("@StylistId", stylistId);
            cmd.Parameters.AddWithValue("@StylistName", stylistName);

            cmd.ExecuteNonQuery();
            StylistId = stylistId;
            StylistName = stylistName;

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }
    }
}