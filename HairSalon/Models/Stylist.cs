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
    }
}