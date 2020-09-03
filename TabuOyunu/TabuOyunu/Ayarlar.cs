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
    public partial class Ayarlar : Form
    {
        public Ayarlar()
        {
            InitializeComponent();
        }

        private void Ayarlar_Load(object sender, EventArgs e)
        {
            sureComboBox.Text = Properties.Settings.Default.Sure.ToString();
            takimComboBox.Text = Properties.Settings.Default.TakımSayisi.ToString();
            turComboBox.Text = Properties.Settings.Default.TurSayisi.ToString();
            //form açılınca farklı bir yere odaklanmasını sağlıyoruz. Yoksa sureComboBox'a odaklanıyor.
            this.ActiveControl = label1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Sure = Convert.ToInt32(sureComboBox.Text);
            Properties.Settings.Default.TakımSayisi = Convert.ToInt32(takimComboBox.Text);
            Properties.Settings.Default.TurSayisi = Convert.ToInt32(turComboBox.Text);
            Properties.Settings.Default.Save();
            MessageBox.Show("Kaydedildi.");
            Ayarlar.ActiveForm.Close();
        }

        private void Ayarlar_FormClosing(object sender, FormClosingEventArgs e)
        {
            AnaSayfa.yalnizBirKereAyarlar = true;
        }
    }
}
