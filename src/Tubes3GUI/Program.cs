using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
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
            var watch = System.Diagnostics.Stopwatch.StartNew();
            List<char> integerList = Utility.ConvertImageToBinaryIntegers(image);
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            // Print the integers
            Debug.WriteLine("Elapsed time: ");
            Debug.WriteLine(elapsedMs);
            //foreach (char c in integerList)
            //{
            //    Debug.WriteLine(c);
            //}
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
