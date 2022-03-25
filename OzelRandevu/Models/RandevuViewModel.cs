using System;

namespace OzelRandevu
{
    public class RandevuViewModel
    {
        public RandevuViewModel()
        {
        }

        public string Doktor { get; internal set; }
        public string Hasta { get; internal set; }
        public DateTime BaslangicTarihi { get; internal set; }
        public DateTime BitisTarihi { get; internal set; }
        public string Aciklama { get; internal set; }
        public string UserId { get; internal set; }
    }
}