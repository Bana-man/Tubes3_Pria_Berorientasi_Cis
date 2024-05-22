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
            Bitmap image = new Bitmap("C:/Users/Sean Nugroho/Pictures/ptrr.png");
            //var watch = System.Diagnostics.Stopwatch.StartNew();
            string integerList = Utility.ConvertImageToString(image);
            Debug.WriteLine(integerList);
            //watch.Stop();
            //var elapsedMs = watch.ElapsedMilliseconds;
            //string[] names = { "Emma Martinez", "Budi Budiman", "John Doe", "Daniel Rodriguez", "Jane Smith", "Sophia Garcia", "Michael Johnson" };
            //string[] fingerPrints = ConnectDB.LoadFirst7ImagesAsBitmap("C:/Users/Sean Nugroho/Documents/fingerprintsamples");
            //for (int i = 0; i < fingerPrints.Length; i++)
            //{
            //    ConnectDB.InsertSidikJari(fingerPrints[i], names[i]);
            //}
            ConnectDB.setDataFingerprint();
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
