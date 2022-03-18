using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EuroStarFOM.Models.Siniflar
{
    public class Urun
    {
        [Key]
        public int UrunID { get; set; }
        [Column(TypeName = ("Varchar"))]
        [StringLength(30)]
        public string UrunAd { get; set; }
        [Column(TypeName = ("Varchar"))]
        [StringLength(30)]
        public string UrunKodu { get; set; }
        [Column(TypeName = ("Varchar"))]
        [StringLength(50)]
        public string Barkod { get; set; }
        [Column(TypeName = ("Varchar"))]
        [StringLength(30)]
        public string Marka { get; set; }
        public string Model { get; set; }
        public decimal AlisFiyat { get; set; }
        public decimal AlisKdv { get; set; }
        public decimal SatisFiyat { get; set; }
        public decimal SatisKdv { get; set; }
        public bool Durum { get; set; }
        [Column(TypeName = ("Varchar"))]
        [StringLength(250)]
        public string UrunGorsel { get; set; }

        public int KategoriId { get; set; }
        [ForeignKey("KategoriId")]
        public virtual Kategori Kategori { get; set; }
        public int StokId { get; set; }
        [ForeignKey("StokId")]
        public virtual Stok Stok { get; set; }
        public ICollection<SatisHaraket> SatisHarakets { get; set; }
        public ICollection<DosyaDegisenParca> DosyaDegisenParca { get; set; }


    }
}