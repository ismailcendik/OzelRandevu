using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OzelRandevu.Data.Entity;
using OzelRandevu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzelRandevu.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<Ozel_Randevu_Kullanicilar> _userManager;
        private SignInManager<Ozel_Randevu_Kullanicilar> _signInManager;
        private RoleManager<Ozel_Randevu_Roller> _roleManager;

        public AccountController(UserManager<Ozel_Randevu_Kullanicilar> userManager, SignInManager<Ozel_Randevu_Kullanicilar> signInManager,
          RoleManager<Ozel_Randevu_Roller> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }


        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task <IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);

            }

            var user = await _userManager.FindByNameAsync(model.KullaniciAdi);
            if (user==null)
            {
                ModelState.AddModelError(String.Empty, "Kullanici bulunamadi");
                return View(model);

            }


            var result = await _signInManager.PasswordSignInAsync(user, model.Sifre, model.RememberMe,false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError(String.Empty, "Oturum açmada bir hata oluştu.");

            return View(model);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)

            {
                return View(model);

            }

            Ozel_Randevu_Kullanicilar user = new Ozel_Randevu_Kullanicilar()
            {
                UserName = model.KullaniciAdi,

                Ad = model.Ad,

                Soyad = model.Soyad,

                Email = model.Email,

                Renk = model.Renk,

                Doktor=model.Doktor


            };

            IdentityResult result = _userManager.CreateAsync(user, model.Sifre).Result;

            if (result.Succeeded)
            {
                bool roleCheck = model.Doktor ? RolEkle("Doktor") : RolEkle("Sekreter");
                if (!roleCheck)
                {
                    return View("Error");
                }
                _userManager.AddToRoleAsync(user, model.Doktor ? "Doktor" : "Sekreter").Wait();
                return RedirectToAction("Index","Home");
            }

            return View("Error");
        }

        public IActionResult LogOut()
        {
            _signInManager.SignOutAsync().Wait();
            return RedirectToAction("Login");
        }

        public IActionResult Denied()
        {

            return View();
        }

        private bool RolEkle(string rolAdi)
        {
            if (!_roleManager.RoleExistsAsync(rolAdi).Result)
            {
                Ozel_Randevu_Roller rol = new Ozel_Randevu_Roller()
                {
                    Name=rolAdi
                };

                IdentityResult result = _roleManager.CreateAsync(rol).Result;
                return result.Succeeded;

            }
            return true;
        }
    }
}
