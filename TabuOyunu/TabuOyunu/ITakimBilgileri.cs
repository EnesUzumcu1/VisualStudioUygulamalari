using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabuOyunu
{
    interface ITakimBilgileri
    {
        string takimAdi { get; set; }
        int takimPuani { get; set; }
    }
}
