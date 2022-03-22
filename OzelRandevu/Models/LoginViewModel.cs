using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OzelRandevu.Models
{
    public class LoginViewModel
    {

        [Required(ErrorMessage = "Lütfen kullanıcı adını belirtiniz.")]
        [Display(Name = "Kullanıcı Adı")]
        public string KullaniciAdi { get; set; }

        [Required(ErrorMessage = "Lütfen şifrenizi belirtiniz.")]
        [Display(Name = "Şifreniz: ")]
        [DataType(DataType.Password)]
        public string Sifre { get; set; }

        [Display(Name = "Beni Hatırla")]
        public bool RememberMe { get; set; }
    }
}
