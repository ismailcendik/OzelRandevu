using System;

namespace OzelRandevu
{
    public class RandevuViewModel
    {
        public int Id { get; set; }

        public string Doktor { get; internal set; }

        public string HastaAdi { get; internal set; }

        public string HastaSoyadi { get; internal set; }

        public DateTime BaslangicTarihi { get; internal set; }

        public DateTime BitisTarihi { get; internal set; }

        public string Aciklama { get; internal set; }

        public string UserId { get; internal set; }

        public string Renk { get; internal set; }
    }
}