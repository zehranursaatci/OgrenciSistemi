using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ogrencibilgileri.Modullers;

namespace ogrencibilgileri.Depo
{
   internal  interface IAmbar
    {
        List<Ogrenci> SearchOgrencis(string tc);

        List<Okul> SearchOkuls(string tc);
    }
}
