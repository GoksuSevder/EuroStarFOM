using EuroStarFOM.Models.Siniflar;
using EuroStarFOM.Models.SinifModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EuroStarFOM.Controllers
{
    public class DosyalarController : Controller
    {
        Context c = new Context();
        // GET: Dosyalar
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DosyaListeGetir(string DosyaNo, string AracPlaka, string SigortaSirketi, string Marka, int DosyaDurumu, string KapatmailkTarih, string KapatmasonTarih, string CevapilkTarih, string CevapsonTarih, string OnarimIhbarilkTarih, string OnarimIhbarsonTarih)
        {
            var degerler = (from d in c.Dosyalars.ToList()
                            join dp in c.DosyaDegisenParcas.ToList() on d.DosylarID equals dp.DosyaID
                           into liste
                            select new
                            {
                                DosyaID = d.DosylarID,
                                SigortaSirketi = d.Cari.CariAd + " " + d.Cari.CariSoyad,
                                DosylarNo = d.DosylarNo,
                                DosyaDurum = d.DosyaDurum,
                                DKapanisTarih = d.DKapanisTarih,
                                AracPlaka = d.AracPlaka,
                                AracModel = d.AracModel,
                                DAcilisTarih = d.DAcilisTarih,
                                DKabulTarih = d.DKabulTarih,
                                ParçaAdeti = liste.Select(x => x.Miktar)
                            }).ToList();

            if (OnarimIhbarilkTarih != "")
            {
                var dAcilisTarih = OnarimIhbarilkTarih == "" ? default : degerler.Where(x => x.DAcilisTarih >= DateTime.Parse(OnarimIhbarilkTarih) && x.DAcilisTarih <= DateTime.Parse(OnarimIhbarsonTarih)).ToList();
                return Json(dAcilisTarih, JsonRequestBehavior.AllowGet);

            }
            if (CevapilkTarih != "")
            {
                var dKabulTarih = CevapilkTarih == "" ? default : degerler.Where(x => x.DKabulTarih >= DateTime.Parse(CevapilkTarih) && x.DKabulTarih <= DateTime.Parse(CevapsonTarih)).ToList();
                return Json(dKabulTarih, JsonRequestBehavior.AllowGet);
            }
            if (KapatmailkTarih != "")
            {
                var dKapanisTarih = KapatmailkTarih == "" ? default : degerler.Where(x => x.DKapanisTarih >= DateTime.Parse(KapatmailkTarih) && x.DKapanisTarih <= DateTime.Parse(KapatmasonTarih)).ToList();
                return Json(dKapanisTarih, JsonRequestBehavior.AllowGet);
            }
            if (DosyaDurumu != 0)
            {
                var dosyaDurumu = DosyaDurumu == 0 ? default : degerler.Where(x => x.DosyaDurum == (DosyaDurum)DosyaDurumu).ToList();
                return Json(dosyaDurumu, JsonRequestBehavior.AllowGet);
            }

            return Json(degerler, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult DosyaEkle()
        {
            List<SelectListItem> sigortaSirketi = (from x in c.Caris.ToList()
                                                   where x.Durum == true
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CariAd + " " + x.CariSoyad,
                                                       Value = x.CariID.ToString()
                                                   }).ToList();
            List<SelectListItem> urunGetir = (from x in c.Uruns.ToList()
                                              where x.Durum == true
                                              select new SelectListItem
                                              {
                                                  Text = x.UrunAd,
                                                  Value = x.UrunID.ToString()
                                              }).ToList();

            ViewBag.UrunGetir = urunGetir;
            ViewBag.SigortaSirketi = sigortaSirketi;
            return View();
        }
        [HttpPost]
        public ActionResult DosyaEkle(DosyaEkleModel model, DosyaDegisenParca[] kalemler)
        {
            try
            {
                Dosyalar d = new Dosyalar();
                d.DosylarNo = model.DosyaNo;

                d.DosyaDurum = (DosyaDurum)model.DosyaDurumu;
                d.Kategori = (DurumKategori)model.Kategori;
                d.AltAsama = (AltAsama)model.AltAsama;
                d.Oncelik = (Oncelik)model.Oncelik;
                d.Surec = (Surec)model.Surec;

                d.CariID = model.SgrtSirketi;
                d.EksperAdi = model.ExperAdi;
                d.EksperGSM = model.ExperGsm;
                d.EksperTel = model.ExperTel;
                d.EksperEposta = model.ExperTelEposta;
                d.ServisAdi = model.ServisAdi;
                d.ServisYetkili = model.ServisYetkili;
                d.ServisGSM = model.ServisGsm;
                d.ServisTel = model.ServisTel;
                d.AracPlaka = model.AracPlaka;
                d.AracMarka = model.AracMarka;
                d.AracModel = model.AracModel;
                d.AracYil = model.AracYili;
                d.UrunDegerlendirme = model.UrunDegerlendirme;
                //d.FaturaSeriNo = model.FaturaSeriNo;
                //d.FaturaSiraNo = model.FaturaSiraNo;
                //d.FaturaTutar = model.FaturaTutar;
                //d.FaturaTarih = model.FaturaTarih;
                d.DAcilisTarih = model.DAcilisTarih;
                d.DKabulTarih = model.DKabulTarih;

                c.Dosyalars.Add(d);
                foreach (var k in kalemler)
                {
                    DosyaDegisenParca p = new DosyaDegisenParca();
                    p.Aciklama = k.Aciklama;
                    p.BirimFiyat = k.BirimFiyat;
                    p.Miktar = k.Miktar;
                    p.Tutar = k.Tutar;
                    p.Kdv = k.Kdv;
                    p.UrunID = k.UrunID;
                    p.DosyaID = d.DosylarID;

                    c.DosyaDegisenParcas.Add(p);
                }
                c.SaveChanges();
                var id = "/Dosyalar/DosyaGuncelle/"+ d.DosylarID;
                ViewBag.Message = "Dosya Başarıyla Kaydedildi";
                return Json(id, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                ViewBag.Message = "Dosya Kaydedilmedi";
                return Json(ViewBag.Message, JsonRequestBehavior.AllowGet);
            }

        }
        public ActionResult DosyaGetir(int id)
        {
            var degerler = (from d in c.Dosyalars.ToList()
                            where d.DosylarID == id
                            select new
                            {
                                DosyaID = d.DosylarID,
                                DosylarNo = d.DosylarNo,
                                DosyaDurum = d.DosyaDurum,
                                Kategori = d.Kategori,
                                AltAsama = d.AltAsama,
                                Oncelik = d.Oncelik,
                                Surec = d.Surec,
                                CariID = d.CariID,
                                SigortaSirketi = d.CariID,
                                EksperAdi = d.EksperAdi,
                                EksperGSM = d.EksperGSM,
                                EksperTel = d.EksperTel,
                                EksperEposta = d.EksperEposta,
                                ServisAdi = d.ServisAdi,
                                ServisYetkili = d.ServisYetkili,
                                ServisGSM = d.ServisGSM,
                                ServisTel = d.ServisTel,
                                AracPlaka = d.AracPlaka,
                                AracMarka = d.AracMarka,
                                AracModel = d.AracModel,
                                AracYil = d.AracYil,
                                UrunDegerlendirme = d.UrunDegerlendirme,
                                FaturaSeriNo = d.FaturaSeriNo,
                                FaturaSiraNo = d.FaturaSiraNo,
                                //FaturaNo = d.FaturaNo,
                                FaturaTutar = d.FaturaTutar,
                                FaturaTarih = d.FaturaTarih,
                                DKapanisTarih = d.DKapanisTarih,
                                DAcilisTarih = d.DAcilisTarih,
                                DKabulTarih = d.DKabulTarih,
                                //DosyaDegisenParcaID = liste.Select(x => x.DDP_ID),
                                //ParçaAdeti = liste.Select(x => x.Miktar)
                            }).FirstOrDefault();

            return Json(degerler, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DosyaUrunGetir(int id)
        {
            var degerler = (from ddp in c.DosyaDegisenParcas.ToList()
                            join u in c.Uruns.ToList() on ddp.UrunID equals u.UrunID
                            where ddp.DosyaID == id
                            select new
                            {
                                DDP_id = ddp.DDP_ID,
                                Aciklama = ddp.Aciklama,
                                Miktar = ddp.Miktar,
                                BirimFiyat = ddp.BirimFiyat,
                                Tutar = ddp.Tutar,
                                Kdv = ddp.Kdv,
                                UrunId = u.UrunID,
                                UrunAd = u.UrunAd
                            }
                            ).ToList();

            return Json(degerler, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult DosyaGuncelle(int id)
        {
            List<SelectListItem> sigortaSirketi = (from x in c.Caris.ToList()
                                                   where x.Durum == true
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CariAd + " " + x.CariSoyad,
                                                       Value = x.CariID.ToString()
                                                   }).ToList();
            List<SelectListItem> urunGetir = (from x in c.Uruns.ToList()
                                              where x.Durum == true
                                              select new SelectListItem
                                              {
                                                  Text = x.UrunAd,
                                                  Value = x.UrunID.ToString()
                                              }).ToList();
            var faturaGetir = c.Faturalars.Where(y => y.DosylarID == id).ToList();

            ViewBag.FaturaGetir = faturaGetir;
            ViewBag.UrunGetir = urunGetir;
            ViewBag.SigortaSirketi = sigortaSirketi;

            var deger = c.Dosyalars.Where(q => q.DosylarID == id).FirstOrDefault();

            return View(deger);
        }
        [HttpGet]
        public ActionResult SatisFaturaDosya(int id)
        {
            SatisFaturaDosyaModel model = new SatisFaturaDosyaModel();
            model.Dosya = c.Dosyalars.Where(x => x.DosylarID == id).FirstOrDefault();
            model.Cari = (from d in c.Dosyalars.ToList()
                          join y in c.Caris.ToList() on d.CariID equals y.CariID
                          select y
                          ).FirstOrDefault();
            model.DepoDeger = c.Depos.Where(x => x.Durum == true).ToList();
            model.UrunDeger = c.Uruns.Where(x => x.Durum == true).ToList();
            return View(model);
        }
        [HttpPost]
        public ActionResult SatisFaturaDosya(string FaturaSeriNo, string FaturaSiraNo, DateTime Tarih, DateTime VadeTarih, string VergiDairesi, int VergiNumarasi, string IrsaliyeNumarasi, string Adres, string AciklamaFatura, string IslemTip, int CariID, int DosylarID, int DepoId, string GenelToplam, FaturaKalem[] kalemler)
        {
            try
            {
                Faturalar faturalar = new Faturalar();
                faturalar.DosylarID = DosylarID;
                faturalar.CariId = CariID;
                faturalar.FaturaSeriNo = FaturaSeriNo;
                faturalar.FaturaSiraNo = FaturaSiraNo;
                faturalar.Tarih = DateTime.Parse(Tarih.ToShortDateString());
                faturalar.VadeTarih = DateTime.Parse(VadeTarih.ToShortDateString());
                faturalar.VergiDairesi = VergiDairesi;
                faturalar.VergiNumarasi = VergiNumarasi;
                faturalar.IrsaliyeNumarasi = IrsaliyeNumarasi;
                faturalar.Adres = Adres;
                faturalar.Aciklama = AciklamaFatura;
                faturalar.IslemTip = IslemTip;
                faturalar.DepoId = DepoId;
                faturalar.Toplam = Convert.ToDecimal(GenelToplam);
                c.Faturalars.Add(faturalar);
                c.SaveChanges();
                foreach (var item in kalemler)
                {
                    FaturaKalem fk = new FaturaKalem();
                    fk.FaturaId = faturalar.FaturaID;
                    fk.UrunId = item.UrunId;
                    fk.Aciklama = item.Aciklama;
                    fk.BirimFiyat = item.BirimFiyat;
                    fk.Miktar = item.Miktar;
                    fk.Kdv = item.Kdv;
                    c.FaturaKalems.Add(fk);
                    c.SaveChanges();
                }
                ViewBag.Message = "Fatura Başarıyla Kaydedildi";

                return Json(ViewBag.Message, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                return View();
            }
           
        }
        [HttpPost]
        public ActionResult DosyaGuncelle(DosyaEkleModel model, DosyaDegisenParca[] kalemler)
        {
            try
            {
                var d = c.Dosyalars.Where(x => x.DosylarID == model.Id).FirstOrDefault();

                d.DosylarNo = model.DosyaNo;

                d.DosyaDurum = (DosyaDurum)model.DosyaDurumu;
                d.Kategori = (DurumKategori)model.Kategori;
                d.AltAsama = (AltAsama)model.AltAsama;
                d.Oncelik = (Oncelik)model.Oncelik;
                d.Surec = (Surec)model.Surec;
                d.CariID = model.SgrtSirketi;
                d.EksperAdi = model.ExperAdi;
                d.EksperGSM = model.ExperGsm;
                d.EksperTel = model.ExperTel;
                d.EksperEposta = model.ExperTelEposta;
                d.ServisAdi = model.ServisAdi;
                d.ServisYetkili = model.ServisYetkili;
                d.ServisGSM = model.ServisGsm;
                d.ServisTel = model.ServisTel;
                d.AracPlaka = model.AracPlaka;
                d.AracMarka = model.AracMarka;
                d.AracModel = model.AracModel;
                d.AracYil = model.AracYili;
                d.UrunDegerlendirme = model.UrunDegerlendirme;
                //d.FaturaSeriNo = model.FaturaSeriNo;
                //d.FaturaSiraNo = model.FaturaSiraNo;
                //d.FaturaTutar = model.FaturaTutar;
                //d.FaturaTarih = model.FaturaTarih;
                d.DAcilisTarih = model.DAcilisTarih;
                d.DKabulTarih = model.DKabulTarih;
                c.SaveChanges();
                //if ((DosyaDurum)model.DosyaDurumu == DosyaDurum.Faturalandi)
                //{

                //    Faturalar faturalar = new Faturalar();
                //    faturalar.CariId = model.SgrtSirketi;
                //    faturalar.FaturaSeriNo = model.FaturaSeriNo;
                //    faturalar.FaturaSiraNo = model.FaturaSiraNo;
                //    faturalar.Tarih = model.FaturaTarih;
                //    faturalar.DosylarID = model.Id;
                //    c.Faturalars.Add(faturalar);
                //    c.SaveChanges();
                //    foreach (var x in kalemler)
                //    {
                //        FaturaKalem fk = new FaturaKalem();
                //        fk.Aciklama = x.Aciklama;
                //        fk.BirimFiyat = x.BirimFiyat;
                //        fk.Miktar = x.Miktar;
                //        fk.Tutar = x.Tutar;
                //        fk.Kdv = x.Kdv;
                //        fk.UrunId = x.UrunID;
                //        fk.FaturaId = faturalar.FaturaID;
                //        c.FaturaKalems.Add(fk);
                //        c.SaveChanges();
                //    }

                //}
                foreach (var k in kalemler)
                {

                    var p = new DosyaDegisenParca();
                    if (k.DDP_ID != 0)
                    {
                        p = c.DosyaDegisenParcas.Where(y => y.DDP_ID == k.DDP_ID).First();
                        p.Aciklama = k.Aciklama;
                        p.BirimFiyat = k.BirimFiyat;
                        p.Miktar = k.Miktar;
                        p.Tutar = k.Tutar;

                        p.UrunID = k.UrunID;
                        p.DosyaID = d.DosylarID;
                        c.SaveChanges();
                    }
                    else
                    {
                        p.Aciklama = k.Aciklama;
                        p.BirimFiyat = k.BirimFiyat;
                        p.Miktar = k.Miktar;
                        p.Tutar = k.Tutar;
                        p.Kdv = k.Kdv;
                        p.UrunID = k.UrunID;
                        p.DosyaID = d.DosylarID;
                        c.DosyaDegisenParcas.Add(p);
                        c.SaveChanges();
                    }

                }
                ViewBag.Message = "Dosya Başarıyla Güncellendi";
                return Json(ViewBag.Message, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                ViewBag.Message = "Dosya Güncellenemedi";
                return Json(ViewBag.Message, JsonRequestBehavior.AllowGet);
            }

        }
        public ActionResult UrunGetir(int id)
        {
            var urun = c.Uruns.Where(x => x.UrunID == id).Select(y => new
            {
                UrunId = y.UrunID,
                UrunAd = y.UrunAd,
                birimfiyat = y.SatisFiyat,

            }).FirstOrDefault();
            return Json(urun, JsonRequestBehavior.AllowGet);
        }
    }
}