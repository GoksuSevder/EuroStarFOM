using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EuroStarFOM.Models.Siniflar
{
    public class Faturalar
    {
        [Key]
        public int FaturaID { get; set; }
        [Column(TypeName = ("Varchar"))]
        [StringLength(6)]
        public string FaturaSeriNo { get; set; }
        [Column(TypeName = ("Varchar"))]
        [StringLength(10)]
        public string FaturaSiraNo { get; set; }
        public DateTime Tarih { get; set; }
        public DateTime VadeTarih { get; set; }
        [Column(TypeName = ("Varchar"))]
        [StringLength(60)]
        public string VergiDairesi { get; set; }
        //[ Range(13,13)]
        public int VergiNumarasi { get; set; }
        [StringLength(20)]
        public string IrsaliyeNumarasi { get; set; }
        [Column(TypeName = ("char"))]
        [StringLength(5)]
        public string Saat { get; set; }
        [Column(TypeName = ("Varchar"))]
        [StringLength(30)]
        public string TeslimEden { get; set; }
        [Column(TypeName = ("Varchar"))]
        [StringLength(30)]
        public string TeslimAlan { get; set; }
        [Column(TypeName = ("Varchar"))]
        [StringLength(100)]
        public string Adres { get; set; }
        [Column(TypeName = ("Varchar"))]
        [StringLength(100)]
        public string Aciklama { get; set; }
        public decimal Toplam { get; set; }
        public int DepoId { get; set; }
        [Column(TypeName = ("Varchar"))]
        [StringLength(30)]
        public string IslemTip { get; set; }
        public bool KdvDahil { get; set; }
        public int CariId { get; set; }
        [ForeignKey("CariId")]
        public virtual Cari Cari { get; set; }
        public ICollection<FaturaKalem> FaturaKalems { get; set; }
        //public ICollection<CariHareketler> CariHareketlers { get; set; }


    }
}