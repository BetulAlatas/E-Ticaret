﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebProgramlama.Areas.Admin.Controllers
{
    public class AnaSayfaController : Controller
    {
        // GET: Admin/AnaSayfa
        public ActionResult Index()
        {
            return View();
        }
    }
}