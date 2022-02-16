using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EuroStarFOM.Models.Siniflar
{
    public class Personel
    {
        [Key]
        public int PersonelID { get; set; }
        [Column(TypeName = ("Varchar"))]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter yazabilirsiniz.")]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz.")]
        public string PersonelAd { get; set; }
        [Column(TypeName = ("Varchar"))]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter yazabilirsiniz.")]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz.")]
        public string PersonelSoyad { get; set; }
        [Column(TypeName = ("Varchar"))]
        [StringLength(250, ErrorMessage = "En fazla 250 karakter yazabilirsiniz.")]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz.")]
        public string PersonelGorsel { get; set; }
        public ICollection<SatisHaraket> SatisHarakets { get; set; }
        public int DepartmanId { get; set; }
        [ForeignKey("DepartmanId")]
        public virtual Departman Departman { get; set; }
        public bool Durum { get; set; }
    }
}