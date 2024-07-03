using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;
using MvcKutuphane.Models.Siniflarim;

namespace MvcKutuphane.Controllers
{
    public class VitrinController : Controller
    {
        // GET: Vitrin
        DbKutuphaneEntities2 db = new DbKutuphaneEntities2();
        [HttpGet]
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.Deger1 = db.TBLKITAP.ToList();
            cs.Deger2 = db.TBLHAKKIMIZDA.ToList();
            //var degerler = db.TBLKITAP.ToList();
            return View(cs);
        }

        [HttpPost]
        public ActionResult Index(TBLILETISIM p)
        {
            db.TBLILETISIM.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}