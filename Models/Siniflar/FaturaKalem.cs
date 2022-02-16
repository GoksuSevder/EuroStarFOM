using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EuroStarFOM.Models.Siniflar
{
    public class FaturaKalem
    {
        [Key]
        public int FaturaKalemID { get; set; }
        [Column(TypeName = ("Varchar"))]
        [StringLength(100)]
        public string Aciklama { get; set; }
        public string Miktar { get; set; }
        public decimal BirimFiyat { get; set; }
        public decimal Tutar { get; set; }
        public decimal Kdv { get; set; }
        public int UrunId { get; set; }
        public virtual Urun Urun { get; set; }
        public int FaturaId { get; set; }
        [ForeignKey("FaturaId")]
        public virtual Faturalar Faturalar { get; set; }


    }
}