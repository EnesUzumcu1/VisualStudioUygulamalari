using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TabuOyunu
{
    public partial class AnaSayfa : Form
    {
        public static bool yalnizBirKereAyarlar = true;
        public static bool yalnizBirKereBasla = true;

        public AnaSayfa()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Ayarlar ayarlarSayfasi = new Ayarlar();
            if (yalnizBirKereAyarlar) {
                ayarlarSayfasi.Show();
                yalnizBirKereAyarlar = false;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TakımAdı takımAdı = new TakımAdı();
            if(yalnizBirKereBasla)
            {
                takımAdı.Show();
                yalnizBirKereBasla = false;
            }
            
        }
    }
}
