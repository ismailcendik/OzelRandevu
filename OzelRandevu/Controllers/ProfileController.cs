using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OzelRandevu.Data.Entity;
using OzelRandevu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzelRandevu.Controllers
{
    public class ProfileController : Controller
    {

        private UserManager<Ozel_Randevu_Kullanicilar> _userManager;

        public ProfileController(UserManager<Ozel_Randevu_Kullanicilar> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            Ozel_Randevu_Kullanicilar kullanicilar = _userManager.Users.SingleOrDefault(x => x.UserName == HttpContext.User.Identity.Name);
            if (kullanicilar==null)
            {
                return View("Error");
            }

            if (_userManager.IsInRoleAsync(kullanicilar,"Sekreter").Result)
            {
                var doktor = _userManager.Users.Where(x => x.Doktor);
                SekreterViewModel model = new SekreterViewModel()
                {

                    Kullanicilar = kullanicilar,
                    Doktor = doktor,
                    DoktorSelectList = doktor.Select(n => new SelectListItem {

                        Value = n.Id,
                        Text = $"Dt. {n.Ad} {n.Soyad}"

                    }).ToList()

                };
                return View("Sekreter",model);

            }
            else
            {
                return View("Doktor");

            }
        }

        public IActionResult Sekreter()
        {
            return View();
        }


        public IActionResult Doktor()
        {
            return View();
        }


    }
}
