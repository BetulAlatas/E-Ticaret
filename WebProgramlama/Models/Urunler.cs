//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebProgramlama.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Urunler
    {
        public Urunler()
        {
            this.Favoriler = new HashSet<Favoriler>();
            this.Satislar = new HashSet<Satislar>();
        }
    
        public int UrunID { get; set; }
        public string UrunAdi { get; set; }
        public string Fiyati { get; set; }
        public Nullable<System.DateTime> EklenmeTarihi { get; set; }
        public Nullable<bool> Durum { get; set; }
        public Nullable<int> UyeID { get; set; }
        public Nullable<int> KategoriID { get; set; }
        public string UrunFotografi { get; set; }
        public string Sehir { get; set; }
    
        public virtual ICollection<Favoriler> Favoriler { get; set; }
        public virtual Kategoriler Kategoriler { get; set; }
        public virtual ICollection<Satislar> Satislar { get; set; }
        public virtual Uyeler Uyeler { get; set; }
    }
}
