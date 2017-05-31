
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


namespace WebProgramlama.Controllers
{
    public class UyelerController : Controller
    {
        private Entities db = new Entities();

        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection fm)
        {
            

            String KullaniciAdi = fm["KullaniciAdi"].ToString();
            String Sifre = fm["Sifre"].ToString();

            var bilgiler = db.Uyeler.FirstOrDefault(x => x.KullaniciAdi == KullaniciAdi && x.Sifre == Sifre);


            if (bilgiler != null)
            {
                Session["ID"] = bilgiler.UyeID;
                Session["Giris"] = 1;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                Session["Giris"] = 0;
                return View();
            }

        }

        public ActionResult YeniKullanici()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKullanici(FormCollection fm)
        {
           
            Uyeler yeniKayit = new Uyeler();

            String Adi = fm["Adi"].ToString();
            String Soyadi = fm["Soyadi"].ToString();
            String KullaniciAdi = fm["KullaniciAdi"].ToString();
            String Sifre = fm["Sifre"].ToString();
            String KayitTarihi = fm["KayitTarihi"].ToString();
            String Fotograf = fm["Fotograf"].ToString();
            String Sehir = fm["Sehir"].ToString();
            String Telefon = fm["Telefon"].ToString();

            yeniKayit.Adi = Adi;
            yeniKayit.Soyadi = Soyadi;
            yeniKayit.KullaniciAdi = KullaniciAdi;
            yeniKayit.Sifre = Sifre;
            yeniKayit.KayitTarihi = DateTime.Parse(KayitTarihi);
            //  yeniKayit.Fotograf = Fotograf;
            yeniKayit.Sehir = Sehir;
            //  yeniKayit.Telefon = Telefon;


            db.Uyeler.Add(yeniKayit);

            db.SaveChanges();

            return RedirectToAction("Login", "Login");
        }

        public ActionResult Cikis()
        {
            Session["Giris"]=0;
            return RedirectToAction("Index", "Home");
        }
    }
}
