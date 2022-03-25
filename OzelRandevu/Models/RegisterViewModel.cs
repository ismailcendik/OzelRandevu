using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OzelRandevu.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="Lütfen kullanıcı adını belirtiniz.")]
        [Display(Name ="Kullanıcı Adı")]
        public string KullaniciAdi  { get; set; }

        [Required(ErrorMessage = "Lütfen adınızı belirtiniz.")]
        [Display(Name = "Adınız:")]
        public string Ad { get; set; }

        [Required(ErrorMessage = "Lütfen soyadınızı belirtiniz.")]
        [Display(Name = "Soyadınız:")]
        public string Soyad { get; set; }

        
        [Required(ErrorMessage = "Lütfen şifrenizi belirtiniz.")]
        [Display(Name = "Şifreniz: ")]
        [DataType(DataType.Password)]
        public string Sifre { get; set; }

        [Required(ErrorMessage = "Lütfen e-posta adresinizi belirtiniz.")]
        [Display(Name = "E-posta:")]
        [EmailAddress(ErrorMessage ="Lütfen e-posta formatınızı kontrol ediniz.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        //[Required(ErrorMessage = "Lütfen randevu rengini belirtiniz.")]
        [Display(Name = "Randevu Rengi:")]
        public string Renk { get; set; }

        [Display(Name = "Doktorum")]
        public bool Doktor { get; set; }
    }
}
