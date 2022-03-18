using EuroStarFOM.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EuroStarFOM.Models.SinifModel
{
    public class DosyaIndexModel
    {
        public string DosylarNo { get; set; }
        public DosyaDurum DosyaDurum { get; set; }
        public string SigortaSirketi { get; set; }
        public string AracPlaka { get; set; }
        public string AracModel { get; set; }
        public DateTime DAcilisTarih { get; set; }
        public DateTime DKabulTarih { get; set; }
        public DateTime DKapanisTarih { get; set; }
        public int ParçaAdeti { get; set; }
    }
}