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
        static bool encryptDatabase = false;
        static bool decryptDatabase = false;
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
                Debug.WriteLine(Enkripsi.XorDecrypt(reader["NIK"].ToString()));
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
                Debug.WriteLine(Enkripsi.EncryptOrDecrypt16DigitString(reader["NIK"].ToString()));
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
            if (decryptDatabase)
            {
                while (reader.Read())
                {
                    Form1.dbSidikJari.Add((Enkripsi.XorDecrypt(reader["berkas_citra"].ToString()), Enkripsi.XorDecrypt(reader["nama"].ToString())));
                }
            } else
            {
                while (reader.Read())
                {
                    Form1.dbSidikJari.Add((reader["berkas_citra"].ToString(), reader["nama"].ToString()));
                }
            }
            
        }
        public static void InsertSidikJari(string berkasJari, string nama)
        {
            var cn = new MySqlConnector.MySqlConnection(connStr);
            cn.Open();
            string query = "INSERT INTO sidik_jari (berkas_citra, nama) VALUES (@berkasJari, @nama)";
            var cmd = new MySqlConnector.MySqlCommand(query, cn);
            if (encryptDatabase)
            {
                cmd.Parameters.AddWithValue("@berkasJari", Enkripsi.XorEncrypt(berkasJari));
                cmd.Parameters.AddWithValue("@nama", Enkripsi.XorEncrypt(nama));
            } else
            {
                cmd.Parameters.AddWithValue("@berkasJari", berkasJari);
                cmd.Parameters.AddWithValue("@nama", nama);
            }
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        public static void InsertBiodata(string NIK, string nama, string tempat_lahir, string tanggal_lahir, string jenis_kelamin, string golongan_darah, string alamat,
            string agama, string status_perkawinan, string pekerjaan, string kewarganegaraan)
        {
            var cn = new MySqlConnector.MySqlConnection(connStr);
            cn.Open();
            string query = "INSERT INTO biodata (NIK, nama, tempat_lahir, tanggal_lahir, jenis_kelamin, golongan_darah, alamat, agama, status_perkawinan," +
                "pekerjaan, kewarganegaraan) VALUES (@NIK, @nama, @tempat_lahir, @tanggal_lahir, @jenis_kelamin, @golongan_darah, @alamat, @agama, @status_perkawinan," +
                "@pekerjaan, @kewarganegaraan)";
            var cmd = new MySqlConnector.MySqlCommand(query, cn);
            if (encryptDatabase)
            {
                cmd.Parameters.AddWithValue("@NIK", Enkripsi.EncryptOrDecrypt16DigitString(NIK));
                cmd.Parameters.AddWithValue("@nama", Enkripsi.XorEncrypt(nama));
                cmd.Parameters.AddWithValue("@tempat_lahir", Enkripsi.XorEncrypt(tempat_lahir));
                cmd.Parameters.AddWithValue("@tanggal_lahir", Enkripsi.DateEncrypt(tanggal_lahir));
                cmd.Parameters.AddWithValue("@jenis_kelamin", Enkripsi.EncryptOrDecryptJenisKelamin(jenis_kelamin, true));
                cmd.Parameters.AddWithValue("@golongan_darah", Enkripsi.XorEncrypt(golongan_darah));
                cmd.Parameters.AddWithValue("@alamat", Enkripsi.XorEncrypt(alamat));
                cmd.Parameters.AddWithValue("@agama", Enkripsi.XorEncrypt(agama));
                cmd.Parameters.AddWithValue("@status_perkawinan", Enkripsi.EncryptOrDecryptStatusPerkawinan(status_perkawinan, true));
                cmd.Parameters.AddWithValue("@pekerjaan", Enkripsi.XorEncrypt(pekerjaan));
                cmd.Parameters.AddWithValue("@kewarganegaraan", Enkripsi.XorEncrypt(kewarganegaraan));
            } else
            {
                cmd.Parameters.AddWithValue("@NIK", NIK);
                cmd.Parameters.AddWithValue("@nama", nama);
                cmd.Parameters.AddWithValue("@tempat_lahir", tempat_lahir);
                cmd.Parameters.AddWithValue("@tanggal_lahir", tanggal_lahir);
                cmd.Parameters.AddWithValue("@jenis_kelamin", jenis_kelamin);
                cmd.Parameters.AddWithValue("@golongan_darah", golongan_darah);
                cmd.Parameters.AddWithValue("@alamat", alamat);
                cmd.Parameters.AddWithValue("@agama", agama);
                cmd.Parameters.AddWithValue("@status_perkawinan", status_perkawinan);
                cmd.Parameters.AddWithValue("@pekerjaan", pekerjaan);
                cmd.Parameters.AddWithValue("@kewarganegaraan", kewarganegaraan);
            }
            
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
            if (decryptDatabase)
            {
                while (reader.Read())
                {
                    Form1.dbBiodata.Add(new Orang(Enkripsi.EncryptOrDecrypt16DigitString(reader["NIK"].ToString()), Enkripsi.XorDecrypt(reader["nama"].ToString()),
                    Enkripsi.XorDecrypt(reader["tempat_lahir"].ToString()), Enkripsi.DateDecrypt(reader["tanggal_lahir"].ToString()),
                    Enkripsi.EncryptOrDecryptJenisKelamin(reader["jenis_kelamin"].ToString(), false), Enkripsi.XorDecrypt(reader["golongan_darah"].ToString()),
                    Enkripsi.XorDecrypt(reader["alamat"].ToString()), Enkripsi.XorDecrypt(reader["agama"].ToString()),
                    Enkripsi.EncryptOrDecryptStatusPerkawinan(reader["status_perkawinan"].ToString(), false), Enkripsi.XorDecrypt(reader["pekerjaan"].ToString()),
                    Enkripsi.XorDecrypt(reader["kewarganegaraan"].ToString())));
                }
            } else
            {
                while (reader.Read())
                {
                    Form1.dbBiodata.Add(new Orang(reader["NIK"].ToString(), reader["nama"].ToString(),
                    reader["tempat_lahir"].ToString(), reader["tanggal_lahir"].ToString(),
                    reader["jenis_kelamin"].ToString(), reader["golongan_darah"].ToString(),
                    reader["alamat"].ToString(), reader["agama"].ToString(),
                    reader["status_perkawinan"].ToString(), reader["pekerjaan"].ToString(),
                    reader["kewarganegaraan"].ToString()));
                }
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
                Debug.WriteLine(Enkripsi.XorDecrypt(reader["nama"].ToString()));
            }
        }

        //Buat masukin data sidik jari, testing purposes
        public static string[] LoadImagesAsBitmap(string folderPath)
        {
            // Get all image files from the folder
            string[] imageFiles = Directory.GetFiles(folderPath, "*.*")
                                            .Where(f => f.EndsWith(".jpg") || f.EndsWith(".jpeg") || f.EndsWith(".png") || f.EndsWith(".BMP") || f.EndsWith(".bmp"))
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
