using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class IstatistikController : Controller
    {
        // GET: Istatistik
        DbKutuphaneEntities2 db = new DbKutuphaneEntities2();
        public ActionResult Index()
        {
            var deger1 = db.TBLUYELER.Count();
            var deger2 = db.TBLKITAP.Count();
            var deger3 = db.TBLKITAP.Where(w => w.DURUM == false).Count();
            var deger4 = db.TBLCEZALAR.Sum(s => s.PARA);
            ViewBag.Dgr1 = deger1;
            ViewBag.Dgr2 = deger2;
            ViewBag.Dgr3 = deger3;
            ViewBag.Dgr4 = deger4;
            return View();
        }

        public ActionResult Hava()
        {
            return View();
        }

        public ActionResult HavaKart()
        {
            return View();
        }

        public ActionResult Galeri()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ResimYukle(HttpPostedFileBase dosya)
        {
            if (dosya.ContentLength > 0)
            {
                string dosyayolu = Path.Combine(Server.MapPath("~/web2/resimler/"), Path.GetFileName(dosya.FileName));
                dosya.SaveAs(dosyayolu);
            }
            return RedirectToAction("Galeri");
        }

        public ActionResult LinqKart()
        {
            var deger1 = db.TBLKITAP.Count();
            var deger2 = db.TBLUYELER.Count();
            var deger3 = db.TBLCEZALAR.Sum(x => x.PARA);
            var deger4 = db.TBLKITAP.Where(x => x.DURUM == false).Count();
            var deger5 = db.TBLKATEGORI.Count();
            var deger6 = db.EnAktifKullanıcı().Select(r => new { r.AD, r.SOYAD }).FirstOrDefault();
            var deger7 = db.EnCokOkunanKitap().FirstOrDefault();
            var deger8 = db.EnFazlaKitapYazar().FirstOrDefault();
            var deger9 = db.TBLKITAP.GroupBy(x => x.YAYINEVI).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault();
            var deger10 = db.EnBasariliPersonel().FirstOrDefault();
            var deger11 = db.TBLILETISIM.Count();
            var deger12 = db.TBLHAREKET.Where(x => x.ALISTARIH == DateTime.Today).Select(c => c.KITAP).Count();

            ViewBag.Dgr1 = deger1;
            ViewBag.Dgr2 = deger2;
            ViewBag.Dgr3 = deger3;
            ViewBag.Dgr4 = deger4;
            ViewBag.Dgr5 = deger5;
            ViewBag.Dgr6 = deger6;
            ViewBag.Dgr7 = deger7;
            ViewBag.Dgr8 = deger8;
            ViewBag.Dgr9 = deger9;
            ViewBag.Dgr10 = deger10;
            ViewBag.Dgr11 = deger11;
            ViewBag.Dgr12 = deger12;

            return View();
        }
    }
}