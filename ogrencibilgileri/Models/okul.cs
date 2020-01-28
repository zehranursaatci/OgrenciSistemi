using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ogrencibilgileri.Modullers
{
    public class Okul
    {
        
        public string Tc { get; set; }
        public string Okulad { get; set; }
        public string Bolum { get; set; }
        public int Sinif { get; set; }
        public ICollection<Ogrenci> Ogrencis{ get; set; }
    }
}
