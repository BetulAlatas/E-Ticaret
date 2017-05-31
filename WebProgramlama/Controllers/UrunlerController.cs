using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebProgramlama;
using WebProgramlama.Models;
using System.IO;


namespace WebProgramlama.Controllers
{
    public class UrunlerController : Controller
    {
        private Entities db = new Entities();
        

        public ActionResult Ekle()
        {
            LoginControl control = new LoginControl();


            if (control.Control())
            {
                return View(db.Kategoriler.ToList());
            }

            else
            {
                return RedirectToAction("Login", "Uyeler");
            }
               
         
        }
    
        
        [HttpPost]
        public ActionResult Ekle(FormCollection fm,HttpPostedFileBase Fotograf)
        {
            Urunler yeniKayit = new Urunler();

           if (Request.Files.Count != null)
           {
               
                String UrunAdi = fm["UrunAdi"].ToString();
                String UrunFiyati = fm["UrunFiyati"].ToString();
                String EklenmeTarihi = fm["EklenmeTarihi"].ToString();
                var DosyaYolu = "images/" + Path.GetFileName(Fotograf.FileName);
                Fotograf.SaveAs(Server.MapPath("~/images/" + Fotograf.FileName));           
                int KategoriId = Convert.ToInt32(fm["id2"].ToString());



                yeniKayit.EklenmeTarihi = DateTime.Parse(EklenmeTarihi);
                yeniKayit.UrunAdi = UrunAdi;
                yeniKayit.Fiyati = UrunFiyati;
                yeniKayit.UrunFotografi =DosyaYolu;
                yeniKayit.Durum = true;                
                yeniKayit.KategoriID = KategoriId;
                yeniKayit.UyeID = Convert.ToInt32(Session["ID"]);

            }

            db.Urunler.Add(yeniKayit);
            db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Kategoriler(int id)
        {
            var bilgiler = db.Urunler.Where(x => x.KategoriID == id).ToList();
            return View(bilgiler);

        }

        [HttpPost]
        public ActionResult Arama(string Kriter, FormCollection fm)
        {
            if (Kriter == "")
            {
                string Sehir = fm["Sehir"].ToString();
                var model = db.Urunler.Where(x => x.Sehir.Contains(Sehir));

                return View(model);
                
            }
            else
            {
                var model = db.Urunler.Where(x => x.UrunAdi.Contains(Kriter));
                return View(model);
            }
         }

     


       
    }
}
