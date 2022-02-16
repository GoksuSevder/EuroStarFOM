using EuroStarFOM.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EuroStarFOM.Models.SinifModel
{
    public class StokUrunEkleModel
    {
        public Urun Urun { get; set; }
        public Stok Stok { get; set; }
        public Depo Depo { get; set; }
        public IEnumerable<Depo> DepoDeger { get; set; }
    }
}