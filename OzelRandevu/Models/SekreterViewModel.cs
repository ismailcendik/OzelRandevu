using OzelRandevu.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzelRandevu.Models
{
    public class SekreterViewModel
    {
        public  Ozel_Randevu_Kullanicilar Kullanicilar { get; set; }
        public IEnumerable<Ozel_Randevu_Kullanicilar> Doktor { get; set; }
    }
}
