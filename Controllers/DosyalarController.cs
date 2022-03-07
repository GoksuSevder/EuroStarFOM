using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EuroStarFOM.Controllers
{
    public class DosyalarController : Controller
    {
        // GET: Dosyalar
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AcikDosyalar()
        {
            return View();
        }
    }
}