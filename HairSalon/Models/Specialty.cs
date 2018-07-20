using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using HairSalon;

namespace HairSalon.Models
{
    public class Specialty
    {
        public int SpecialtyId { get; set; }
        public string SpecialtyType { get; set; }

        public Specialty(string specialtyType, int specialtyId = 0)
        {
            SpecialtyType = specialtyType;
            SpecialtyId = specialtyId;
        }

        public override bool Equals(System.Object otherSpecialty)
        {
            if (!(otherSpecialty is Specialty))
            {
                return false;
            }
            else
            {
                Specialty newSpecialty = (Specialty)otherSpecialty;
                bool specialtyIdEquality = (this.SpecialtyId == newSpecialty.SpecialtyId);
                bool specialtyTypeEquality = (this.SpecialtyType == newSpecialty.SpecialtyType);

                return (specialtyIdEquality && specialtyTypeEquality);
            }
        }

        public override int GetHashCode()
        {
            return this.SpecialtyType.GetHashCode();
        }

        public static List<Specialty> GetAll()
        {
            List<Specialty> allSpecialties = new List<Specialty> { };
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM specialties;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                int specialtyId = rdr.GetInt32(0);
                string specialtyType = rdr.GetString(1);
                Specialty newSpecialty = new Specialty(specialtyType, specialtyId);
                allSpecialties.Add(newSpecialty);
            }

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allSpecialties;
        }

        public static Specialty Find(int id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM specialties WHERE id = @SpecialtyId;";

            cmd.Parameters.AddWithValue("@SpecialtyId", id);

            var rdr = cmd.ExecuteReader() as MySqlDataReader;

            int specialtyId = 0;
            string specialtyType = "";

            while (rdr.Read())
            {
                specialtyId = rdr.GetInt32(0);
                specialtyType = rdr.GetString(1);
            }

            Specialty foundSpecialty = new Specialty(specialtyType, specialtyId);

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return foundSpecialty;
        }

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO specialties (type) VALUES (@SpecialtyType);";

            cmd.Parameters.AddWithValue("@SpecialtyType", this.SpecialtyType);

            cmd.ExecuteNonQuery();
            this.SpecialtyId = (int)cmd.LastInsertedId;

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }
    }
}
