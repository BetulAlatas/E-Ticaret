using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProgramlama.Models;
using WebProgramlama;


namespace WebProgramlama.Controllers
{
    public class DetaylarController : Controller
    {
        private Entities db = new Entities();
        public ActionResult Detaylar(int id)
        {
            var _urunDetay = db.Urunler.FirstOrDefault(x => x.UrunID == id);
            var urunDetay = db.Urunler.Where(x => x.UrunID == id).ToList();
            var tumUrunler = db.Urunler.Where(x => x.Uyeler.UyeID == _urunDetay.Uyeler.UyeID).ToList() ;

            var uye = db.Uyeler.Where(x => x.UyeID == _urunDetay.Uyeler.UyeID).ToList();
            MultipleModel mymodel = new MultipleModel
            {
                uyeler = uye,
                urunler = urunDetay,
                tumUrunler=tumUrunler
            };


            return View(mymodel);

        }




    }
}