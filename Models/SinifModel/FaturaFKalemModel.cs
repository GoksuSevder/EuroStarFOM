using EuroStarFOM.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EuroStarFOM.Models.SinifModel
{
    public class FaturaFKalemModel
    {
        public IEnumerable<Faturalar> FaturalarDeger { get; set; }
        public IEnumerable<FaturaKalem> FaturaKalemDeger { get; set; }
        public IEnumerable<Cari> CariDeger { get; set; }
        public IEnumerable<Urun> UrunDeger { get; set; }
        public IEnumerable<Depo> DepoDeger { get; set; }
        public bool KdvDahil { get; set; } = true;
    }
}