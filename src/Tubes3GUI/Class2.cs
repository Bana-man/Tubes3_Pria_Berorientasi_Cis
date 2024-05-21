using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySqlConnector;

namespace Tubes3GUI
{
    internal class ConnectDB
    {
        public static void printNIK()
        {
            string connStr = "Server=localhost;User ID = root; Password=;Database=stima";
            var cn = new MySqlConnector.MySqlConnection(connStr);
            cn.Open();
            string query = "SELECT * FROM biodata";
            var cmd = new MySqlConnector.MySqlCommand(query, cn);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Debug.WriteLine(reader["NIK"].ToString());
            }
        }

        public static List<string> listFingerprint() {
            var retVal = new List<string>();
            string connStr = "Server=localhost;User ID = root; Password=;Database=stima";
            var cn = new MySqlConnector.MySqlConnection(connStr);
            cn.Open();
            string query = "SELECT * FROM biodata";
            var cmd = new MySqlConnector.MySqlCommand(query, cn);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Debug.WriteLine(reader["NIK"].ToString());
            }
            return retVal;
        }
    }
}
