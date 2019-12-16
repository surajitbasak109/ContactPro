using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace ContactPro
{
    class Conn
    {
        public MySqlConnection ClsConnection;
        public static MySqlConnection allcon = new MySqlConnection();

        public Conn()
        {
            string constring = "Server=localhost;Database=contactpro;uid=root;pwd=mntz; convert zero datetime=True";
            ClsConnection = new MySqlConnection(constring);
            allcon = new MySqlConnection(constring);
        }

        public static void Open()
        {
            if (allcon.State == ConnectionState.Closed)
            {
                allcon.Open();
            }
        }
        public static void Close()
        {
            if (allcon.State == ConnectionState.Open)
            {
                allcon.Close();
            }
        }
    }
}
