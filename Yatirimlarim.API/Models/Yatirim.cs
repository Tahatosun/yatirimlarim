using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yatirimlarim.API.Models
{
    public class Yatirim
    {
        public int YatirimID { get; set; }
        public int KullaniciID { get; set; }
        public int UrunID { get; set; }
        public DateTime YatirimTarihi { get; set; }
        public double UrunAdet { get; set; }
        public double YatirimMaliyeti { get; set; }
    }
}
