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
            // Use a verbatim string literal to handle file paths correctly
            //string[] names = { "Emma Martinez", "Budi Budiman", "John Doe", "Daniel Rodriguez", "Jane Smith", "Sophia Garcia", "Michael Johnson", "Matthew Hernandez", "Isabella Gonzalez", "Emily Davis" };
            //string[] fingerPrints = ConnectDB.LoadFirst10ImagesAsBitmap("C:\\Users\\irvan\\Documents\\uni\\smt 4\\stima\\tubes\\dataset");
            //for (int i = 0; i < fingerPrints.Length; i++)
            //{
            //    ConnectDB.InsertSidikJari(fingerPrints[i], names[i]);
            //}
            ConnectDB.setDataFingerprint();
            ConnectDB.setDataBiodata();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
