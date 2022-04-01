using EuroStarFOM.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EuroStarFOM.Models.SinifModel
{
    public class SatisFaturaDosyaModel
    {
        public Dosyalar Dosya { get; set; }
        public Cari Cari { get; set; }
        public IEnumerable<Depo> DepoDeger { get; set; }
        public IEnumerable<Urun> UrunDeger { get; set; }
    }
}