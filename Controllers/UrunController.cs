using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EuroStarFOM.Models.Siniflar;
namespace EuroStarFOM.Controllers
{
    public class UrunController : Controller
    {
        Context c = new Context();
        // GET: Urun
        public ActionResult Index()
        {
            var urunler = c.Uruns.Where(x => x.Durum == true).ToList();

            return View(urunler);
        }
        [HttpGet]
        public ActionResult UrunEkle()
        {
            List<SelectListItem> deger = (from x in c.Kategoris.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.KategoriAd,
                                              Value = x.KategoriId.ToString()
                                          }).ToList();
            ViewBag.kategoriList = deger;
            return View();
        }
        [HttpPost]
        public ActionResult UrunEkle(Urun u)
        {
            try
            {
                string kelime = "";
                var rnd = new Random();
                for (int i = 0; i < 4; i++)
                {
                    kelime += ((char)rnd.Next('A', 'Z')).ToString();
                }
                var stok = new Stok();
                stok.Aciklama = "Açıklama Yaz.";
                stok.Durum = true;
                stok.Miktar = 0;
                stok.DepoId = 1;
                stok.StokKod = kelime + DateTime.Now.ToString("yyyymmdd");
                stok.StokTarih = DateTime.Parse(DateTime.Now.ToShortDateString());
                c.Stoks.Add(stok);
                c.SaveChanges();
                u.Durum = true;
                u.StokId = stok.StokId;
                c.Uruns.Add(u);

                c.SaveChanges();
                return RedirectToAction("Index", "Urun");
            }
            catch (Exception)
            {

                return View(u);
            }
        }
        public ActionResult UrunSil(int id)
        {
            try
            {
                var deger = c.Uruns.Find(id);
                deger.Durum = false;
                c.SaveChanges();
                return RedirectToAction("Index", "Urun");
            }
            catch (Exception)
            {

                return RedirectToAction("Index");
            }
           
        }
        public ActionResult UrunGetir(int id)
        {
            try
            {
                List<SelectListItem> deger = (from x in c.Kategoris.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.KategoriAd,
                                                  Value = x.KategoriId.ToString()
                                              }).ToList();
                ViewBag.kategoriList = deger;
                var degerUrun = c.Uruns.Find(id);
                return View("UrunGetir", degerUrun);
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
          
        }
        public ActionResult UrunGuncelle(Urun urun)
        {
            try
            {
                var degerUrun = c.Uruns.Find(urun.UrunID);
                degerUrun.AlisFiyat = urun.AlisFiyat;
                degerUrun.AlisKdv = urun.AlisKdv;
                degerUrun.SatisFiyat = urun.SatisFiyat;
                degerUrun.SatisKdv = urun.SatisKdv;
                degerUrun.Durum = true;
                degerUrun.UrunAd = urun.UrunAd;
                degerUrun.UrunKodu = urun.UrunKodu;
                degerUrun.Barkod = urun.Barkod;
                degerUrun.Marka = urun.Marka;
                degerUrun.Model = urun.Model;

                degerUrun.UrunGorsel = urun.UrunGorsel;
                degerUrun.KategoriId = urun.KategoriId;
                c.SaveChanges();

                return RedirectToAction("Index", "Urun");
            }
            catch (Exception)
            {

                return RedirectToAction("Index");
            }
           
        }

        public ActionResult UrunListesi()
        {
            var degerler = c.Uruns.ToList();
            return View(degerler);
        }
    }
}