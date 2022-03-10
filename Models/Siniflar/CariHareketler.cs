using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EuroStarFOM.Models.Siniflar
{
    public class CariHareketler
    {
        [Key]
        public int CariHareketID { get; set; }
        public int CariID { get; set; }
        //[ForeignKey("CariID")]
        //public virtual Cari Cari { get; set; }
        public int FaturaID { get; set; }
        //[ForeignKey("FaturaID")]
        //public virtual Faturalar Faturalar { get; set; }
        [Column(TypeName = ("Varchar"))]
        [StringLength(30)]
        public string IslemTip { get; set; }
        public DateTime Tarih { get; set; }
        public DateTime VadeTarih { get; set; }
        [Column(TypeName = ("Varchar"))]
        [StringLength(100)]
        public string Aciklama { get; set; }
        public decimal CariDenAlacak { get; set; }
        public decimal CariNinAlacak { get; set; }
    }
}