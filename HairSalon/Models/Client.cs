using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using HairSalon;

namespace HairSalon.Models
{

    public class Client
    {
        private string _name;
        private int _id;
        private int _stylistId;

        public Client (string name, int stylistId, int id = 0)
        {
            _name = name;
            _stylistId = stylistId;
            _id = id;
        }

        public int GetId()
        {
            return _id;
        }

        public string GetName()
        {
            return _name;
        }

        public int GetStylistId()
        {
            return _stylistId;
        }

        public override bool Equals(System.Object otherClient)
        {
            if (!(otherClient is Client))
            {
                return false;
            }
            else
            {
                Client newClient = (Client) otherClient;
                bool idEquality = (this.GetId() == newClient.GetId());
                bool nameEquality = (this.GetName() == newClient.GetName());
                bool stylistIdEquality = (this.GetStylistId() == newClient.GetStylistId());
                return (idEquality && nameEquality && stylistIdEquality);
            }
        }

        public override int GetHashCode()
        {
            return this.GetName().GetHashCode();
        }

        public static void ClearAll()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM clients; ALTER TABLE clients AUTO_INCREMENT = 1;";

            cmd.ExecuteNonQuery();

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO clients (name, stylistId) VALUES (@ClientName, @StylistId);";

            MySqlParameter name = new MySqlParameter();
            name.ParameterName = "@ClientName";
            name.Value = this._name;
            cmd.Parameters.Add(name);

            MySqlParameter stylistId = new MySqlParameter();
            stylistId.ParameterName = "@StylistId";
            stylistId.Value = this._stylistId;
            cmd.Parameters.Add(stylistId);

            cmd.ExecuteNonQuery();
            _id = (int)cmd.LastInsertedId;

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static List<Client> GetAll()
        {
            List<Client> allClients = new List<Client>();

            MySqlConnection conn = DB.Connection();
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM clients;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                int clientId = rdr.GetInt32(0);
                string clientName = rdr.GetString(1);
                int stylistId = rdr.GetInt32(2);
                Client client = new Client(clientName, stylistId, clientId);
                allClients.Add(client);
            }

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }

            return allClients;
        }

        public static List<Client> GetSpecificClients(int givenId)
        {
            List<Client> specificClients = new List<Client>();

            MySqlConnection conn = DB.Connection();
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM clients WHERE stylistId = " + givenId + ";";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                int clientId = rdr.GetInt32(0);
                string clientName = rdr.GetString(1);
                int stylistId = rdr.GetInt32(2);
                Client client = new Client(clientName, stylistId, clientId);
                specificClients.Add(client);
            }

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }

            return specificClients;
        }
    }
}
