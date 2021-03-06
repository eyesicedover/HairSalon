using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using HairSalon;

namespace HairSalon.Models
{

    public class Stylist
    {
        private int _id;
        private string _name;
        private static int _currentStylistId;

        public Stylist(string name, int Id = 0)
        {
            _name = name;
            _id = Id;
        }

        public override bool Equals(System.Object otherStylist)
        {
            if(!(otherStylist is Stylist))
            {
                return false;
            }
            else
            {
                Stylist newStylist = (Stylist) otherStylist;
                bool idEquality = (this.GetId() == newStylist.GetId());
                bool nameEquality = (this.GetName() == newStylist.GetName());
                return (idEquality && nameEquality);
            }
        }

        public override int GetHashCode()
        {
            return this.GetName().GetHashCode();
        }


        public int GetId()
        {
            return _id;
        }

        public string GetName()
        {
            return _name;
        }

        public void SetName(string newName)
        {
            _name = newName;
        }

        public static void SetCurrentStylistId(int newId)
        {
            _currentStylistId = newId;
        }

        public static int GetCurrentStylistId()
        {
            return _currentStylistId;
        }

        public static void ClearAll()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM stylists; ALTER TABLE stylists AUTO_INCREMENT = 1;";

            cmd.ExecuteNonQuery();

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static List<Stylist> GetAll()
        {
            List<Stylist> allStylists = new List<Stylist>();

            MySqlConnection conn = DB.Connection();
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM stylists;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
                int stylistId = rdr.GetInt32(0);
                string stylistName = rdr.GetString(1);
                Stylist stylist = new Stylist(stylistName, stylistId);
                allStylists.Add(stylist);
            }

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }

            return allStylists;
        }

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO stylists (name) VALUES (@StylistName);";

            MySqlParameter name = new MySqlParameter();
            name.ParameterName = "@StylistName";
            name.Value = this._name;
            cmd.Parameters.Add(name);

            cmd.ExecuteNonQuery();
            _id = (int)cmd.LastInsertedId;

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static Stylist Find(int id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM stylists WHERE id = @thisId;";

            MySqlParameter thisId = new MySqlParameter();
            thisId.ParameterName = "@thisId";
            thisId.Value = id;
            cmd.Parameters.Add(thisId);

            var rdr = cmd.ExecuteReader() as MySqlDataReader;

            int stylistId = 0;
            string stylistName = "";

            while (rdr.Read())
            {
                stylistId = rdr.GetInt32(0);
                stylistName = rdr.GetString(1);
            }

            Stylist foundStylist = new Stylist(stylistName, stylistId);

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }

            return foundStylist;
        }
    }
}
