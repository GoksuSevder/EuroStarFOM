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
        public Faturalar FaturaDeger { get; set; }
        public IEnumerable<FaturaKalem> FaturaKalemDeger { get; set; }
        public IEnumerable<Cari> CariDeger { get; set; }
        public Cari Cari { get; set; }
        public IEnumerable<Urun> UrunDeger { get; set; }
        public IEnumerable<Depo> DepoDeger { get; set; }
        public IEnumerable<Dosyalar> DosyaDeger { get; set; }
       
        public bool KdvDahil { get; set; } = true;
    }
}