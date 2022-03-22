using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OzelRandevu.Data.Entity
{
    public class Ozel_Randevu
    {
        
        public int Id { get; set; }

        public string UserId { get; set; }

        public Ozel_Randevu_Kullanicilar User { get; set; }

        public DateTime OlusturmaTarihi { get; set; }

        public DateTime GuncellemeTarihi { get; set; }

        public DateTime BaslangicTarihi { get; set; }

        public DateTime BitisTarihi { get; set; }

        public string HastaAdi { get; set; }

        public string HastaSoyadi { get; set; }

        public string Aciklama { get; set; }


    }
}
