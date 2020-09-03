using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace TabuOyunu
{
    public partial class OyunSayfası : Form 
    {
        int pasHakki = 5;
        int turSayisi =1;
        int maxTurSayisi;
        int siraNumarasi = 0;
        int sure;
        int takimSayisi;
        int puan = 0;

        int takimPuani1 = 0;
        int takimPuani2 = 0;
        int takimPuani3 = 0;
        int takimPuani4 = 0;

        string takimAdi1;
        string takimAdi2;
        string takimAdi3;
        string takimAdi4;

        string query;

        ITakimBilgileri ilktakim;
        ITakimBilgileri ikincitakim;
        ITakimBilgileri ucuncutakim;
        ITakimBilgileri dorduncutakim;
        List<ITakimBilgileri> takimListesi = new List<ITakimBilgileri>();
        List<int> uretilenRakamlar = new List<int>();
        Database database;

        SQLiteCommand command;
        SQLiteDataReader sonuc;

        private readonly Random _random = new Random();

        public OyunSayfası()
        {
            InitializeComponent();      
        }

        private void OyunSayfası_Load(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reload();

            takimAdi1 = Properties.Settings.Default.TakımAdı1;
            takimAdi2 = Properties.Settings.Default.TakımAdı2;
            takimAdi3 = Properties.Settings.Default.TakımAdı3;
            takimAdi4 = Properties.Settings.Default.TakımAdı4;

            sure = Properties.Settings.Default.Sure;

            takimSayisi = Properties.Settings.Default.TakımSayisi;

            maxTurSayisi = Properties.Settings.Default.TurSayisi;

            ilktakim = new TakimBilgileri(takimAdi1, takimPuani1);
            ikincitakim = new TakimBilgileri(takimAdi2, takimPuani2);
            ucuncutakim = new TakimBilgileri(takimAdi3, takimPuani3);
            dorduncutakim = new TakimBilgileri(takimAdi4, takimPuani4);

            switch (takimSayisi)
            {
                case 2:
                    takimListesi.Add(ilktakim);
                    takimListesi.Add(ikincitakim);

                    label2.Text = ilktakim.takimAdi;
                    label3.Text = ikincitakim.takimAdi;

                    label6.Text = ilktakim.takimPuani.ToString();
                    label7.Text = ikincitakim.takimPuani.ToString();
                    break;
                case 3:
                    takimListesi.Add(ilktakim);
                    takimListesi.Add(ikincitakim);
                    takimListesi.Add(ucuncutakim);

                    label2.Text = ilktakim.takimAdi;
                    label3.Text = ikincitakim.takimAdi;
                    label4.Text = ucuncutakim.takimAdi;
                    label4.Visible = true;

                    label6.Text = ilktakim.takimPuani.ToString();
                    label7.Text = ikincitakim.takimPuani.ToString();
                    label8.Text = ucuncutakim.takimPuani.ToString();
                    label8.Visible = true;
                    break;
                case 4:
                    takimListesi.Add(ilktakim);
                    takimListesi.Add(ikincitakim);
                    takimListesi.Add(ucuncutakim);
                    takimListesi.Add(dorduncutakim);

                    label2.Text = ilktakim.takimAdi;
                    label3.Text = ikincitakim.takimAdi;
                    label4.Text = ucuncutakim.takimAdi;
                    label5.Text = dorduncutakim.takimAdi;
                    label4.Visible = true;
                    label5.Visible = true;

                    label6.Text = ilktakim.takimPuani.ToString();
                    label7.Text = ikincitakim.takimPuani.ToString();
                    label8.Text = ucuncutakim.takimPuani.ToString();
                    label9.Text = dorduncutakim.takimPuani.ToString();
                    label8.Visible = true;
                    label9.Visible = true;
                    break;
            }
            label1.Text = pasHakki.ToString();
            sureLabel.Text = sure.ToString();
            label12.Text = turSayisi + ". Tur";
            kazananTakimLabel.Visible = false;
        }

        private void sureTimer_Tick(object sender, EventArgs e)
        {
            if(sure > 0) {
                --sure;
                sureLabel.Text = sure.ToString();
                if (sure == 0)
                {
                    oyunPanel.Visible = false;
                    bilgiPanel.Visible = true;
                    pasHakki = 5;
                    label1.Text = pasHakki.ToString();
                    label6.Text = ilktakim.takimPuani.ToString();
                    label7.Text = ikincitakim.takimPuani.ToString();
                    label8.Text = ucuncutakim.takimPuani.ToString();
                    label9.Text = dorduncutakim.takimPuani.ToString();
                    puan = 0;
                    if(turSayisi == maxTurSayisi && takimListesi.Count-siraNumarasi == 0)
                    {
                        baslatButonu.Enabled = false;
                        baslatButonu.Text = "Oyun Bitti";                        
                        //Birinci olan takımı yazdırma 
                        int buyuktur;
                        bool beraberlikYok = true; 
                        for(int i = 0; i < takimListesi.Count; i++)
                        {
                            buyuktur = 0;
                            for(int j = 0; j < takimListesi.Count; j++) {
                                if (takimListesi[i].takimPuani > takimListesi[j].takimPuani)
                                {
                                    buyuktur++;
                                    if(buyuktur == takimListesi.Count - 1)
                                    {
                                        kazananTakimLabel.Visible = true;
                                        kazananTakimLabel.Text = "Kazanan Takım : " + takimListesi[i].takimAdi;
                                        beraberlikYok = false;
                                    }
                                }                                
                            }
                            
                        }
                        if (beraberlikYok)
                        {
                            kazananTakimLabel.Visible = true;
                            kazananTakimLabel.Text = "Kazanan Takım Yok.";
                        }
                        //Birinci olan takımı yazdırma sonu
                    }
                    database.closeConnection();
                    sure = Properties.Settings.Default.Sure;
                    sureTimer.Enabled = false;                    
                }
            }
            
        }

        private void baslatButonu_Click(object sender, EventArgs e)
        {           
            sureTimer.Enabled = true;                       
            bilgiPanel.Visible = false;
            oyunPanel.Visible = true;
            sureLabel.Text = sure.ToString();
            puanLabel.Text = puan.ToString();

            database = new Database();
            query = "SELECT * FROM kelimeler WHERE ID=@ID";
            command = new SQLiteCommand(query, database.baglanti);
            command.Parameters.AddWithValue("@ID", random_Sayi_uretici(1, 4386));
            database.openConnection();
            sonuc = command.ExecuteReader();
            sonuc.Read();
            anlatilacakKelimeLbl.Text = sonuc["AnlatilanKelime"].ToString();
            tabu1Lbl.Text = sonuc["Tabu1"].ToString();
            tabu2Lbl.Text = sonuc["Tabu2"].ToString();
            tabu3Lbl.Text = sonuc["Tabu3"].ToString();
            tabu4Lbl.Text = sonuc["Tabu4"].ToString();
            tabu5Lbl.Text = sonuc["Tabu5"].ToString();
            //database.closeConnection();

            if (siraNumarasi < takimListesi.Count)
            {                
                takimAdiLabel.Text = takimListesi[siraNumarasi].takimAdi;
                puanLabel.Text = puan.ToString();
                siraNumarasi++;
            }
            else
            {
                siraNumarasi = 0;
                takimAdiLabel.Text = takimListesi[siraNumarasi].takimAdi;
                puanLabel.Text = puan.ToString();
                siraNumarasi++;
                turSayisi++;
                label12.Text = turSayisi + ". Tur";
            }

        }

        private void dogruButonu_Click(object sender, EventArgs e)
        {
            takimListesi[siraNumarasi-1].takimPuani++;
            puanLabel.Text = (++puan).ToString();
            command = new SQLiteCommand(query, database.baglanti);
            command.Parameters.AddWithValue("@ID", random_Sayi_uretici(1, 4386));            
            sonuc = command.ExecuteReader();
            sonuc.Read();
            anlatilacakKelimeLbl.Text = sonuc["AnlatilanKelime"].ToString();
            tabu1Lbl.Text = sonuc["Tabu1"].ToString();
            tabu2Lbl.Text = sonuc["Tabu2"].ToString();
            tabu3Lbl.Text = sonuc["Tabu3"].ToString();
            tabu4Lbl.Text = sonuc["Tabu4"].ToString();
            tabu5Lbl.Text = sonuc["Tabu5"].ToString();
        }

        private void pasButonu_Click(object sender, EventArgs e)
        {
            if(pasHakki > 0)
            {
                --pasHakki;
                label1.Text = pasHakki.ToString();
                command = new SQLiteCommand(query, database.baglanti);
                command.Parameters.AddWithValue("@ID", random_Sayi_uretici(1, 4386));
                sonuc = command.ExecuteReader();
                sonuc.Read();
                anlatilacakKelimeLbl.Text = sonuc["AnlatilanKelime"].ToString();
                tabu1Lbl.Text = sonuc["Tabu1"].ToString();
                tabu2Lbl.Text = sonuc["Tabu2"].ToString();
                tabu3Lbl.Text = sonuc["Tabu3"].ToString();
                tabu4Lbl.Text = sonuc["Tabu4"].ToString();
                tabu5Lbl.Text = sonuc["Tabu5"].ToString();
            }
        }

        private void tabuButonu_Click(object sender, EventArgs e)
        {
            takimListesi[siraNumarasi-1].takimPuani--;
            puanLabel.Text = (--puan).ToString();
            command = new SQLiteCommand(query, database.baglanti);
            command.Parameters.AddWithValue("@ID", random_Sayi_uretici(1, 4386));
            sonuc = command.ExecuteReader();
            sonuc.Read();
            anlatilacakKelimeLbl.Text = sonuc["AnlatilanKelime"].ToString();
            tabu1Lbl.Text = sonuc["Tabu1"].ToString();
            tabu2Lbl.Text = sonuc["Tabu2"].ToString();
            tabu3Lbl.Text = sonuc["Tabu3"].ToString();
            tabu4Lbl.Text = sonuc["Tabu4"].ToString();
            tabu5Lbl.Text = sonuc["Tabu5"].ToString();
        }

        public int random_Sayi_uretici(int baslangic, int bitis)
        {
            bool donguKontrol = true;
            int x = _random.Next(baslangic, bitis);
            if (!uretilenRakamlar.Contains(x))
            {
                uretilenRakamlar.Add(x);
                donguKontrol = false;
            }
            while (donguKontrol)
            {
                x = _random.Next(baslangic, bitis);
                if (!uretilenRakamlar.Contains(x))
                {
                    uretilenRakamlar.Add(x);
                    donguKontrol = false;
                    break;
                }
                
            }
            return x;
        }


    }
}
