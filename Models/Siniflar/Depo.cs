using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EuroStarFOM.Models.Siniflar
{
    public class Depo
    {
        [Key]
        public int DepoId { get; set; }
        [Column(TypeName = ("Varchar"))]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter yazabilirsiniz.")]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz.")]
        public string DepoAd { get; set; }
        [Column(TypeName = ("Varchar"))]
        [StringLength(200, ErrorMessage = "En fazla 200 karakter yazabilirsiniz.")]
        public string Aciklama { get; set; }
        public bool Durum { get; set; }
        public ICollection<Stok> Stoks { get; set; }
    }
}