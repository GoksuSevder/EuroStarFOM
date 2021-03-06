using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EuroStarFOM.Models.Siniflar
{
    public class Context : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Cari> Caris { get; set; }
        public DbSet<Departman> Departmans { get; set; }
        public DbSet<FaturaKalem> FaturaKalems { get; set; }
        public DbSet<Faturalar> Faturalars { get; set; }
        public DbSet<Gider> Giders { get; set; }
        public DbSet<Kategori> Kategoris { get; set; }
        public DbSet<Personel> Personels { get; set; }
        public DbSet<SatisHaraket> SatisHarakets { get; set; }
        public DbSet<TamirHareket> TamirHarekets { get; set; }
        public DbSet<Urun> Uruns { get; set; }
        public DbSet<Depo> Depos { get; set; }
        public DbSet<Stok> Stoks { get; set; }
        public DbSet<CariHareketler> CariHareketlers { get; set; }
        public DbSet<Dosyalar> Dosyalars { get; set; }
        public DbSet<DosyaDegisenParca> DosyaDegisenParcas { get; set; }
        //public DbSet<DepoStok> DepoStoks { get; set; }
    }
}