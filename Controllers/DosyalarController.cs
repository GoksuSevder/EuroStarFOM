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
                var dosyaDurumu = DosyaDurumu == 0 ? default : degerler.Where(x => x.DosyaDurum ==(DosyaDurum)DosyaDurumu).ToList();
                return Json(dosyaDurumu, JsonRequestBehavior.AllowGet);
            }

            return Json(degerler, JsonRequestBehavior.AllowGet);
        }
        public ActionResult AcikDosyalar()
        {
            return View();
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
                d.DosyaDurum = (DosyaDurum)1;
                d.Kategori = (DurumKategori)1;
                d.AltAsama = (AltAsama)1;
                d.Oncelik = (Oncelik)1;
                d.Surec = (Surec)1;
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
                d.FaturaNo = model.FaturaNo;
                d.FaturaTutar = model.FaturaTutar;
                d.FaturaTarih = model.FaturaTarih;
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
                ViewBag.Message = "Dosya Başarıyla Kaydedildi";
                return Json(ViewBag.Message, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                ViewBag.Message = "Dosya Kaydedilmedi";
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