using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Boya_Kazan
{
    public partial class Form1 : Form
    {        
        int satir1 ;
        int satir2 ;
        int satir3 ;
        int satir4 ;
        int satir5 ;
        int satir6 ;
        int satir7 ;
        int satir8 ;
        int satir9 ;
        int satir10;        
        int renkKontrolu = 0;
        int siraRenkKontrol = 0;
        List<int> satirlarList;
        List<Color> renkler = new List<Color>();
        //son hamlede tutulan değerler sırasıyla satır, sütun, renkKontrolü, siraRenkKontrolü
        int[,] sonHamle = new int[,]{{ 0,0,0,0} };
        //6 satır 10 sütun bi matris
        Color[,] koordinatlar = new Color[6,10 ] {
            { SystemColors.Control, SystemColors.Control,SystemColors.Control, SystemColors.Control,SystemColors.Control, SystemColors.Control,SystemColors.Control, SystemColors.Control,SystemColors.Control, SystemColors.Control },
            { SystemColors.Control, SystemColors.Control,SystemColors.Control, SystemColors.Control,SystemColors.Control, SystemColors.Control,SystemColors.Control, SystemColors.Control,SystemColors.Control, SystemColors.Control },
            { SystemColors.Control, SystemColors.Control,SystemColors.Control, SystemColors.Control,SystemColors.Control, SystemColors.Control,SystemColors.Control, SystemColors.Control,SystemColors.Control, SystemColors.Control },
            { SystemColors.Control, SystemColors.Control,SystemColors.Control, SystemColors.Control,SystemColors.Control, SystemColors.Control,SystemColors.Control, SystemColors.Control,SystemColors.Control, SystemColors.Control },
            { SystemColors.Control, SystemColors.Control,SystemColors.Control, SystemColors.Control,SystemColors.Control, SystemColors.Control,SystemColors.Control, SystemColors.Control,SystemColors.Control, SystemColors.Control },
            { SystemColors.Control, SystemColors.Control,SystemColors.Control, SystemColors.Control,SystemColors.Control, SystemColors.Control,SystemColors.Control, SystemColors.Control,SystemColors.Control, SystemColors.Control }
        };
        public Form1()
        {
            InitializeComponent();            
        }    

        private void Form1_Load(object sender, EventArgs e)
        {
            renkler.Add(Color.Red);
            renkler.Add(Color.Yellow);
            textBox1.BackColor = renkler[0];
            textBox2.BackColor = renkler[1];
            geriAlBtn.Enabled = false;
            satirlarList = new List<int> { satir1, satir2, satir3, satir4, satir5, satir6, satir7, satir8, satir9, satir10 };
            for(int i = 0; i < satirlarList.Count; i++)
            {
                satirlarList[i] = Convert.ToInt32(tableLayoutPanel1.RowCount);
                //Satir sayısı bütün değişkenlere atanıyor.
            }
        }

        private void tableLayoutPanel1_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {    
            using (var b = new SolidBrush(koordinatlar[e.Row, e.Column]))
            {
                //e.Graphics.FillRectangle(b, e.CellBounds);
                e.Graphics.FillEllipse(b, e.CellBounds.X+5,e.CellBounds.Y+5,30,30);                
            }
        }
        private void tableLayoutPanel3_CellPaint(object sender, TableLayoutCellPaintEventArgs h)
        {
            int deger;
            if(siraRenkKontrol %2 == 1)
            {
                deger = 1;
            }
            else
            {
                deger = 0;
            }
            h.Graphics.FillEllipse(new SolidBrush(renkler[deger]), h.CellBounds.X+2, h.CellBounds.Y+2, 30, 30);
        }

        private void sutun1Btn_Click(object sender, EventArgs e)
        {            
            tum_kontroller(0, 0);
        }

        private void sutun2Btn_Click(object sender, EventArgs e)
        {            
            tum_kontroller(1, 1);
        }

        private void sutun3Btn_Click(object sender, EventArgs e)
        {            
            tum_kontroller(2, 2);
        }

        private void sutun4Btn_Click(object sender, EventArgs e)
        {
            tum_kontroller(3, 3);
        }

        private void sutun5Btn_Click(object sender, EventArgs e)
        {            
            tum_kontroller(4, 4);
        }

        private void sutun6Btn_Click(object sender, EventArgs e)
        {            
            tum_kontroller(5, 5);
        }

        private void sutun7Btn_Click(object sender, EventArgs e)
        {            
            tum_kontroller(6, 6);
        }

        private void sutun8Btn_Click(object sender, EventArgs e)
        {            
            tum_kontroller(7, 7);
        }

        private void sutun9Btn_Click(object sender, EventArgs e)
        {            
            tum_kontroller(8, 8);
        }

        private void sutun10Btn_Click(object sender, EventArgs e)
        {            
            tum_kontroller(9, 9);            
        }
        public void buton_tikla_renk_degis(int satir,int sutun)
        {
            gizleTimer.Enabled = true;
            if (satir > -1)
            {                
                if (renkKontrolu % 2 == 1)
                {
                    koordinatlar[satir, sutun] = renkler[1];
                    siraRenkKontrol++;
                    renkKontrolu++;
                }
                else
                {
                    koordinatlar[satir, sutun] = renkler[0];
                    siraRenkKontrol++;
                    renkKontrolu++;
                }                
                sonHamle = new int[,] { { satir, sutun, renkKontrolu, siraRenkKontrol} };                
                satir--;
                tableLayoutPanel1.Refresh();
                tableLayoutPanel3.Refresh();
                geriAlBtn.Enabled = true;
            }
        }

        private void gizleTimer_Tick(object sender, EventArgs e)
        {
            sutun1Btn.Enabled = false;
            sutun2Btn.Enabled = false;
            sutun3Btn.Enabled = false;
            sutun4Btn.Enabled = false;
            sutun5Btn.Enabled = false;
            sutun6Btn.Enabled = false;
            sutun7Btn.Enabled = false;
            sutun8Btn.Enabled = false;
            sutun9Btn.Enabled = false;
            sutun10Btn.Enabled = false;
            gosterTimer.Enabled = true;
            gizleTimer.Enabled = false;
        }

        private void gosterTimer_Tick(object sender, EventArgs e)
        {
            sutun1Btn.Enabled = true;
            sutun2Btn.Enabled = true;
            sutun3Btn.Enabled = true;
            sutun4Btn.Enabled = true;
            sutun5Btn.Enabled = true;
            sutun6Btn.Enabled = true;
            sutun7Btn.Enabled = true;
            sutun8Btn.Enabled = true;
            sutun9Btn.Enabled = true;
            sutun10Btn.Enabled = true;
            gosterTimer.Enabled = false;
        }

        private void geriAlBtn_Click(object sender, EventArgs e)
        {            
            koordinatlar[sonHamle[0,0], sonHamle[0,1]] = Color.Empty;
            switch (sonHamle[0, 1])
            {
                case 0:
                    satirlarList[0]++;
                    break;
                case 1:
                    satirlarList[1]++;
                    break;
                case 2:
                    satirlarList[2]++;
                    break;
                case 3:
                    satirlarList[3]++;
                    break;
                case 4:
                    satirlarList[4]++;
                    break;
                case 5:
                    satirlarList[5]++;
                    break;
                case 6:
                    satirlarList[6]++;
                    break;
                case 7:
                    satirlarList[7]++;
                    break;
                case 8:
                    satirlarList[8]++;
                    break;
                case 9:
                    satirlarList[9]++;
                    break;             
            }
            renkKontrolu = --sonHamle[0, 2];
            siraRenkKontrol = --sonHamle[0, 3];
            tableLayoutPanel1.Refresh();
            tableLayoutPanel3.Refresh();
            geriAlBtn.Enabled = false;            
        }

        private void sifirlaBtn_Click(object sender, EventArgs e)
        {
            for(int i = 0;i < tableLayoutPanel1.ColumnCount; i++)
            {
                for(int j = 0; j < tableLayoutPanel1.RowCount; j++)
                {
                    koordinatlar[j, i] = Color.Empty;
                }
            }
            tableLayoutPanel1.Refresh();
            //eski degerler geri yukleniyor.
            for (int i = 0; i < satirlarList.Count; i++)
            {
                satirlarList[i] = Convert.ToInt32(tableLayoutPanel1.RowCount);
                //Satir sayısı bütün değişkenlere atanıyor.
            }
            renkKontrolu = 0;
            siraRenkKontrol = 0;
            sonHamle = new int[,] { { 0, 0, 0, 0 } };
            tableLayoutPanel2.Visible = true;
            tableLayoutPanel3.Refresh();
            label1.Text = "";
            button1.Enabled = true;
            button2.Enabled = true;
        }
        private void sol_ust_sag_alt_ilk(int satir,int sutun)
        {
            try
            {
                //-...
                //.-..
                //..-.
                //...x
                String x1 = koordinatlar[satir, sutun].Name;
                String x2 = koordinatlar[satir-1, sutun-1].Name;
                String x3 = koordinatlar[satir-2, sutun-2].Name;
                String x4 = koordinatlar[satir-3, sutun-3].Name;                
                int deger;
                if(renkKontrolu % 2 == 1)
                {
                    deger = 0;
                }
                else
                {
                    deger = 1;
                }
                if (x1 == x2 && x1 == x3 && x1 == x4)
                {
                    if (deger == 0)
                    {
                        label1.Text = "Kazanan -> Oyuncu 1";
                        tableLayoutPanel2.Visible = false;
                    }
                    else
                    {
                        label1.Text = "Kazanan -> Oyuncu 2";
                        tableLayoutPanel2.Visible = false;
                    }
                }                
            }
            catch
            {

            }
        }
        private void sol_ust_sag_alt_iki(int satir, int sutun)
        {
            try
            {
                //-...
                //.-..
                //..x.
                //...-
                String x1 = koordinatlar[satir, sutun].Name;
                String x2 = koordinatlar[satir + 1, sutun + 1].Name;
                String x3 = koordinatlar[satir - 1, sutun - 1].Name;
                String x4 = koordinatlar[satir - 2, sutun - 2].Name;
                int deger;
                if (renkKontrolu % 2 == 1)
                {
                    deger = 0;
                }
                else
                {
                    deger = 1;
                }
                if (x1 == x2 && x1 == x3 && x1 == x4)
                {
                    if(deger == 0)
                    {
                        label1.Text = "Kazanan -> Oyuncu 1";
                        tableLayoutPanel2.Visible = false;
                    }
                    else
                    {
                        label1.Text = "Kazanan -> Oyuncu 2";
                        tableLayoutPanel2.Visible = false;
                    }
                }
            }
            catch
            {

            }
        }
        private void sol_ust_sag_alt_uc(int satir, int sutun)
        {
            try
            {
                String x1 = koordinatlar[satir , sutun].Name;
                String x2 = koordinatlar[satir - 1, sutun - 1].Name;
                String x3 = koordinatlar[satir + 1, sutun + 1].Name;
                String x4 = koordinatlar[satir + 2, sutun + 2].Name;
                int deger;
                if (renkKontrolu % 2 == 1)
                {
                    deger = 0;
                }
                else
                {
                    deger = 1;
                }
                if (x1 == x2 && x1 == x3 && x1 == x4)
                {
                    if (deger == 0)
                    {
                        label1.Text = "Kazanan -> Oyuncu 1";
                        tableLayoutPanel2.Visible = false;
                    }
                    else
                    {
                        label1.Text = "Kazanan -> Oyuncu 2";
                        tableLayoutPanel2.Visible = false;
                    }
                }
            }
            catch
            {

            }
        }
        private void sol_ust_sag_alt_dort(int satir, int sutun)
        {
            try
            {
                String x1 = koordinatlar[satir , sutun].Name;
                String x2 = koordinatlar[satir + 1, sutun + 1].Name;
                String x3 = koordinatlar[satir + 2, sutun + 2].Name;
                String x4 = koordinatlar[satir + 3, sutun + 3].Name;
                int deger;
                if (renkKontrolu % 2 == 1)
                {
                    deger = 0;
                }
                else
                {
                    deger = 1;
                }
                if (x1 == x2 && x1 == x3 && x1 == x4)
                {
                    if (deger == 0)
                    {
                        label1.Text = "Kazanan -> Oyuncu 1";
                        tableLayoutPanel2.Visible = false;
                    }
                    else
                    {
                        label1.Text = "Kazanan -> Oyuncu 2";
                        tableLayoutPanel2.Visible = false;
                    }
                }
            }
            catch
            {

            }
        }
        private void sol_alt_sag_ust_ilk(int satir, int sutun)
        {
            try
            {
                //...-
                //..-.
                //.-..
                //x...
                String x1 = koordinatlar[satir, sutun].Name;
                String x2 = koordinatlar[satir - 1, sutun + 1].Name;
                String x3 = koordinatlar[satir - 2, sutun + 2].Name;
                String x4 = koordinatlar[satir - 3, sutun + 3].Name;
                int deger;
                if (renkKontrolu % 2 == 1)
                {
                    deger = 0;
                }
                else
                {
                    deger = 1;
                }
                if (x1 == x2 && x1 == x3 && x1 == x4)
                {
                    if (deger == 0)
                    {
                        label1.Text = "Kazanan -> Oyuncu 1";
                        tableLayoutPanel2.Visible = false;
                    }
                    else
                    {
                        label1.Text = "Kazanan -> Oyuncu 2";
                        tableLayoutPanel2.Visible = false;
                    }
                }
            }
            catch
            {

            }
        }
        private void sol_alt_sag_ust_iki(int satir, int sutun)
        {
            try
            {
                //...-
                //..x.
                //.-..
                //-...
                String x1 = koordinatlar[satir , sutun].Name;
                String x2 = koordinatlar[satir - 1, sutun + 1].Name;
                String x3 = koordinatlar[satir + 1, sutun - 1].Name;
                String x4 = koordinatlar[satir + 2, sutun - 2].Name;
                int deger;
                if (renkKontrolu % 2 == 1)
                {
                    deger = 0;
                }
                else
                {
                    deger = 1;
                }
                if (x1 == x2 && x1 == x3 && x1 == x4)
                {
                    if (deger == 0)
                    {
                        label1.Text = "Kazanan -> Oyuncu 1";
                        tableLayoutPanel2.Visible = false;
                    }
                    else
                    {
                        label1.Text = "Kazanan -> Oyuncu 2";
                        tableLayoutPanel2.Visible = false;
                    }
                }
            }
            catch
            {

            }
        }
        private void sol_alt_sag_ust_uc(int satir, int sutun)
        {
            try
            {
                //...-
                //..-.
                //.x..
                //-...
                String x1 = koordinatlar[satir , sutun ].Name;
                String x2 = koordinatlar[satir + 1, sutun - 1].Name;
                String x3 = koordinatlar[satir - 1, sutun + 1].Name;
                String x4 = koordinatlar[satir - 2, sutun + 2].Name;
                int deger;
                if (renkKontrolu % 2 == 1)
                {
                    deger = 0;
                }
                else
                {
                    deger = 1;
                }
                if (x1 == x2 && x1 == x3 && x1 == x4)
                {
                    if (deger == 0)
                    {
                        label1.Text = "Kazanan -> Oyuncu 1";
                        tableLayoutPanel2.Visible = false;
                    }
                    else
                    {
                        label1.Text = "Kazanan -> Oyuncu 2";
                        tableLayoutPanel2.Visible = false;
                    }
                }
            }
            catch
            {

            }
        }
        private void sol_alt_sag_ust_dort(int satir, int sutun)
        {
            try
            {
                //...x
                //..-.
                //.-..
                //-...
                String x1 = koordinatlar[satir , sutun ].Name;
                String x2 = koordinatlar[satir + 1, sutun - 1].Name;
                String x3 = koordinatlar[satir + 2, sutun - 2].Name;
                String x4 = koordinatlar[satir + 3, sutun - 3].Name;
                int deger;
                if (renkKontrolu % 2 == 1)
                {
                    deger = 0;
                }
                else
                {
                    deger = 1;
                }
                if (x1 == x2 && x1 == x3 && x1 == x4)
                {
                    if (deger == 0)
                    {
                        label1.Text = "Kazanan -> Oyuncu 1";
                        tableLayoutPanel2.Visible = false;
                    }
                    else
                    {
                        label1.Text = "Kazanan -> Oyuncu 2";
                        tableLayoutPanel2.Visible = false;
                    }
                }
            }
            catch
            {

            }
        }
        private void yukardan_asagi_ilk(int satir,int sutun)
        {
            try
            {
                String x1 = koordinatlar[satir, sutun].Name;
                String x2 = koordinatlar[satir + 1, sutun ].Name;
                String x3 = koordinatlar[satir + 2, sutun ].Name;
                String x4 = koordinatlar[satir + 3, sutun ].Name;
                int deger;
                if (renkKontrolu % 2 == 1)
                {
                    deger = 0;
                }
                else
                {
                    deger = 1;
                }
                if (x1 == x2 && x1 == x3 && x1 == x4)
                {
                    if (deger == 0)
                    {
                        label1.Text = "Kazanan -> Oyuncu 1";
                        tableLayoutPanel2.Visible = false;
                    }
                    else
                    {
                        label1.Text = "Kazanan -> Oyuncu 2";
                        tableLayoutPanel2.Visible = false;
                    }
                }
            }
            catch
            {

            }
        }
        private void soldan_saga_ilk(int satir,int sutun)
        {
            try
            {
                String x1 = koordinatlar[satir, sutun].Name;
                String x2 = koordinatlar[satir, sutun-1].Name;
                String x3 = koordinatlar[satir, sutun-2].Name;
                String x4 = koordinatlar[satir, sutun-3].Name;
                int deger;
                if (renkKontrolu % 2 == 1)
                {
                    deger = 0;
                }
                else
                {
                    deger = 1;
                }
                if (x1 == x2 && x1 == x3 && x1 == x4)
                {
                    if (deger == 0)
                    {
                        label1.Text = "Kazanan -> Oyuncu 1";
                        tableLayoutPanel2.Visible = false;
                    }
                    else
                    {
                        label1.Text = "Kazanan -> Oyuncu 2";
                        tableLayoutPanel2.Visible = false;
                    }
                }
            }
            catch
            {

            }
        }
        private void soldan_saga_iki(int satir, int sutun)
        {
            try
            {
                String x1 = koordinatlar[satir, sutun+1].Name;
                String x2 = koordinatlar[satir, sutun].Name;
                String x3 = koordinatlar[satir, sutun - 1].Name;
                String x4 = koordinatlar[satir, sutun - 2].Name;
                int deger;
                if (renkKontrolu % 2 == 1)
                {
                    deger = 0;
                }
                else
                {
                    deger = 1;
                }
                if (x1 == x2 && x1 == x3 && x1 == x4)
                {
                    if (deger == 0)
                    {
                        label1.Text = "Kazanan -> Oyuncu 1";
                        tableLayoutPanel2.Visible = false;
                    }
                    else
                    {
                        label1.Text = "Kazanan -> Oyuncu 2";
                        tableLayoutPanel2.Visible = false;
                    }
                }
            }
            catch
            {

            }
        }
        private void soldan_saga_uc(int satir, int sutun)
        {
            try
            {
                String x1 = koordinatlar[satir, sutun + 2].Name;
                String x2 = koordinatlar[satir, sutun + 1].Name;
                String x3 = koordinatlar[satir, sutun].Name;
                String x4 = koordinatlar[satir, sutun - 1].Name;
                int deger;
                if (renkKontrolu % 2 == 1)
                {
                    deger = 0;
                }
                else
                {
                    deger = 1;
                }
                if (x1 == x2 && x1 == x3 && x1 == x4)
                {
                    if (deger == 0)
                    {
                        label1.Text = "Kazanan -> Oyuncu 1";
                        tableLayoutPanel2.Visible = false;
                    }
                    else
                    {
                        label1.Text = "Kazanan -> Oyuncu 2";
                        tableLayoutPanel2.Visible = false;
                    }
                }
            }
            catch
            {

            }
        }
        private void soldan_saga_dort(int satir, int sutun)
        {
            try
            {
                String x1 = koordinatlar[satir, sutun + 3].Name;
                String x2 = koordinatlar[satir, sutun + 2].Name;
                String x3 = koordinatlar[satir, sutun + 1].Name;
                String x4 = koordinatlar[satir, sutun].Name;
                int deger;
                if (renkKontrolu % 2 == 1)
                {
                    deger = 0;
                }
                else
                {
                    deger = 1;
                }
                if (x1 == x2 && x1 == x3 && x1 == x4)
                {
                    if (deger == 0)
                    {
                        label1.Text = "Kazanan -> Oyuncu 1";
                        tableLayoutPanel2.Visible = false;
                    }
                    else
                    {
                        label1.Text = "Kazanan -> Oyuncu 2";
                        tableLayoutPanel2.Visible = false;
                    }
                }
            }
            catch
            {

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {            
            if(colorDialog1.ShowDialog() == DialogResult.OK)
            {
                if (renkler[1] != colorDialog1.Color)
                {
                    textBox1.BackColor = colorDialog1.Color;
                    renkler[0] = colorDialog1.Color;
                    tableLayoutPanel3.Refresh();
                    button1.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Farklı bir renk seçin");
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                if (renkler[0] != colorDialog1.Color)
                {
                    textBox2.BackColor = colorDialog1.Color;
                    renkler[1] = colorDialog1.Color;
                    tableLayoutPanel3.Refresh();
                    button2.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Farklı bir renk seçin.");
                }
            }
        }
        private void butonlari_gizle()
        {
            button1.Enabled = false;
            button2.Enabled = false;
        }
        private void tum_kontroller(int satirlarListIndexi,int sutun)
        {
            //satir sayısının bir eksiği olarak yazılıyor. İndex 9, satır10 gösterir.
            int satirDegeri = satirlarList[satirlarListIndexi]-1;            
            //ilk satır değeri 0 olduğu için -1'den büyük olana kadar kontrol edecek.
            if (satirDegeri > -1)
            {
                buton_tikla_renk_degis(satirDegeri, sutun);

                sol_ust_sag_alt_ilk(satirDegeri, sutun);
                sol_ust_sag_alt_iki(satirDegeri, sutun);
                sol_ust_sag_alt_uc(satirDegeri, sutun);
                sol_ust_sag_alt_dort(satirDegeri, sutun);

                sol_alt_sag_ust_ilk(satirDegeri, sutun);
                sol_alt_sag_ust_iki(satirDegeri, sutun);
                sol_alt_sag_ust_uc(satirDegeri, sutun);
                sol_alt_sag_ust_dort(satirDegeri, sutun);

                yukardan_asagi_ilk(satirDegeri, sutun);

                soldan_saga_ilk(satirDegeri, sutun);
                soldan_saga_iki(satirDegeri, sutun);
                soldan_saga_uc(satirDegeri, sutun);
                soldan_saga_dort(satirDegeri, sutun);

                satirlarList[satirlarListIndexi] = satirDegeri--;

                butonlari_gizle();
            }
        }
    }
}
