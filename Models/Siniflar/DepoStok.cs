using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EuroStarFOM.Models.Siniflar
{
    public class DepoStok
    {
        [Key]
        public int DepoStokId { get; set; }
        public int DepoId { get; set; }
        public int StokId { get; set; }
        public virtual Depo Depo { get; set; }
        public virtual Stok Stok { get; set; }
        public bool Durum { get; set; }
    }
}