using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EuroStarFOM.Models.Siniflar
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }
        [Column(TypeName = ("Varchar"))]
        [StringLength(10)]
        public string KulaniciAd { get; set; }
        [Column(TypeName = ("Varchar"))]
        [StringLength(30)]
        public string Sifre { get; set; }
        [Column(TypeName = ("Char"))]
        [StringLength(10)]
        public string Yetki { get; set; }


    }
}