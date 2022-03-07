using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EuroStarFOM.Models.Siniflar;
namespace EuroStarFOM.Controllers
{
    public class CariController : Controller
    {
        Context c = new Context();
        // GET: Cari
        public ActionResult Index()
        {
            var degerler = c.Caris.Where(x => x.Durum == true).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult CariEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CariEkle(Cari cari)
        {
            if (!ModelState.IsValid)
            {
                return View(cari);
            }
            else
            {
                cari.Durum = true;
                c.Caris.Add(cari);
                c.SaveChanges();
            }
           
            return RedirectToAction("Index");
        }
        public ActionResult CariSil(int id)
        {
            var cari = c.Caris.Find(id);
            cari.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariGetir(int id)
        {
            var cari = c.Caris.Find(id);
            return View("CariGetir", cari);
        }
        public ActionResult CariGuncelle(Cari cari)
        {
            if (!ModelState.IsValid)
            {
                return View("CariGetir");
            }
            else
            {
                var deger = c.Caris.Find(cari.CariID);
                deger.CariAd = cari.CariAd;
                deger.CariSoyad = cari.CariSoyad;
                deger.CariSehir = cari.CariSehir;
                deger.CariMail = cari.CariMail;
                deger.Durum = true;
                c.SaveChanges();
            }
          
            return RedirectToAction("Index");
        }
        public ActionResult CariSatis(int id)
        {
             var deger = c.SatisHarakets.Where(x=>x.CariId== id).ToList();
            var cariAdi = c.Caris.Where(x => x.CariID == id).Select(y => y.CariAd + " " + y.CariSoyad).FirstOrDefault();
            ViewBag.CariAdi = cariAdi;
            return View(deger);
        }
        public ActionResult CariFatura()
        {
            var degerler = c.Caris.Where(x => x.Durum == true).ToList();
            return View(degerler);
        }
        public ActionResult CariFaturaDetay(int id)
        {
            var deger = c.Faturalars.Where(x => x.CariId == id).ToList();
            var cariAdi = c.Caris.Where(x => x.CariID == id).Select(y => y.CariAd + " " + y.CariSoyad).FirstOrDefault();
            ViewBag.CariAdi = cariAdi;
            return View(deger);

        }
        public ActionResult TarihAraligi(int id,DateTime altsinir,DateTime ustsinir,string islemtip)
        {
            var d = c.Faturalars.ToList();
            try
            {
                if (islemtip == "")
                {
                    var deger = c.Faturalars.Where(x => x.CariId == id && x.VadeTarih >= altsinir && x.VadeTarih <= ustsinir)
                    .Select(y => new {
                        IslemTip = y.IslemTip,
                        SeriSiraNo = y.FaturaSeriNo + y.FaturaSiraNo,
                        IrsaliyeNo = y.IrsaliyeNumarasi,
                        Tarih = y.Tarih,
                        VadeTarih = y.VadeTarih,
                        Toplam = y.Toplam
                    })
                .ToList();
                    return Json(deger, JsonRequestBehavior.AllowGet);

                }
                else
                {
                    var deger = c.Faturalars.Where(x => x.CariId == id && x.VadeTarih >= altsinir && x.VadeTarih <= ustsinir && x.IslemTip == islemtip)
                   .Select(y => new {
                       IslemTip = y.IslemTip,
                       SeriSiraNo = y.FaturaSeriNo + y.FaturaSiraNo,
                       IrsaliyeNo = y.IrsaliyeNumarasi,
                       Tarih = y.Tarih,
                       VadeTarih = y.VadeTarih,
                       Toplam = y.Toplam
                   })
                .ToList();
                    return Json(deger, JsonRequestBehavior.AllowGet);

                }
            }
            catch (Exception)
            {

                return View("Index");
            }
           

        }
        public ActionResult CariFaturaData(int id)
        {
            var deger = c.Faturalars.Where(x => x.CariId == id )
                .Select(y => new {
                    IslemTip = y.IslemTip,
                    SeriSiraNo = y.FaturaSeriNo + y.FaturaSiraNo,
                    IrsaliyeNo = y.IrsaliyeNumarasi,
                    Tarih = y.Tarih,
                    VadeTarih = y.VadeTarih,
                    Toplam = y.Toplam
                })
                .ToList();

            return Json(deger, JsonRequestBehavior.AllowGet);

        }
    }
}