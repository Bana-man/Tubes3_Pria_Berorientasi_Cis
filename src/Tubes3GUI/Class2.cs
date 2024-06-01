using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySqlConnector;

namespace Tubes3GUI
{
    internal class ConnectDB
    {
        static String connStr = "Server=localhost;User ID = root; Password=;Database=stima";
        public static void printNIK()
        {
            //string connStr = "Server=localhost;User ID = root; Password=;Database=stima";
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
            //string connStr = "Server=localhost;User ID = root; Password=;Database=stima";
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

        public static void setDataFingerprint()
        {   
            //string connStr = "Server=localhost;User ID = root; Password=;Database=stima";
            var cn = new MySqlConnector.MySqlConnection(connStr);
            cn.Open();
            string query = "SELECT * FROM sidik_jari";
            var cmd = new MySqlConnector.MySqlCommand(query, cn);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Form1.dbSidikJari.Add((reader["berkas_citra"].ToString(), reader["nama"].ToString()));
            }
        }
        public static void InsertSidikJari(string berkasJari, string nama)
        {
            var cn = new MySqlConnector.MySqlConnection(connStr);
            cn.Open();
            string query = "INSERT INTO sidik_jari (berkas_citra, nama) VALUES (@berkasJari, @nama)";
            var cmd = new MySqlConnector.MySqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@berkasJari", berkasJari);
            cmd.Parameters.AddWithValue("@nama", nama);
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        public static void setDataBiodata()
        {
            var cn = new MySqlConnector.MySqlConnection(connStr);
            cn.Open();
            string query = "SELECT * FROM biodata";
            var cmd = new MySqlConnector.MySqlCommand(query, cn);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Form1.dbBiodata.Add(new Orang(reader["NIK"].ToString(), reader["nama"].ToString(), reader["tempat_lahir"].ToString(), reader["tanggal_lahir"].ToString()
                    , reader["jenis_kelamin"].ToString(), reader["golongan_darah"].ToString(), reader["alamat"].ToString(), reader["agama"].ToString(),
                    reader["status_perkawinan"].ToString(), reader["pekerjaan"].ToString(), reader["kewarganegaraan"].ToString()));
            }
        }

        public static void printNamafromBiodata()
        {
            //string connStr = "Server=localhost;User ID = root; Password=;Database=stima";
            var cn = new MySqlConnector.MySqlConnection(connStr);
            cn.Open();
            string query = "SELECT * FROM biodata";
            var cmd = new MySqlConnector.MySqlCommand(query, cn);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Debug.WriteLine(reader["nama"].ToString());
            }
        }

        //Buat masukin data sidik jari, testing purposes
        public static string[] LoadFirst10ImagesAsBitmap(string folderPath)
        {
            // Get all image files from the folder
            string[] imageFiles = Directory.GetFiles(folderPath, "*.*")
                                            .Where(f => f.EndsWith(".jpg") || f.EndsWith(".jpeg") || f.EndsWith(".png") || f.EndsWith(".BMP"))
                                            .Take(10)
                                            .ToArray();

            // Create an array to hold the Bitmap objects
            Bitmap[] bitmaps = new Bitmap[imageFiles.Length];

            // Convert each image file to Bitmap and store in the array
            for (int i = 0; i < imageFiles.Length; i++)
            {
                bitmaps[i] = new Bitmap(imageFiles[i]);
            }

            string[] convertedBitmap = new string[imageFiles.Length];

            for (int i = 0; i < imageFiles.Length; i++)
            {
                convertedBitmap[i] = Utility.ConvertImageToString(bitmaps[i]);
            }

            return convertedBitmap;
        }

    }
}
