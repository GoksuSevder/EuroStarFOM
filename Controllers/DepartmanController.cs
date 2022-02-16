using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EuroStarFOM.Models.Siniflar;
namespace EuroStarFOM.Controllers
{
    public class DepartmanController : Controller
    {
        Context c = new Context();
        // GET: Departman
        public ActionResult Index()
        {
            var degerler = c.Departmans.Where(x => x.Durum == true).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DepartmanEkle(Departman d)
        {
            try
            {
                c.Departmans.Add(d);
                c.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                return View(d);
            }
           
        }
        public ActionResult DepartmanSil(int id)
        {
            try
            {
                var departman = c.Departmans.Find(id);
                departman.Durum = false;
                c.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                return RedirectToAction("Index");
            }
       
        }
        public ActionResult DepartmanGetir(int id)
        {
            try
            {
                var departman = c.Departmans.Find(id);
                return View("DepartmanGetir", departman);
            }
            catch (Exception)
            {

                return RedirectToAction("Index");
            }
           
        }
        public ActionResult DepartmanGuncelle(Departman d)
        {
            try
            {
                var departman = c.Departmans.Find(d.DepartmanID);
                departman.DepartmanAd = d.DepartmanAd;
                departman.Durum = true;
                c.SaveChanges();
                return RedirectToAction("Index", "Departman");
            }
            catch (Exception)
            {

                return RedirectToAction("Index");
            }
           
        }
        public ActionResult DepartmanDetay(int id)
        {
            var degerler = c.Personels.Where(x=>x.DepartmanId == id).ToList();
            var dptAd = c.Departmans.Where(x => x.DepartmanID == id).Select(y => y.DepartmanAd).FirstOrDefault();
            ViewBag.DepartmaninAdi = dptAd;
            
            return View(degerler);
        }
        public ActionResult DepartmanPersonelSatis(int id)
        {
            var degerler = c.SatisHarakets.Where(x => x.PersonelId == id).ToList();
            var personelAdi = c.Personels.Where(x => x.PersonelID == id).Select(y => y.PersonelAd +" "+ y.PersonelSoyad).FirstOrDefault();
            ViewBag.PersonelAdi = personelAdi;
            return View(degerler);
        }
    }
}