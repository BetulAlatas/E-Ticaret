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

using PagedList.Mvc;
using PagedList;

namespace WebProgramlama.Controllers
{
    public class SatislarController : Controller
    {
        private Entities db = new Entities();

 

        
         public ActionResult Satislar()
        {
            LoginControl control = new LoginControl();


            if (control.Control())
            {
                int UyeID = Convert.ToInt32(Session["ID"]);
                var satis = db.Satislar.Where(x => x.SatanUyeID == UyeID).ToList();
                List<Urunler> model = new List<Urunler>();
                foreach (var item in satis)
                {

                    model.Add(db.Urunler.FirstOrDefault(x => x.UrunID == item.Urunler.UrunID));
                }
                return View(model);
            }
            else
            {
                return RedirectToAction("Login", "Uyeler");
            }

        
        }


        public ActionResult Aldıklarım()
         {
             LoginControl control = new LoginControl();


             if (control.Control())
             {
                 int UyeID = Convert.ToInt32(Session["ID"]);
                 var satis = db.Satislar.Where(x => x.AlanUyeID == UyeID).ToList();
                 List<Urunler> model = new List<Urunler>();
                 foreach (var item in satis)
                 {

                     model.Add(db.Urunler.FirstOrDefault(x => x.UrunID == item.Urunler.UrunID));
                 }
                 return View(model);
             }
             else
             {
                 return RedirectToAction("Login", "Uyeler");
             }


         }


        
    }
}
