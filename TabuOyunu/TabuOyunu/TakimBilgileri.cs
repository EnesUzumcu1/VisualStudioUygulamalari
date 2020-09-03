using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabuOyunu
{
    class TakimBilgileri:ITakimBilgileri
    {
        private string TakimAdi;
        private int TakimPuani;

        public TakimBilgileri(string takimAdi,int takimPuani)
        {
            TakimAdi = takimAdi;
            TakimPuani = takimPuani;
        }

        public string takimAdi { get => TakimAdi; set => TakimAdi= value; }
        public int takimPuani { get => TakimPuani; set => TakimPuani = value; }
    }
}
