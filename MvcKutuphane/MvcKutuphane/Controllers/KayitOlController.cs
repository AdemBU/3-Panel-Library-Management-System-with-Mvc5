﻿using MvcKutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class KayitOlController : Controller
    {
        // GET: KayitOl
        DbKutuphaneEntities2 db = new DbKutuphaneEntities2();

        [HttpGet]
        public ActionResult Kayit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Kayit(TBLUYELER p)
        {
            if (!ModelState.IsValid)
            {
                return View("Kayit");
            }
            db.TBLUYELER.Add(p);
            db.SaveChanges();
            return View();
        }

    }
}