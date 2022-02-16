using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EuroStarFOM.Models.Siniflar;
namespace EuroStarFOM.Controllers
{
    public class DepoController : Controller
    {
        Context c = new Context();
        // GET: Depo
        public ActionResult Index()
        {
            var depolar = c.Depos.Where(x => x.Durum == true).ToList();
            return View(depolar);
        }
        [HttpGet]
        public ActionResult DepoEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DepoEkle(Depo depo)
        {
            try
            {
                depo.Durum = true;
                c.Depos.Add(depo);
                c.SaveChanges();
                return RedirectToAction("Index", "Depo");
            }
            catch (Exception)
            {

                return View(depo);
            }
        }
        public ActionResult DepoSil(int id)
        {
            try
            {
                var deger = c.Depos.Find(id);
                deger.Durum = false;
                c.SaveChanges();
                return RedirectToAction("Index", "Depo");
            }
            catch (Exception)
            {

                return RedirectToAction("Index", "Depo");
            }
            
        }
        public ActionResult DepoGetir(int id)
        {
            try
            {
                var deger = c.Depos.Find(id);
                return View("DepoGetir", deger);
            }
            catch (Exception)
            {

                return View(id);
            }
           
        }
        public ActionResult DepoGuncelle(Depo depo)
        {
            try
            {
                var deger = c.Depos.Find(depo.DepoId);
                deger.DepoAd = depo.DepoAd;
                deger.Aciklama = depo.Aciklama;
                c.SaveChanges();
                return RedirectToAction("Index", "Depo");
            }
            catch (Exception)
            {

                return View(depo);
            }
           
        }
       
    }
}