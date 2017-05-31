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
   
    public class HomeController : Controller
    {
        private Entities db = new Entities();

        public ActionResult Index(int sayfa=1)
        {
           
         return View(db.Urunler.ToList().ToPagedList(sayfa,8));  
        }

      
    
    }
}