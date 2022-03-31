using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzelRandevu.Models
{
    public class RandevuEkleGuncelleModel
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public DateTime BaslangicTarihi { get; set; }

        public DateTime BitisTarihi { get; set; }

        public string HastaAdi { get; set; }

        public string HastaSoyadi { get; set; }

        public string Aciklama { get; set; }
    }
}
