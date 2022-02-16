using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EuroStarFOM.Models.Siniflar;
namespace EuroStarFOM.Controllers
{
    public class PersonelController : Controller
    {
        Context c = new Context();
        // GET: Personel
        public ActionResult Index()
        {
            var degerler = c.Personels.Where(x=>x.Durum==true).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult PersonelEkle()
        {
          
            List<SelectListItem> deger = (from x in c.Departmans.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.DepartmanAd,
                                              Value = x.DepartmanID.ToString()
                                          }).ToList();
            ViewBag.departmanList = deger;
            return View();
        }
        [HttpPost]
        public ActionResult PersonelEkle(Personel p)
        {
            if (!ModelState.IsValid)
            {
                return View(p);
            }
            else
            {
                p.Durum = true;
                c.Personels.Add(p);
                c.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        public ActionResult PersonelGetir(int id)
        {
            List<SelectListItem> deger = (from x in c.Departmans.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.DepartmanAd,
                                              Value = x.DepartmanID.ToString()
                                          }).ToList();
            ViewBag.departmanList = deger;
            var personel = c.Personels.Find(id);
            return View("PersonelGetir", personel);
        }
        public ActionResult PersonelGuncelle(Personel personel)
        {
            var degerpersonel = c.Personels.Find(personel.PersonelID);
            degerpersonel.PersonelAd = personel.PersonelAd;
            degerpersonel.PersonelSoyad = personel.PersonelSoyad;
            degerpersonel.DepartmanId = personel.DepartmanId;
            degerpersonel.PersonelGorsel = personel.PersonelGorsel;
            degerpersonel.Durum =true;
            c.SaveChanges();
            return RedirectToAction("Index", "Personel");
        }
    }
}