using System;
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
            ((System.ComponentModel.ISupportInitialize)(this.sidikJariAsal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sidikJariMatch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.coverUpHasil)).BeginInit();
            this.SuspendLayout();
            // 
            // listHasil
            // 
            this.listHasil.FormattingEnabled = true;
            this.listHasil.Location = new System.Drawing.Point(817, 139);
            this.listHasil.Name = "listHasil";
            this.listHasil.Size = new System.Drawing.Size(224, 329);
            this.listHasil.TabIndex = 0;
            this.listHasil.Visible = false;
            this.listHasil.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // selectFileButton
            // 
            this.selectFileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectFileButton.Location = new System.Drawing.Point(107, 513);
            this.selectFileButton.Name = "selectFileButton";
            this.selectFileButton.Size = new System.Drawing.Size(146, 57);
            this.selectFileButton.TabIndex = 1;
            this.selectFileButton.Text = "Select Finger Print";
            this.selectFileButton.UseVisualStyleBackColor = true;
            this.selectFileButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // sidikJariAsal
            // 
            this.sidikJariAsal.BackColor = System.Drawing.SystemColors.ControlDark;
            this.sidikJariAsal.Image = global::Tubes3GUI.Properties.Resources.masukan;
            this.sidikJariAsal.Location = new System.Drawing.Point(71, 139);
            this.sidikJariAsal.Name = "sidikJariAsal";
            this.sidikJariAsal.Size = new System.Drawing.Size(224, 329);
            this.sidikJariAsal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.sidikJariAsal.TabIndex = 2;
            this.sidikJariAsal.TabStop = false;
            this.sidikJariAsal.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // sidikJariMatch
            // 
            this.sidikJariMatch.BackColor = System.Drawing.SystemColors.ControlDark;
            this.sidikJariMatch.Image = global::Tubes3GUI.Properties.Resources.match;
            this.sidikJariMatch.Location = new System.Drawing.Point(449, 139);
            this.sidikJariMatch.Name = "sidikJariMatch";
            this.sidikJariMatch.Size = new System.Drawing.Size(224, 329);
            this.sidikJariMatch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.sidikJariMatch.TabIndex = 3;
            this.sidikJariMatch.TabStop = false;
            this.sidikJariMatch.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // coverUpHasil
            // 
            this.coverUpHasil.BackColor = System.Drawing.SystemColors.ControlDark;
            this.coverUpHasil.Image = global::Tubes3GUI.Properties.Resources.biodata;
            this.coverUpHasil.Location = new System.Drawing.Point(817, 139);
            this.coverUpHasil.Name = "coverUpHasil";
            this.coverUpHasil.Size = new System.Drawing.Size(224, 329);
            this.coverUpHasil.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.coverUpHasil.TabIndex = 4;
            this.coverUpHasil.TabStop = false;
            // 
            // TitleLable
            // 
            this.TitleLable.AutoSize = true;
            this.TitleLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLable.Location = new System.Drawing.Point(138, 44);
            this.TitleLable.Name = "TitleLable";
            this.TitleLable.Size = new System.Drawing.Size(843, 55);
            this.TitleLable.TabIndex = 5;
            this.TitleLable.Text = "Aplikasi C# Tubes 3 Strategi Algoritma";
            this.TitleLable.Click += new System.EventHandler(this.label1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1139, 678);
            this.Controls.Add(this.TitleLable);
            this.Controls.Add(this.coverUpHasil);
            this.Controls.Add(this.sidikJariMatch);
            this.Controls.Add(this.sidikJariAsal);
            this.Controls.Add(this.selectFileButton);
            this.Controls.Add(this.listHasil);
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
       
        //private string image

        public void changeAsalImage(string imageLocation)
        {
            this.sidikJariAsal.ImageLocation = imageLocation;
        }

        private PictureBox coverUpHasil;
        private Label TitleLable;
    }
}

