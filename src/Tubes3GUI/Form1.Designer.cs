using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Tubes3GUI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listHasil = new System.Windows.Forms.ListBox();
            this.selectFileButton = new System.Windows.Forms.Button();
            this.sidikJariAsal = new System.Windows.Forms.PictureBox();
            this.sidikJariMatch = new System.Windows.Forms.PictureBox();
            this.coverUpHasil = new System.Windows.Forms.PictureBox();
            this.TitleLable = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.toggle = new System.Windows.Forms.CheckBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.waktuPencarian = new System.Windows.Forms.Label();
            this.persenCocok = new System.Windows.Forms.Label();
            this.numberKecocokan = new System.Windows.Forms.Label();
            this.numberWaktu = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.sidikJariAsal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sidikJariMatch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.coverUpHasil)).BeginInit();
            this.SuspendLayout();
            // 
            // listHasil
            // 
            this.listHasil.FormattingEnabled = true;
            this.listHasil.ItemHeight = 25;
            this.listHasil.Location = new System.Drawing.Point(1634, 267);
            this.listHasil.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.listHasil.Name = "listHasil";
            this.listHasil.Size = new System.Drawing.Size(444, 629);
            this.listHasil.TabIndex = 0;
            this.listHasil.Visible = false;
            this.listHasil.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // selectFileButton
            // 
            this.selectFileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectFileButton.Location = new System.Drawing.Point(108, 987);
            this.selectFileButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.selectFileButton.Name = "selectFileButton";
            this.selectFileButton.Size = new System.Drawing.Size(292, 110);
            this.selectFileButton.TabIndex = 1;
            this.selectFileButton.Text = "Select Finger Print";
            this.selectFileButton.UseVisualStyleBackColor = true;
            this.selectFileButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // sidikJariAsal
            // 
            this.sidikJariAsal.BackColor = System.Drawing.SystemColors.ControlDark;
            this.sidikJariAsal.Image = global::Tubes3GUI.Properties.Resources.masukan;
            this.sidikJariAsal.Location = new System.Drawing.Point(142, 267);
            this.sidikJariAsal.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.sidikJariAsal.Name = "sidikJariAsal";
            this.sidikJariAsal.Size = new System.Drawing.Size(448, 633);
            this.sidikJariAsal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.sidikJariAsal.TabIndex = 2;
            this.sidikJariAsal.TabStop = false;
            this.sidikJariAsal.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // sidikJariMatch
            // 
            this.sidikJariMatch.BackColor = System.Drawing.SystemColors.ControlDark;
            this.sidikJariMatch.Image = global::Tubes3GUI.Properties.Resources.match;
            this.sidikJariMatch.Location = new System.Drawing.Point(898, 267);
            this.sidikJariMatch.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.sidikJariMatch.Name = "sidikJariMatch";
            this.sidikJariMatch.Size = new System.Drawing.Size(448, 633);
            this.sidikJariMatch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.sidikJariMatch.TabIndex = 3;
            this.sidikJariMatch.TabStop = false;
            this.sidikJariMatch.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // coverUpHasil
            // 
            this.coverUpHasil.BackColor = System.Drawing.SystemColors.ControlDark;
            this.coverUpHasil.Image = global::Tubes3GUI.Properties.Resources.biodata;
            this.coverUpHasil.Location = new System.Drawing.Point(1634, 267);
            this.coverUpHasil.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.coverUpHasil.Name = "coverUpHasil";
            this.coverUpHasil.Size = new System.Drawing.Size(448, 633);
            this.coverUpHasil.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.coverUpHasil.TabIndex = 4;
            this.coverUpHasil.TabStop = false;
            // 
            // TitleLable
            // 
            this.TitleLable.AutoSize = true;
            this.TitleLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLable.Location = new System.Drawing.Point(276, 85);
            this.TitleLable.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.TitleLable.Name = "TitleLable";
            this.TitleLable.Size = new System.Drawing.Size(1679, 108);
            this.TitleLable.TabIndex = 5;
            this.TitleLable.Text = "Aplikasi C# Tubes 3 Strategi Algoritma";
            this.TitleLable.Click += new System.EventHandler(this.label1_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(0, 0);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(150, 29);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // toggle
            // 
            this.toggle.Appearance = System.Windows.Forms.Appearance.Button;
            this.toggle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toggle.Location = new System.Drawing.Point(550, 987);
            this.toggle.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.toggle.Name = "toggle";
            this.toggle.Size = new System.Drawing.Size(292, 110);
            this.toggle.TabIndex = 7;
            this.toggle.Text = "BM";
            this.toggle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toggle.UseVisualStyleBackColor = true;
            this.toggle.CheckedChanged += new System.EventHandler(this.toggle_toggled);
            // 
            // searchButton
            // 
            this.searchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchButton.Location = new System.Drawing.Point(1018, 985);
            this.searchButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(292, 110);
            this.searchButton.TabIndex = 8;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.buttonSearch_click);
            // 
            // waktuPencarian
            // 
            this.waktuPencarian.AutoSize = true;
            this.waktuPencarian.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.waktuPencarian.Location = new System.Drawing.Point(1426, 985);
            this.waktuPencarian.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.waktuPencarian.Name = "waktuPencarian";
            this.waktuPencarian.Size = new System.Drawing.Size(379, 37);
            this.waktuPencarian.TabIndex = 9;
            this.waktuPencarian.Text = "Waktu Pencarian            :";
            this.waktuPencarian.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // persenCocok
            // 
            this.persenCocok.AutoSize = true;
            this.persenCocok.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.persenCocok.Location = new System.Drawing.Point(1426, 1083);
            this.persenCocok.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.persenCocok.Name = "persenCocok";
            this.persenCocok.Size = new System.Drawing.Size(371, 37);
            this.persenCocok.TabIndex = 10;
            this.persenCocok.Text = "Persentase Kecocokan  :";
            this.persenCocok.Click += new System.EventHandler(this.label2_Click);
            // 
            // numberKecocokan
            // 
            this.numberKecocokan.AutoSize = true;
            this.numberKecocokan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numberKecocokan.Location = new System.Drawing.Point(1808, 1083);
            this.numberKecocokan.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.numberKecocokan.Name = "numberKecocokan";
            this.numberKecocokan.Size = new System.Drawing.Size(99, 37);
            this.numberKecocokan.TabIndex = 11;
            this.numberKecocokan.Text = "xxx %";
            this.numberKecocokan.Click += new System.EventHandler(this.label1_Click_2);
            // 
            // numberWaktu
            // 
            this.numberWaktu.AutoSize = true;
            this.numberWaktu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numberWaktu.Location = new System.Drawing.Point(1808, 987);
            this.numberWaktu.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.numberWaktu.Name = "numberWaktu";
            this.numberWaktu.Size = new System.Drawing.Size(114, 37);
            this.numberWaktu.TabIndex = 13;
            this.numberWaktu.Text = "xxx ms";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2278, 1304);
            this.Controls.Add(this.numberWaktu);
            this.Controls.Add(this.numberKecocokan);
            this.Controls.Add(this.persenCocok);
            this.Controls.Add(this.waktuPencarian);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.toggle);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.TitleLable);
            this.Controls.Add(this.coverUpHasil);
            this.Controls.Add(this.sidikJariMatch);
            this.Controls.Add(this.sidikJariAsal);
            this.Controls.Add(this.selectFileButton);
            this.Controls.Add(this.listHasil);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.sidikJariAsal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sidikJariMatch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.coverUpHasil)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listHasil;
        private System.Windows.Forms.Button selectFileButton;
        private System.Windows.Forms.PictureBox sidikJariAsal;
        private System.Windows.Forms.PictureBox sidikJariMatch;
        private int uwuWhatsThis = 0;
        private long waktuEksekusi = -1;
        private long tingkatKecocokan = -1;
        public string sidikJariFrom = "";
        public static List<(string,string)> dbSidikJari = new List<(string, string)>();
        public string associatedName = "";
       
        //private string image

        public void changeAsalImage(string imageLocation)
        {
            this.sidikJariAsal.ImageLocation = imageLocation;
        }

        private PictureBox coverUpHasil;
        private Label TitleLable;
        private CheckBox checkBox1;
        private CheckBox toggle;
        //kalau togglenya checked berarti menggunakan algoritma BM
        private Button searchButton;
        private Label waktuPencarian;
        private Label persenCocok;
        private Label numberKecocokan;
        private Label numberWaktu;
    }
}

