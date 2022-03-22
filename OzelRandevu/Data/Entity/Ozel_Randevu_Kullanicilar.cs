using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzelRandevu.Data.Entity
{
    public class Ozel_Randevu_Kullanicilar :IdentityUser
    {
        public bool Doktor { get; set; }

        public string Ad { get; set; }

        public string Soyad { get; set; }

        public string Renk { get; set; }


        public List<Ozel_Randevu> OzelRandevular { get; set; }
    }
}
