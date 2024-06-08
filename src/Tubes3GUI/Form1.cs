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
                this.sidikJariFrom = Utility.makeSubstringOfImage(imageSidikJariAsal);
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

        public static void PrintDictionaryContents(Dictionary<string, float> dictionary)
        {
            if (dictionary == null || dictionary.Count == 0)
            {
                Console.WriteLine("The dictionary is empty or null.");
                return;
            }

            foreach (var kvp in dictionary)
            {
                Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
            }
        }

        private void buttonSearch_click(object sender, EventArgs e)
        {
            kemiripanMap.Clear();
            float benchMark = 50;
            int value = -1;
            string[] sesuatu = RegexPnySendiri.strToList(sidikJariFrom); //
            for(int i = 0; i < sesuatu.Length; i++)
            {
                Console.Write(sesuatu[i]);
            }
            Console.WriteLine();
            Console.WriteLine(dbSidikJari.Count);
            var watch = System.Diagnostics.Stopwatch.StartNew();
            Debug.WriteLine("CHECKPOINT 1");
            if (this.toggle.Checked) // if using KMP
            {
                Debug.WriteLine("Doing KMP");
                for (int i = 0; i < dbSidikJari.Count; i++)
                {
                    value = kmp.kmpmatch(RegexPnySendiri.strToList(dbSidikJari[i].Item1), sesuatu); // TODO : CHANGE SIDIKJARIFROM TO SESUATU
                    if (value > -1)
                    {
                        Console.WriteLine("KMP ditemukan");
                        kemiripanMap.Add(dbSidikJari[i].Item2,(float) 100);
                        this.associatedName = dbSidikJari[i].Item2;
                        break;
                    }
                }
            }
            else // if using BM
            {
                int idxBM = 0;
                for (int i = 0; i < dbSidikJari.Count; i++)
                {
                    value = BoyerMoore.BMMatch(RegexPnySendiri.strToList(dbSidikJari[i].Item1),sesuatu);
                    if (value > -1)
                    {
                        Console.WriteLine("BM ditemukan");
                        kemiripanMap.Add(dbSidikJari[i].Item2,(float) 100);
                        this.associatedName = dbSidikJari[i].Item2;
                        break;
                    }
                }
            }
            for (int i = 0; i < dbSidikJari.Count; i++)
            {
            float temp = LCS.LongestCommonSubsequence(sesuatu, RegexPnySendiri.strToList(dbSidikJari[i].Item1));
                if (value > -1)
                {
                    float persentaseKemiripan = temp * 99;
                    if (!dbSidikJari[i].Item2.Equals(this.associatedName) && persentaseKemiripan > benchMark)
                    {
                        kemiripanMap.Add(dbSidikJari[i].Item2, persentaseKemiripan); // TODO: REVISI RUMUS
                    }
                }
                else
                {
                    float persentaseKemiripan = temp * 99;
                    if (persentaseKemiripan > benchMark)
                    {
                        kemiripanMap.Add(dbSidikJari[i].Item2, persentaseKemiripan); // TODO: REVISI RUMUS
                    }
                }
            }
            string numberTobeShown;
            string imageTobeShown;
            KeyValuePair<String, float> maxPair = new KeyValuePair<string, float>("default", 0); ;
            if (kemiripanMap.Count > 0) {
                maxPair = kemiripanMap.Aggregate((l, r) => l.Value > r.Value ? l : r);
            }
            numberTobeShown = maxPair.Value.ToString();
            Console.WriteLine("nama orang termirip: ");
            Console.WriteLine(maxPair.Key.ToString());
            if ( maxPair.Value > benchMark)
            {
                for (int i = 0; i < dbSidikJari.Count; i++)
                {
                    if (dbSidikJari[i].Item2 == maxPair.Key)
                    {
                        imageTobeShown = dbSidikJari[i].Item1;
                        this.sidikJariMatch.Image = Utility.ConvertStringToImage(imageTobeShown);
                        break;
                    }
                }
            }
            else
            {
                this.sidikJariMatch.Image = Properties.Resources.nomatch;
            }
            numberKecocokan.Text = numberTobeShown + " %";
            //this.coverUpHasil.Image = null;
            this.listHasil.Items.Clear();
            this.listHasil.Items.Add("NIK | Nama | Tempat Lahir | Tanggal Lahir | Jenis Kelamin | Golongan Darah | Alamat | Agama | Status Perkawinan | Pekerjaan | Kewarganegaraan ");
            //////
            int foundValue = -1; // value kalau KMP atau bm ditemukan, used as a flag
            List<string> biodataygDitampilkan = new List<string>();
            if (this.toggle.Checked) // if using KMP
            {
                Debug.WriteLine("Doing KMP");
                Console.WriteLine(kemiripanMap.Count);
                foreach (KeyValuePair<string, float> entry in kemiripanMap)
                {
                    for (int j = 0; j < dbBiodata.Count; j++)
                    {
                        string[] regexOfName = RegexPnySendiri.strToRgx(dbBiodata[j].Nama);
                        int idxNamaKMP = kmp.kmpmatch(RegexPnySendiri.strToList(entry.Key),regexOfName);
                        if (idxNamaKMP > -1)
                        {
                            Debug.WriteLine("KMP ditemukan");
                            foundValue = idxNamaKMP;
                            biodataygDitampilkan.Add(dbBiodata[j].GetFormattedData());
                            break;
                        }
                    }
                    if (foundValue == -1)
                    {
                        List<String> similarNames = new List<String>();
                        for (int j = 0; j < dbBiodata.Count; j++)
                        {
                            string[] regexOfName = RegexPnySendiri.strToRgx(dbBiodata[j].Nama);

                            float temp2 = LCS.LongestCommonSubsequence(regexOfName, RegexPnySendiri.strToList(entry.Key));
                            float kemiripanNama = temp2 * 99;
                            if (kemiripanNama > 80)
                            {
                                similarNames.Add(dbBiodata[j].GetFormattedData());
                            }
                        }
                        biodataygDitampilkan.Add(similarNames.Last());
                    }
                }
            }
            else 
            {   
                Console.WriteLine("count of thingy");
                Console.WriteLine(kemiripanMap.Count);
                foreach (KeyValuePair<string, float> entry in kemiripanMap)
                {
                    for (int j = 0; j < dbBiodata.Count; j++)
                    {
                        string[] regexOfName = RegexPnySendiri.strToList(dbBiodata[j].Nama);
                        int idxNamaBM = BoyerMoore.BMMatch(regexOfName,RegexPnySendiri.strToRgx(entry.Key));
                        Console.WriteLine("bm");
                        Console.WriteLine(idxNamaBM);
                        if (idxNamaBM > -1)
                        {
                            Debug.WriteLine("BM ditemukan");
                            foundValue = idxNamaBM;
                            biodataygDitampilkan.Add(dbBiodata[j].GetFormattedData());
                            break;
                        }
                    }
                    if (foundValue == -1)
                    {
                        List<String> similarNames = new List<String>();
                        for (int i = 0; i < dbBiodata.Count; i++)
                        {
                            string[] regexOfName = RegexPnySendiri.strToList(dbBiodata[i].Nama);

                            float temp2 = LCS.LongestCommonSubsequence(regexOfName, RegexPnySendiri.strToRgx(entry.Key));
                            float kemiripanNama = temp2 * 99;
                            Console.WriteLine("lcs nama");
                            Console.WriteLine(dbBiodata[i].Nama);
                            Console.WriteLine(entry.Key);
                            Console.WriteLine(kemiripanNama.ToString());
                            if (kemiripanNama > 10)
                            {
                                similarNames.Add(dbBiodata[i].GetFormattedData());
                            }
                        }
                        if (similarNames.Count > 0)
                        {
                            similarNames.Sort();
                            biodataygDitampilkan.Add(similarNames.Last());
                        }
                    }

                }
            }
            ////// save

            /// weird bug found here, originally handles for duplicate data, it detects it as malware ?!?!
            //foreach (KeyValuePair<string, float> entry in kemiripanMap)
            //{
            //    for (int j = 0; j < dbBiodata.Count; j++)
            //    {
            //        string[] regexOfName = RegexPnySendiri.strToList(dbBiodata[j].Nama);
            //        int temp2 = LCS.LongestCommonSubsequence(regexOfName, RegexPnySendiri.strToList(entry.Key));
            //        float kemiripanNama = ((float)temp2 / regexOfName.Length) * 100;
            //        if (kemiripanNama > 95)
            //        {
            //            biodataygDitampilkan.Add(dbBiodata[j].GetFormattedData());
            //            break;
            //        }
                    
            //    }
            //}
            //////ends here


            //Debug.WriteLine(biodataygDitampilkan.Count);
            for (int i = 0; i < biodataygDitampilkan.Count; i++)
            {
                listHasil.Items.Add(biodataygDitampilkan[i]);
            }
            //////
            this.listHasil.Refresh();
            watch.Stop();
            Debug.WriteLine("CHECKPOINT 6");
            var elapsedMs = watch.ElapsedMilliseconds;
            this.waktuEksekusi = elapsedMs;
            numberWaktu.Text = this.waktuEksekusi.ToString();
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

        private void coverUpHasil_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
                    }
    }
}
