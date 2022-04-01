namespace EuroStarFOM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asda : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminId = c.Int(nullable: false, identity: true),
                        KulaniciAd = c.String(maxLength: 10, unicode: false),
                        Sifre = c.String(maxLength: 30, unicode: false),
                        Yetki = c.String(maxLength: 10, fixedLength: true, unicode: false),
                    })
                .PrimaryKey(t => t.AdminId);
            
            CreateTable(
                "dbo.CariHareketlers",
                c => new
                    {
                        CariHareketID = c.Int(nullable: false, identity: true),
                        CariID = c.Int(nullable: false),
                        FaturaID = c.Int(nullable: false),
                        IslemTip = c.String(maxLength: 30, unicode: false),
                        Tarih = c.DateTime(nullable: false),
                        VadeTarih = c.DateTime(nullable: false),
                        Aciklama = c.String(maxLength: 100, unicode: false),
                        CariDenAlacak = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CariNinAlacak = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.CariHareketID);
            
            CreateTable(
                "dbo.Caris",
                c => new
                    {
                        CariID = c.Int(nullable: false, identity: true),
                        CariAd = c.String(nullable: false, maxLength: 30, unicode: false),
                        CariSoyad = c.String(nullable: false, maxLength: 30, unicode: false),
                        CariSehir = c.String(maxLength: 13, unicode: false),
                        Adres = c.String(maxLength: 100, unicode: false),
                        VergiNo = c.Int(nullable: false),
                        VergiDairesi = c.String(maxLength: 60, unicode: false),
                        CariMail = c.String(maxLength: 50, unicode: false),
                        Durum = c.Boolean(nullable: false),
                        Bakiye = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Tel = c.Int(nullable: false),
                        Gsm = c.Int(nullable: false),
                        CariTip = c.String(),
                    })
                .PrimaryKey(t => t.CariID);
            
            CreateTable(
                "dbo.Dosyalars",
                c => new
                    {
                        DosylarID = c.Int(nullable: false, identity: true),
                        DosylarNo = c.String(),
                        DosyaDurum = c.Int(nullable: false),
                        Kategori = c.Int(nullable: false),
                        AltAsama = c.Int(nullable: false),
                        Oncelik = c.Int(nullable: false),
                        Surec = c.Int(nullable: false),
                        CariID = c.Int(nullable: false),
                        EksperAdi = c.String(),
                        EksperGSM = c.Int(nullable: false),
                        EksperTel = c.Int(nullable: false),
                        EksperEposta = c.String(),
                        ServisAdi = c.String(),
                        ServisYetkili = c.String(),
                        ServisGSM = c.Int(nullable: false),
                        ServisTel = c.Int(nullable: false),
                        AracPlaka = c.String(),
                        AracMarka = c.String(),
                        AracModel = c.String(),
                        AracYil = c.Int(nullable: false),
                        UrunDegerlendirme = c.String(),
                        FaturaTutar = c.Int(nullable: false),
                        FaturaSeriNo = c.String(maxLength: 6, unicode: false),
                        FaturaSiraNo = c.String(maxLength: 10, unicode: false),
                        FaturaTarih = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DAcilisTarih = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DKabulTarih = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DKapanisTarih = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.DosylarID)
                .ForeignKey("dbo.Caris", t => t.CariID, cascadeDelete: true)
                .Index(t => t.CariID);
            
            CreateTable(
                "dbo.DosyaDegisenParcas",
                c => new
                    {
                        DDP_ID = c.Int(nullable: false, identity: true),
                        DosyaID = c.Int(nullable: false),
                        UrunID = c.Int(nullable: false),
                        Aciklama = c.String(),
                        Miktar = c.String(),
                        BirimFiyat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Tutar = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Kdv = c.Decimal(nullable: false, precision: 18, scale: 2),
                        durum = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.DDP_ID)
                .ForeignKey("dbo.Dosyalars", t => t.DosyaID, cascadeDelete: true)
                .ForeignKey("dbo.Uruns", t => t.UrunID, cascadeDelete: true)
                .Index(t => t.DosyaID)
                .Index(t => t.UrunID);
            
            CreateTable(
                "dbo.Uruns",
                c => new
                    {
                        UrunID = c.Int(nullable: false, identity: true),
                        UrunAd = c.String(maxLength: 30, unicode: false),
                        UrunKodu = c.String(maxLength: 30, unicode: false),
                        Barkod = c.String(maxLength: 50, unicode: false),
                        Marka = c.String(maxLength: 30, unicode: false),
                        Model = c.String(),
                        AlisFiyat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AlisKdv = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SatisFiyat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SatisKdv = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Durum = c.Boolean(nullable: false),
                        UrunGorsel = c.String(maxLength: 250, unicode: false),
                        KategoriId = c.Int(nullable: false),
                        StokId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UrunID)
                .ForeignKey("dbo.Kategoris", t => t.KategoriId, cascadeDelete: true)
                .ForeignKey("dbo.Stoks", t => t.StokId, cascadeDelete: true)
                .Index(t => t.KategoriId)
                .Index(t => t.StokId);
            
            CreateTable(
                "dbo.Kategoris",
                c => new
                    {
                        KategoriId = c.Int(nullable: false, identity: true),
                        KategoriAd = c.String(maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.KategoriId);
            
            CreateTable(
                "dbo.SatisHarakets",
                c => new
                    {
                        SatisID = c.Int(nullable: false, identity: true),
                        Tarih = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Adet = c.Int(nullable: false),
                        Fiyat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ToplamTutar = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PersonelId = c.Int(nullable: false),
                        UrunId = c.Int(nullable: false),
                        CariId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SatisID)
                .ForeignKey("dbo.Caris", t => t.CariId, cascadeDelete: true)
                .ForeignKey("dbo.Personels", t => t.PersonelId, cascadeDelete: true)
                .ForeignKey("dbo.Uruns", t => t.UrunId, cascadeDelete: true)
                .Index(t => t.PersonelId)
                .Index(t => t.UrunId)
                .Index(t => t.CariId);
            
            CreateTable(
                "dbo.Personels",
                c => new
                    {
                        PersonelID = c.Int(nullable: false, identity: true),
                        PersonelAd = c.String(nullable: false, maxLength: 30, unicode: false),
                        PersonelSoyad = c.String(nullable: false, maxLength: 30, unicode: false),
                        PersonelGorsel = c.String(nullable: false, maxLength: 250, unicode: false),
                        DepartmanId = c.Int(nullable: false),
                        Durum = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PersonelID)
                .ForeignKey("dbo.Departmen", t => t.DepartmanId, cascadeDelete: true)
                .Index(t => t.DepartmanId);
            
            CreateTable(
                "dbo.Departmen",
                c => new
                    {
                        DepartmanID = c.Int(nullable: false, identity: true),
                        DepartmanAd = c.String(maxLength: 30, unicode: false),
                        Durum = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.DepartmanID);
            
            CreateTable(
                "dbo.Stoks",
                c => new
                    {
                        StokId = c.Int(nullable: false, identity: true),
                        Aciklama = c.String(maxLength: 200, unicode: false),
                        StokKod = c.String(nullable: false, maxLength: 20, unicode: false),
                        Miktar = c.Int(nullable: false),
                        DepoId = c.Int(nullable: false),
                        StokTarih = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Durum = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.StokId)
                .ForeignKey("dbo.Depoes", t => t.DepoId, cascadeDelete: true)
                .Index(t => t.DepoId);
            
            CreateTable(
                "dbo.Depoes",
                c => new
                    {
                        DepoId = c.Int(nullable: false, identity: true),
                        DepoAd = c.String(nullable: false, maxLength: 30, unicode: false),
                        Aciklama = c.String(maxLength: 200, unicode: false),
                        Durum = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.DepoId);
            
            CreateTable(
                "dbo.Faturalars",
                c => new
                    {
                        FaturaID = c.Int(nullable: false, identity: true),
                        FaturaSeriNo = c.String(maxLength: 6, unicode: false),
                        FaturaSiraNo = c.String(maxLength: 10, unicode: false),
                        Tarih = c.DateTime(precision: 7, storeType: "datetime2"),
                        VadeTarih = c.DateTime(precision: 7, storeType: "datetime2"),
                        VergiDairesi = c.String(maxLength: 60, unicode: false),
                        VergiNumarasi = c.Int(nullable: false),
                        IrsaliyeNumarasi = c.String(maxLength: 20),
                        Saat = c.String(maxLength: 5, fixedLength: true, unicode: false),
                        TeslimEden = c.String(maxLength: 30, unicode: false),
                        TeslimAlan = c.String(maxLength: 30, unicode: false),
                        Adres = c.String(maxLength: 100, unicode: false),
                        Aciklama = c.String(maxLength: 100, unicode: false),
                        Toplam = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DepoId = c.Int(),
                        IslemTip = c.String(maxLength: 30, unicode: false),
                        KdvDahil = c.Boolean(nullable: false),
                        CariId = c.Int(nullable: false),
                        DosylarID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FaturaID)
                .ForeignKey("dbo.Caris", t => t.CariId, cascadeDelete: true)
                .Index(t => t.CariId);
            
            CreateTable(
                "dbo.FaturaKalems",
                c => new
                    {
                        FaturaKalemID = c.Int(nullable: false, identity: true),
                        Aciklama = c.String(maxLength: 100, unicode: false),
                        Miktar = c.String(),
                        BirimFiyat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Tutar = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Kdv = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UrunId = c.Int(nullable: false),
                        FaturaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FaturaKalemID)
                .ForeignKey("dbo.Faturalars", t => t.FaturaId, cascadeDelete: true)
                .ForeignKey("dbo.Uruns", t => t.UrunId, cascadeDelete: true)
                .Index(t => t.UrunId)
                .Index(t => t.FaturaId);
            
            CreateTable(
                "dbo.Giders",
                c => new
                    {
                        GiderId = c.Int(nullable: false, identity: true),
                        Aciklama = c.String(maxLength: 100, unicode: false),
                        Tarih = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Tutar = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.GiderId);
            
            CreateTable(
                "dbo.TamirHarekets",
                c => new
                    {
                        TamirID = c.Int(nullable: false, identity: true),
                        Aciklama = c.String(),
                        Asama = c.Int(nullable: false),
                        Durum = c.Boolean(nullable: false),
                        Tarih = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        PersonelId = c.Int(nullable: false),
                        UrunId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TamirID)
                .ForeignKey("dbo.Personels", t => t.PersonelId, cascadeDelete: true)
                .ForeignKey("dbo.Uruns", t => t.UrunId, cascadeDelete: true)
                .Index(t => t.PersonelId)
                .Index(t => t.UrunId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TamirHarekets", "UrunId", "dbo.Uruns");
            DropForeignKey("dbo.TamirHarekets", "PersonelId", "dbo.Personels");
            DropForeignKey("dbo.FaturaKalems", "UrunId", "dbo.Uruns");
            DropForeignKey("dbo.FaturaKalems", "FaturaId", "dbo.Faturalars");
            DropForeignKey("dbo.Faturalars", "CariId", "dbo.Caris");
            DropForeignKey("dbo.Uruns", "StokId", "dbo.Stoks");
            DropForeignKey("dbo.Stoks", "DepoId", "dbo.Depoes");
            DropForeignKey("dbo.SatisHarakets", "UrunId", "dbo.Uruns");
            DropForeignKey("dbo.SatisHarakets", "PersonelId", "dbo.Personels");
            DropForeignKey("dbo.Personels", "DepartmanId", "dbo.Departmen");
            DropForeignKey("dbo.SatisHarakets", "CariId", "dbo.Caris");
            DropForeignKey("dbo.Uruns", "KategoriId", "dbo.Kategoris");
            DropForeignKey("dbo.DosyaDegisenParcas", "UrunID", "dbo.Uruns");
            DropForeignKey("dbo.DosyaDegisenParcas", "DosyaID", "dbo.Dosyalars");
            DropForeignKey("dbo.Dosyalars", "CariID", "dbo.Caris");
            DropIndex("dbo.TamirHarekets", new[] { "UrunId" });
            DropIndex("dbo.TamirHarekets", new[] { "PersonelId" });
            DropIndex("dbo.FaturaKalems", new[] { "FaturaId" });
            DropIndex("dbo.FaturaKalems", new[] { "UrunId" });
            DropIndex("dbo.Faturalars", new[] { "CariId" });
            DropIndex("dbo.Stoks", new[] { "DepoId" });
            DropIndex("dbo.Personels", new[] { "DepartmanId" });
            DropIndex("dbo.SatisHarakets", new[] { "CariId" });
            DropIndex("dbo.SatisHarakets", new[] { "UrunId" });
            DropIndex("dbo.SatisHarakets", new[] { "PersonelId" });
            DropIndex("dbo.Uruns", new[] { "StokId" });
            DropIndex("dbo.Uruns", new[] { "KategoriId" });
            DropIndex("dbo.DosyaDegisenParcas", new[] { "UrunID" });
            DropIndex("dbo.DosyaDegisenParcas", new[] { "DosyaID" });
            DropIndex("dbo.Dosyalars", new[] { "CariID" });
            DropTable("dbo.TamirHarekets");
            DropTable("dbo.Giders");
            DropTable("dbo.FaturaKalems");
            DropTable("dbo.Faturalars");
            DropTable("dbo.Depoes");
            DropTable("dbo.Stoks");
            DropTable("dbo.Departmen");
            DropTable("dbo.Personels");
            DropTable("dbo.SatisHarakets");
            DropTable("dbo.Kategoris");
            DropTable("dbo.Uruns");
            DropTable("dbo.DosyaDegisenParcas");
            DropTable("dbo.Dosyalars");
            DropTable("dbo.Caris");
            DropTable("dbo.CariHareketlers");
            DropTable("dbo.Admins");
        }
    }
}
