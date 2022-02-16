using EuroStarFOM.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EuroStarFOM.Models.SinifModel
{
    public class DepoStokUrun
    {
        public IEnumerable<Depo> DepoDeger { get; set; }
        public IEnumerable<Stok> StokDeger { get; set; }
        public IEnumerable<Urun> UrunDeger { get; set; }
       public Urun Urun { get; set; }
    }
}