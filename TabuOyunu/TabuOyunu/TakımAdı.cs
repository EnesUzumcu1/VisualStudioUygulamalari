using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TabuOyunu
{
    public partial class TakımAdı : Form
    {
        int takımSayisi;
        public TakımAdı()
        {
            InitializeComponent();
        }

        private void TakımAdı_Load(object sender, EventArgs e)
        {
            this.ActiveControl = label1;
            takımSayisi = Properties.Settings.Default.TakımSayisi;
            switch (takımSayisi)
            {
                case 2:
                    label3.Visible = false;
                    label4.Visible = false;
                    textBox3.Visible = false;
                    textBox4.Visible = false;
                    break;
                case 3:
                    label4.Visible = false;
                    textBox4.Visible = false;
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OyunSayfası oyunSayfası = new OyunSayfası();
            if(takımSayisi == 2)
            {
                Properties.Settings.Default.TakımAdı1 = textBox1.Text;
                Properties.Settings.Default.TakımAdı2 = textBox2.Text;
                Properties.Settings.Default.Save();
                MessageBox.Show("Takım adları kaydedildi.");
                TakımAdı.ActiveForm.Close();
                oyunSayfası.Show();
            }
            else if(takımSayisi == 3)
            {
                Properties.Settings.Default.TakımAdı1 = textBox1.Text;
                Properties.Settings.Default.TakımAdı2 = textBox2.Text;
                Properties.Settings.Default.TakımAdı3 = textBox3.Text;
                Properties.Settings.Default.Save();
                MessageBox.Show("Takım adları kaydedildi.");
                TakımAdı.ActiveForm.Close();
                oyunSayfası.Show();                
            }
            else if(takımSayisi == 4)
            {
                Properties.Settings.Default.TakımAdı1 = textBox1.Text;
                Properties.Settings.Default.TakımAdı2 = textBox2.Text;
                Properties.Settings.Default.TakımAdı3 = textBox3.Text;
                Properties.Settings.Default.TakımAdı4 = textBox4.Text;
                Properties.Settings.Default.Save();
                MessageBox.Show("Takım adları kaydedildi.");
                TakımAdı.ActiveForm.Close();
                oyunSayfası.Show();                
            }
            else
            {
                MessageBox.Show("Bir hata oluştu.");
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
        }

        private void textBox4_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
            {
                textBox1.Text = "Takım 1";
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Takım 2";
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = "Takım 3";
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                textBox4.Text = "Takım 4";
            }
        }

        private void TakımAdı_FormClosing(object sender, FormClosingEventArgs e)
        {
            AnaSayfa.yalnizBirKereBasla = true;
        }
    }
}
