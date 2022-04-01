using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EuroStarFOM.Models.Siniflar
{
    public class TamirHareket
    {
        [Key]
        public int TamirID { get; set; }
        public string Aciklama { get; set; }
        public int Asama { get; set; }
        public bool Durum { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime Tarih { get; set; }
        public int PersonelId { get; set; }
        [ForeignKey("PersonelId")]
        public virtual Personel Personel { get; set; }
        public int UrunId { get; set; }
        [ForeignKey("UrunId")]
        public virtual Urun Urun { get; set; }
    }
}