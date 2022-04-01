using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EuroStarFOM.Models.Siniflar
{
    public class Cari
    {
        [Key]
        public int CariID { get; set; }
      
        [Column(TypeName = ("Varchar"))]
        [StringLength(30,ErrorMessage ="En fazla 30 karakter yazabilirsiniz.")]
        [Required(ErrorMessage ="Bu alanı boş geçemezsiniz.")]
        public string CariAd { get; set; }
       
        [Column(TypeName = ("Varchar"))]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter yazabilirsiniz.")]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz.")]
        public string CariSoyad { get; set; }
      
        [Column(TypeName = ("Varchar"))]
        [StringLength(13)]
        public string CariSehir { get; set; }
      
        [Column(TypeName = ("Varchar"))]
        [StringLength(100)]
        public string Adres { get; set; } 
        
        public int VergiNo { get; set; } 
        
        [Column(TypeName = ("Varchar"))]
        [StringLength(60)]
        public string VergiDairesi { get; set; }
       
        [Column(TypeName = ("Varchar"))]
        [StringLength(50)]
        public string CariMail { get; set; }
        public bool Durum { get; set; }
        public decimal? Bakiye { get; set; }
        public int? Tel { get; set; }
        public int Gsm { get; set; }
        public string CariTip { get; set; }

        //public ICollection<CariHareketler> CariHareketlers { get; set; }
        public ICollection<SatisHaraket> SatisHarakets { get; set; }
        public ICollection<Faturalar> Faturalars { get; set; }
        public ICollection<Dosyalar> Dosyalars { get; set; }

    }
}