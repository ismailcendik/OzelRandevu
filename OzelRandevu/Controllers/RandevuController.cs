using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OzelRandevu.Data;
using OzelRandevu.Data.Entity;
using OzelRandevu.Models;
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

        [HttpPost]

        public JsonResult RandevuEkleGuncelle(RandevuEkleGuncelleModel model)
        {
            //Basit validasyon   31.03 İsmail Çendik

            if (model.Id==0)
            {
                Ozel_Randevu entity = new Ozel_Randevu()
                {
                    OlusturmaTarihi = DateTime.Now,
                    BaslangicTarihi = model.BaslangicTarihi,
                    BitisTarihi = model.BitisTarihi,
                    HastaAdi = model.HastaAdi,
                    HastaSoyadi = model.HastaSoyadi,
                    Aciklama = model.Aciklama,
                    UserId = model.UserId
                };

                _context.Add(entity);
                _context.SaveChanges();
            }
            else
            {
                var entity = _context.OzelRandevular.SingleOrDefault(x => x.Id == model.Id);
                if (entity==null)
                {
                    return Json("Güncellenecek veri bulunamadı");
                }
                entity.GuncellemeTarihi = DateTime.Now;
                entity.HastaAdi = model.HastaAdi;
                entity.HastaSoyadi = model.HastaSoyadi;
                entity.Aciklama = model.Aciklama;
                entity.BaslangicTarihi = model.BaslangicTarihi;
                entity.BitisTarihi = model.BitisTarihi;
                entity.UserId = model.UserId;

                _context.Update(entity);
                _context.SaveChanges();
            }
            return Json("200");

        }

        public JsonResult RandevuSil(int id = 0)
        {
            var entity = _context.OzelRandevular.SingleOrDefault(x => x.Id == id);
            if (entity==null)
            {
                return Json("Kayıt bulunamadı");
            }
            _context.Remove(entity);
            _context.SaveChanges();
            return Json("200");
        }

    }
    
}
