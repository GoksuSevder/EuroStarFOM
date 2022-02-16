using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EuroStarFOM.Models.Siniflar
{
    public class SatisHaraket
    {
        [Key]
        public int SatisID { get; set; }

        public DateTime Tarih { get; set; }
        public int Adet { get; set; }
        public decimal Fiyat { get; set; }
        public decimal ToplamTutar { get; set; }
        public int PersonelId { get; set; }
        [ForeignKey("PersonelId")]
        public virtual Personel Personel { get; set; }
        public int UrunId { get; set; }
        [ForeignKey("UrunId")]
        public virtual Urun Urun { get; set; }
        public int CariId { get; set; }
        [ForeignKey("CariId")]
        public virtual Cari Cari { get; set; }
    }
}