using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EuroStarFOM.Models.Siniflar;
namespace EuroStarFOM.Controllers
{
    public class SatisController : Controller
    {
        Context c = new Context();
        // GET: Satis
        public ActionResult Index()
        {
            var degerler = c.SatisHarakets.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            List<SelectListItem> urundeger = (from u in c.Uruns.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = u.UrunAd,
                                                  Value = u.UrunID.ToString()
                                              }
                                              ).ToList();
            List<SelectListItem> carideger = (from u in c.Caris.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = u.CariAd + " " + u.CariSoyad,
                                                  Value = u.CariID.ToString()
                                              }
                                             ).ToList();
            List<SelectListItem> personeldeger = (from u in c.Personels.ToList()
                                                  select new SelectListItem
                                                  {
                                                      Text = u.PersonelAd + " " + u.PersonelSoyad,
                                                      Value = u.PersonelID.ToString()
                                                  }
                                             ).ToList();

            ViewBag.Urundeger = urundeger;
            ViewBag.Carideger = carideger;
            ViewBag.Personeldeger = personeldeger;


            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(SatisHaraket satisHaraket)
        {
            try
            {
                satisHaraket.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
                c.SatisHarakets.Add(satisHaraket);
                c.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                return View(satisHaraket);
            }
           
        }
        public ActionResult SatisGetir(int id)
        {
            List<SelectListItem> urundeger = (from u in c.Uruns.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = u.UrunAd,
                                                  Value = u.UrunID.ToString()
                                              }
                                                ).ToList();
            List<SelectListItem> carideger = (from u in c.Caris.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = u.CariAd + " " + u.CariSoyad,
                                                  Value = u.CariID.ToString()
                                              }
                                             ).ToList();
            List<SelectListItem> personeldeger = (from u in c.Personels.ToList()
                                                  select new SelectListItem
                                                  {
                                                      Text = u.PersonelAd + " " + u.PersonelSoyad,
                                                      Value = u.PersonelID.ToString()
                                                  }
                                             ).ToList();

            ViewBag.Urundeger = urundeger;
            ViewBag.Carideger = carideger;
            ViewBag.Personeldeger = personeldeger;

            var deger = c.SatisHarakets.Find(id);
            return View("SatisGetir", deger);

        }
        public ActionResult SatisGuncelle(SatisHaraket satisHaraket)
        {
            var deger = c.SatisHarakets.Find(satisHaraket.SatisID);
            deger.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            deger.UrunId = satisHaraket.UrunId;
            deger.CariId = satisHaraket.CariId;
            deger.PersonelId = satisHaraket.PersonelId;
            deger.Adet = satisHaraket.Adet;
            deger.Fiyat = satisHaraket.Fiyat;
            deger.ToplamTutar = satisHaraket.ToplamTutar;
            c.SaveChanges();
            return RedirectToAction("Index", "Satis");
        }
        public ActionResult SatisDetay(int id)
        {
            var degerler = c.SatisHarakets.Where(x => x.SatisID == id).ToList();
            return View(degerler);
        }
    }
}