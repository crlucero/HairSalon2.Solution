using System;
using MySql.Data.MySqlClient;
using HairSalon2;
 
namespace HairSalon2.Models
{
    public class DB
    {
        public static MySqlConnection Connection()
        {
            MySqlConnection conn = new MySqlConnection(DBConfiguration.ConnectionString);
            return conn;
        }
    }
}
