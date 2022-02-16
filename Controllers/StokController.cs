using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EuroStarFOM.Models.Siniflar;
using EuroStarFOM.Models.SinifModel;

namespace EuroStarFOM.Controllers
{
    public class StokController : Controller
    {
        Context c = new Context();
        // GET: Stok
        public ActionResult Index(int id)
        {

            var urun = c.Uruns.Where(x => x.Stok.DepoId == id && x.Durum==true).ToList();
            
            return View(urun);
        }
        [HttpGet]
        public ActionResult StokGuncelle(int? id)
        {
            var model = new StokUrunEkleModel();
            var urun = c.Uruns.Where(x => x.UrunID == id).FirstOrDefault();
            var depo = c.Depos.ToList();
            model.Urun = urun;
            model.DepoDeger = depo;
            model.Stok= c.Stoks.Where(x => x.StokId == urun.StokId).FirstOrDefault();

            return View(model);
        }
        [HttpPost]
        public ActionResult StokGuncelle(int id, int Miktar, string Aciklama, int DepoId)
        {
            var stokID = c.Uruns.Where(x => x.UrunID == id && x.Durum==true).Select(y => y.StokId).FirstOrDefault();
            if (stokID >= 0 )
            {
                var deger = c.Stoks.Where(x => x.StokId == stokID).FirstOrDefault();
                deger.Aciklama = Aciklama;
                deger.Miktar = Miktar;
                deger.StokTarih= DateTime.Today;
                deger.DepoId = DepoId;
                c.SaveChanges();

            }           
            return Redirect("/Stok/Index?id="+ DepoId);
        }
       
    }
}