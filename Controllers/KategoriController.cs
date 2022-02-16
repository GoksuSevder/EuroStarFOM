using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EuroStarFOM.Models.Siniflar;
namespace EuroStarFOM.Controllers
{
    public class KategoriController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Kategoris.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View( );
        }
        [HttpPost]
        public ActionResult KategoriEkle(Kategori k)
        {
            try
            {
                c.Kategoris.Add(k);
                c.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                return View(k);
            }
           
        }
        public ActionResult KategoriSil(int id)
        {
            try
            {
                var ktg = c.Kategoris.Find(id);
                c.Kategoris.Remove(ktg);
                c.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                return RedirectToAction("Index");
            }
           
        }
        public ActionResult KategoriGetir(int id)
        {
            try
            {
                var kategori = c.Kategoris.Find(id);
                return View("KategoriGetir", kategori);
            }
            catch (Exception)
            {
                return View(id);
            }
           
        }

        public ActionResult KategoriGuncelle(Kategori k)
        {
            try
            {
                var kategori = c.Kategoris.Find(k.KategoriId);
                kategori.KategoriAd = k.KategoriAd;
                c.SaveChanges();
                return RedirectToAction("Index", "Kategori");
            }
            catch (Exception)
            {

                return View(k);
            }
           
        }
    }
}