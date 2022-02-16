using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EuroStarFOM.Models.Siniflar;
using EuroStarFOM.Models.SinifModel;
namespace EuroStarFOM.Controllers
{
    public class FaturaController : Controller
    {
        Context c = new Context();
        // GET: Fatura
        public ActionResult Index()
        {
            FaturaFKalemModel ffkm = new FaturaFKalemModel();
            ffkm.FaturalarDeger = c.Faturalars.ToList();
            ffkm.FaturaKalemDeger = c.FaturaKalems.ToList();
            ffkm.CariDeger = c.Caris.ToList();
            ffkm.UrunDeger = c.Uruns.ToList();

            return View(ffkm);
        }
        [HttpGet]
        public ActionResult FaturaEkle()
        {
            List<SelectListItem> deger = (from x in c.Caris.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.CariAd + " " + x.CariSoyad,
                                              Value = x.CariID.ToString()
                                          }).ToList();
            ViewBag.CariList = deger;
            return View();
        }
        [HttpPost]
        public ActionResult FaturaEkle(Faturalar faturalar)
        {
            c.Faturalars.Add(faturalar);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaGetir(int id)
        {
            var fatura = c.Faturalars.Find(id);
            return View("FaturaGetir", fatura);
        }
        public ActionResult FaturaGuncelle(Faturalar fatura)
        {
            var faturaDeger = c.Faturalars.Find(fatura.FaturaID);
            faturaDeger.FaturaSeriNo = fatura.FaturaSeriNo;
            faturaDeger.FaturaSiraNo = fatura.FaturaSiraNo;
            faturaDeger.VergiDairesi = fatura.VergiDairesi;
            faturaDeger.Tarih = fatura.Tarih;
            faturaDeger.Saat = fatura.Saat;
            faturaDeger.TeslimEden = fatura.TeslimEden;
            faturaDeger.TeslimAlan = fatura.TeslimAlan;


            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaDetay(int id)
        {
            var degerler = c.FaturaKalems.Where(x => x.FaturaId == id).ToList();

            var faturaId = c.Faturalars.Where(x => x.FaturaID == id).Select(y => y.FaturaID).FirstOrDefault();
            var faturaCari = c.Faturalars.Where(x => x.FaturaID == id).Select(y => y.Cari.CariAd + " " + y.Cari.CariSoyad).FirstOrDefault();
            var faturaVergiDairesi = c.Faturalars.Where(x => x.FaturaID == id).Select(y => y.VergiDairesi).FirstOrDefault();
            var faturaSeriSiraNo = c.Faturalars.Where(x => x.FaturaID == id).Select(y => y.FaturaSeriNo + " " + y.FaturaSiraNo).FirstOrDefault();

            ViewBag.FaturaId = faturaId;
            ViewBag.FaturaCari = faturaCari;
            ViewBag.FaturaVergiDairesi = faturaVergiDairesi;
            ViewBag.FaturaSeriSiraNo = faturaSeriSiraNo;

            return View(degerler);
        }
        [HttpGet]
        public ActionResult FaturaKalemEkle(int id)
        {
            List<SelectListItem> deger = (from x in c.Uruns.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.UrunAd,
                                              Value = x.UrunID.ToString()
                                          }).ToList();
            ViewBag.UrunList = deger;
            ViewBag.FaturaId = id;
            return View();
        }
        [HttpPost]
        public ActionResult FaturaKalemEkle(FaturaKalem faturaKalem, int id)
        {
            var tutar = c.Uruns.Find(faturaKalem.UrunId);
            faturaKalem.FaturaId = id;
            faturaKalem.BirimFiyat = tutar.SatisFiyat;
            faturaKalem.Tutar = Convert.ToInt32(faturaKalem.Miktar) * Convert.ToInt32(tutar.SatisFiyat);
            c.FaturaKalems.Add(faturaKalem);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult DinamikFaturaEkle()
        {
            FaturaFKalemModel ffkm = new FaturaFKalemModel();
            ffkm.FaturalarDeger = c.Faturalars.ToList();
            ffkm.FaturaKalemDeger = c.FaturaKalems.ToList();
            ffkm.CariDeger = c.Caris.ToList();
            ffkm.UrunDeger = c.Uruns.ToList();
            ffkm.DepoDeger = c.Depos.Where(x=>x.Durum==true).ToList();
            return View(ffkm);
        }
        [HttpPost]
        public ActionResult DinamikFaturaEkle(string FaturaSeriNo, string FaturaSiraNo, DateTime Tarih, DateTime VadeTarih, string VergiDairesi, int VergiNumarasi, string IrsaliyeNumarasi, string Adres, string AciklamaFatura, string IslemTip, int CariID, int DepoId, string GenelToplam, FaturaKalem[] kalemler)
        {
            try
            {
                Faturalar f = new Faturalar();
                f.FaturaSeriNo = FaturaSeriNo;
                f.FaturaSiraNo = FaturaSiraNo;
                f.Tarih = Tarih;
                f.VadeTarih = VadeTarih;
                f.VergiDairesi = VergiDairesi;
                f.VergiNumarasi = VergiNumarasi;
                f.IrsaliyeNumarasi = IrsaliyeNumarasi;
                f.Adres = Adres;
                f.Saat = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString();
                f.Toplam = decimal.Parse(GenelToplam);
                f.CariId = CariID;
                f.DepoId = DepoId;
                f.Aciklama = AciklamaFatura;
                f.IslemTip = IslemTip;
                f.TeslimEden = c.Caris.Where(x => x.CariID == CariID).Select(y => y.CariAd + " " + y.CariSoyad).FirstOrDefault();
                f.TeslimAlan = c.Caris.Where(x => x.CariID == CariID).Select(y => y.CariAd + " " + y.CariSoyad).FirstOrDefault();

                c.Faturalars.Add(f);

                foreach (var x in kalemler)
                {
                    FaturaKalem fk = new FaturaKalem();
                    fk.Aciklama = x.Aciklama;
                    fk.BirimFiyat = x.BirimFiyat;
                    fk.Miktar = x.Miktar;
                    fk.Tutar = x.Tutar;
                    fk.Kdv = x.Kdv;
                    fk.UrunId = x.UrunId;
                    fk.FaturaId = x.FaturaKalemID;
                    c.FaturaKalems.Add(fk);
                }
                c.SaveChanges();
                ViewBag.Message = "Fatura Başarıyla Kaydedildi";
                return Json(ViewBag.Message, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return RedirectToAction("DinamikFaturaEkle");
            }
           
        }

    }
}