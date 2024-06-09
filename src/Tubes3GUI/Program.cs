using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;
using StringHandler;
//namespace UtilityFunctions;

namespace Tubes3GUI
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //// Memasukkan entri biodata ke database
            //string filePath = "C:\\Users\\irvan\\Documents\\uni\\smt 4\\stima\\tubes\\tubes 3\\Tubes3_Pria_Berorientasi_Cis\\biodata.txt";
            //string[] lines = File.ReadAllLines(filePath);

            //List<List<string>> biodata = new List<List<string>>();
            //foreach (string line in lines)
            //{
            //    string[] entry = line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            //    biodata.Add(new List<string>(entry));
            //}

            //for (int i = 0; i < biodata.Count; i++)
            //{
            //    ConnectDB.InsertBiodata(biodata[i][0], biodata[i][1], biodata[i][2], biodata[i][3], biodata[i][4],
            //        biodata[i][5], biodata[i][6], biodata[i][7], biodata[i][8], biodata[i][9], biodata[i][10]);
            //}

            //// Memasukkan entri sidik jari ke database
            //string[] names = { "Emma Martinez", "Budi Budiman", "John Doe", "Daniel Rodriguez", "Jane Smith", "Sophia Garcia", "Michael Johnson", "Matthew Hernandez", "Isabella Gonzalez", "Emily Davis" };
            //string[] fingerPrints = ConnectDB.LoadFirst10ImagesAsBitmap("C:\\Users\\irvan\\Documents\\uni\\smt 4\\stima\\tubes\\dataset");

            //for (int i = 0; i < fingerPrints.Length; i++)
            //{
            //    ConnectDB.InsertSidikJari(fingerPrints[i], names[i]);
            //}

            //.Muat kembali data biodata dan sidik jari dari database
            ConnectDB.setDataFingerprint();
            ConnectDB.setDataBiodata();

            // Jalankan program
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
