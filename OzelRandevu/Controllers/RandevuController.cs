using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OzelRandevu.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzelRandevu.Controllers
{
    public class RandevuController : Controller
    {
        private ApplicationDbContext _context;

        public RandevuController(ApplicationDbContext context)
        {

            _context = context;

        }

        public JsonResult GetRandevu()
        {
            var model = _context.OzelRandevular        /* sorgulamaya gore randevuları tekrar listeleyebiliriz*/
                .Include(x=>x.User).Select(x=>new RandevuViewModel()
                    { 
                        Doktor = x.User.Ad + " " + x.User.Soyad,
                        Hasta = x.HastaAdi + " "+ x.HastaSoyadi,
                        BaslangicTarihi = x.BaslangicTarihi,
                        BitisTarihi=x.BitisTarihi,
                        Aciklama=x.Aciklama,
                        UserId = x.UserId

            
                    });  
            return Json(model);
        }


        public JsonResult GetRandevu(string userId="" )
        {
            var model = _context.OzelRandevular.Where(x=>x.UserId==userId)        
                .Include(x => x.User).Select(x => new RandevuViewModel()
                {
                    Doktor = x.User.Ad + " " + x.User.Soyad,
                    Hasta = x.HastaAdi + " " + x.HastaSoyadi,
                    BaslangicTarihi = x.BaslangicTarihi,
                    BitisTarihi = x.BitisTarihi,
                    Aciklama = x.Aciklama,
                    UserId = x.UserId


                });
            return Json(model);
        }


    }
}
