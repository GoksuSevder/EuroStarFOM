﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EuroStarFOM.Models.Siniflar
{
    public class Dosyalar
    {
        [Key]
        public int DosylarID { get; set; }
        public string DosylarNo { get; set; }
        public DosyaDurum DosyaDurum { get; set; }
        public DurumKategori Kategori { get; set; }
        public AltAsama AltAsama { get; set; }
        public Oncelik Oncelik { get; set; }
        public Surec Surec { get; set; }
        //Sigorta Şİrketi
        public int CariID { get; set; }
        [ForeignKey("CariID")]
        public virtual Cari Cari { get; set; }
        public string EksperAdi { get; set; }
        public int EksperGSM { get; set; }
        public int EksperTel { get; set; }
        public string EksperEposta { get; set; }
        public string ServisAdi { get; set; }
        public string ServisYetkili { get; set; }
        public int ServisGSM { get; set; }
        public int ServisTel { get; set; }
        public string AracPlaka { get; set; }
        public string AracMarka { get; set; }
        public string AracModel { get; set; }
        public int AracYil { get; set; }
        public string UrunDegerlendirme { get; set; }
        //public int UrunID { get; set; }
        public string FaturaNo { get; set; }
        public int FaturaTutar { get; set; }
        public DateTime FaturaTarih { get; set; }
        public DateTime DAcilisTarih { get; set; }
        public DateTime DKabulTarih { get; set; }
        public DateTime DKapanisTarih { get; set; }
        public ICollection<DosyaDegisenParca> DosyaDegisenParca { get; set; }
    }


    public enum DosyaDurum  
    {
        YeniKayit = 1, EksperInceliyor = 2, Onarimda = 3, Faturalandi = 4, Tamamlandi = 5
    }
    public enum DurumKategori  
    {
        Ucretli = 1, Garantili = 2
    }
    public enum AltAsama  
    {
        AltAsama0 = 0,  AltAsama1 = 1, AltAsama2 = 2
    }
    public enum Surec  
    {
        Sürec0 = 0, Sürec1 = 1, Sürec2 = 2
    }
    public enum Oncelik  
    {
        Oncelik0 = 0, Oncelik1 = 1, Oncelik2 = 2
    }
    public enum UrunDegerlendirme  
    {
        Cam = 1, Kasa = 2, Lamba = 3
    }
}