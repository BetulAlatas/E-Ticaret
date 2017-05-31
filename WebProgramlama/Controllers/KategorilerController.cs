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
    public class KategorilerController : Controller
    {
        private Entities db = new Entities();

        
        public ActionResult Index()
        {
            LoginControl control = new LoginControl();


            if (control.Control())
            {
                return View(db.Kategoriler);
            }

            else
            {
                return RedirectToAction("Login", "Uyeler");
            }


        }
        public ActionResult Kategoriler(int id)
        {
           var bilgiler = db.Kategoriler.Where(x => x.KategoriID == id).ToList();
            return View(bilgiler);

        }



      
    }
}