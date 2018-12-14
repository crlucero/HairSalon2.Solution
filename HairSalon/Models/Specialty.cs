using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using HairSalon;

namespace HairSalon.Models
{ 
    public class Specialty
    {
        private int _id;
        private string _name;

        public Specialty(string specialtyName, int specialtyId = 0)
        {
            _id = specialtyId;
            _name = specialtyName;
        }

        public int GetId()
        {
            return _id;
        }

        public string GetSpecialtyName()
        {
            return _name;
        }

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO specialties (name) VALUES (@name);";

            MySqlParameter specialtyName = new MySqlParameter();
            specialtyName.ParameterName = "@name";
            specialtyName.Value = _name;
            cmd.Parameters.Add(specialtyName);

            cmd.ExecuteNonQuery();
            _id = (int)cmd.LastInsertedId;

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static List<Specialty> GetAll()
        {
            List<Specialty> allSpecialties = new List<Specialty> { };
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM specialties;";
            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                int specialtyId = rdr.GetInt32(0);
                string specialtyName = rdr.GetString(1);

                Specialty newSpecialty = new Specialty(specialtyName,specialtyId );
                allSpecialties.Add(newSpecialty);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allSpecialties;
        }

        //Overrides
        public override bool Equals(System.Object otherSpecialty)
        {
            if (!(otherSpecialty is Specialty))
            {
                return false;
            }
            else
            {
                Specialty newSpecialty = (Specialty)otherSpecialty;
                bool areIdsEqual = (this.GetId() == newSpecialty.GetId());
                bool areNamesEqual = (this.GetSpecialtyName() == newSpecialty.GetSpecialtyName());
                return (areIdsEqual && areNamesEqual);
            }
        }


        public override int GetHashCode()
        {
            return this.GetSpecialtyName().GetHashCode();
        }


        // end of Specialty class
    }
//end of namespace
}
