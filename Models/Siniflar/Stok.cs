using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EuroStarFOM.Models.Siniflar
{
    public class Stok
    {
        [Key]
        public int StokId { get; set; }
        [Column(TypeName = ("Varchar"))]
        [StringLength(200, ErrorMessage = "En fazla 200 karakter yazabilirsiniz.")]
        public string Aciklama { get; set; }

        [Column(TypeName = ("Varchar"))]
        [StringLength(20, ErrorMessage = "En fazla 13 karakter yazabilirsiniz.")]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz.")]
        public string StokKod { get; set; }
        public int Miktar { get; set; }
        public int DepoId { get; set; }
        [ForeignKey("DepoId")]
        public virtual Depo Depo { get; set; }

        public DateTime StokTarih { get; set; }
        public bool Durum { get; set; }
        public ICollection<Urun> Uruns { get; set; }
        //public ICollection<DepoStok> DepoStoks { get; set; }
    }
}