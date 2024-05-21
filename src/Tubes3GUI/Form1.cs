using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Tubes3GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Your message here");
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Select File";
            openFileDialog1.InitialDirectory = @"C:\";  //--"C:\\";
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif|All Files|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "")
            { 
                changeAsalImage(openFileDialog1.FileName);
                Bitmap imageSidikJariAsal = new Bitmap(openFileDialog1.FileName);
                this.sidikJariFrom = Utility.ConvertImageToString(imageSidikJariAsal);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if(this.uwuWhatsThis == 10)
            {
                this.TitleLable.Text = "wow an easter egg";
                this.uwuWhatsThis = 0;
            } else
            {
                this.uwuWhatsThis += 1;
            }
            
        }

        private void toggle_toggled(object sender, EventArgs e)
        {
            if (this.toggle.Checked) 
            {
                this.toggle.Text = "KMP";
            }
            else
            {
                this.toggle.Text = "BM";
            }
            

        }

        private void buttonSearch_click(object sender, EventArgs e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            if (this.toggle.Checked) // if using KMP
            {
                Debug.WriteLine("Doing KMP");
            }
            else // if using BM
            {
                Debug.WriteLine("Doing BM");
            }
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            this.waktuEksekusi = elapsedMs;
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void label1_Click_3(object sender, EventArgs e)
        {

        }
    }
}
