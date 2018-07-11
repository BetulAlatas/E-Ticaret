using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebProgramlama;
using WebProgramlama.Models;


namespace WebProgramlama.Models
{
    public class MultipleModel
   {        
       public List<Urunler>urunler {get; set;}
        
       public List<Uyeler> uyeler { get; set; }

       public List<Urunler> tumUrunler { get; set; }
       
    }
}
