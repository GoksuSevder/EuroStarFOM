using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EuroStarFOM.Models.Siniflar
{
    public class DosyaDegisenParca
    {
        [Key]
        public int DDP_ID { get; set; }
        public int DosyaID { get; set; }
        [ForeignKey("DosyaID")]
        public Dosyalar Dosyalar { get; set; }
        public int UrunID { get; set; }
        [ForeignKey("UrunID")]
        public virtual Urun Urun { get; set; }
        public string Aciklama { get; set; }
        public string Miktar { get; set; }
        public decimal BirimFiyat { get; set; }
        public decimal Tutar { get; set; }
        public decimal Kdv { get; set; }
        public bool durum { get; set; }
    }
}