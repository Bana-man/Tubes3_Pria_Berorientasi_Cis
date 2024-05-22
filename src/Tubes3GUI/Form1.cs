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
using System.Text.RegularExpressions;
using StringHandler;

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
            float benchMark = 0.5f;
            int value = -1;
            string[] sesuatu = RegexPnySendiri.strToList(sidikJariFrom);
            var watch = System.Diagnostics.Stopwatch.StartNew();
            Debug.WriteLine("CHECKPOINT 1");
            if (this.toggle.Checked) // if using KMP
            {
                Debug.WriteLine("Doing KMP");
                int idxKMP = 0;
                for (int i = 0; i < dbSidikJari.Count; i++)
                {
                    value = kmp.kmpmatch(sidikJariFrom, dbSidikJari[i].Item1);
                    if (value > -1)
                    {
                        idxKMP = i;
                        break;
                    }
                }
                if(value > -1)
                {
                    // show kecocokan 100%, give data
                    this.associatedName = dbSidikJari[idxKMP].Item2;
                    this.sidikJariMatch.Image = Utility.ConvertStringToImage(dbSidikJari[idxKMP].Item1);
                    numberKecocokan.Text = "100 %";
                }
            }
            else // if using BM
            {
                Debug.WriteLine("Doing BM");
                int idxBM = 0;
                for (int i = 0; i < dbSidikJari.Count; i++)
                {
                    value = BoyerMoore.BMMatch(sesuatu, RegexPnySendiri.strToList(dbSidikJari[i].Item1));
                    if (value > -1)
                    {
                        idxBM = i;
                        break;
                    }
                }
                Debug.WriteLine("CHECKPOINT 2");
                if (value > -1)
                {
                    // show kecocokan 100%, give data
                    this.associatedName = dbSidikJari[idxBM].Item2;
                    this.sidikJariMatch.Image = Utility.ConvertStringToImage(dbSidikJari[idxBM].Item1);
                    numberKecocokan.Text = "100 %";
                }
                Debug.WriteLine("CHECKPOINT 3");
            }
            if (value == -1)
            {
                int lcsValue = 0;
                int idx = 0;
                Debug.WriteLine("CHECKPOINT 4");
                for (int i = 0; i < dbSidikJari.Count; i++)
                {
                    int temp = LCS.LongestCommonSubsequence(sesuatu, RegexPnySendiri.strToList(dbSidikJari[i].Item1));
                    Debug.WriteLine(temp);
                    if (temp > lcsValue)
                    {
                        lcsValue = temp;
                        idx = i;
                    }
                }
                Debug.WriteLine("CHECKPOINT 5");
                float persentaseKemiripan = lcsValue / sesuatu.Length;
                if (persentaseKemiripan > benchMark)
                {
                    // show kemiripan, display si gambarnya
                    this.associatedName = dbSidikJari[idx].Item2;
                    this.sidikJariMatch.Image = Utility.ConvertStringToImage(dbSidikJari[idx].Item1);
                    numberKecocokan.Text = persentaseKemiripan.ToString() + " %";
                }
                else
                {
                    // show no match
                    this.sidikJariMatch.Image = Properties.Resources.nomatch;

                }
            }
            watch.Stop();
            Debug.WriteLine("CHECKPOINT 6");
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
