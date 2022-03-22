using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EuroStarFOM.Models.SinifModel
{
    public class DosyaEkleModel
    {
        public int Id { get; set; }
        public string DosyaNo { get; set; }
        public DateTime DAcilisTarih { get; set; }
        public int SgrtSirketi { get; set; }
        public DateTime DKabulTarih { get; set; }
        public int DosyaDurumu { get; set; }
        public string ExperAdi { get; set; }
        public int ExperGsm { get; set; }
        public int ExperTel { get; set; }
        public string ExperTelEposta { get; set; }
        public string ServisAdi { get; set; }
        public string ServisYetkili { get; set; }
        public int ServisTel { get; set; }
        public int ServisGsm { get; set; }
        public int Kategori { get; set; }
        public string AracPlaka { get; set; }
        public int AltAsama { get; set; }
        public string AracMarka { get; set; }
        public int Surec { get; set; }
        public string AracModel { get; set; }
        public int Oncelik { get; set; }
        public int AracYili { get; set; }
        public string UrunDegerlendirme { get; set; }
        public string FaturaNo { get; set; }
        public int FaturaTutar { get; set; }
        public DateTime FaturaTarih { get; set; }
    }
}

