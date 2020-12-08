using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yatirimlarim.API.Models
{
    public class Kullanici
    {
        public int KullaniciID { get; set; }
        public string KullaniciAdi { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }   
        public string Eposta { get; set; }
        public string Sifre { get; set; }
        public string Telefon { get; set; }

    }
}
