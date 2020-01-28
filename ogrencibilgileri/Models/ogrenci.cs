using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ogrencibilgileri.Modullers
{
    public class Ogrenci
    {
    
        public string Tc { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public DateTime Dtarih { get; set; }
        public string Cinsiyet { get; set; }
        public ICollection<Okul> Okuls { get; set; }
    }
}
