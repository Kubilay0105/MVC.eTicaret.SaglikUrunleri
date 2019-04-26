using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Saglik.PL.MVC.Models
{
    public class RegisterVM
    {
        [Required]
        [StringLength(30, ErrorMessage = "İsim {0} karakterden uzun olmamalıdır!")]
        public string ad { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "Soyisim {0} karakterden uzun olmamalıdır!")]
        public string soyad { get; set; }
        [Required]
        [MinLength(11), MaxLength(11)]
        public string tckno { get; set; }
        public string adres { get; set; }
        public string UserId { get; set; }
        [Required]
        [EmailAddress(ErrorMessage ="Geçerli bir mail adresi giriniz.")]
        public string Email { get; set; }
        public DateTime Tarih { get; set; } = DateTime.Now;

        public string UserName { get; set; }
        [Required(ErrorMessage = "Şifre gerekli")]
        [StringLength(255, ErrorMessage = "En az 5 karakter girmelisiniz.", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifre gerekli")]
        [StringLength(255, ErrorMessage = "En az 5 karakter girmelisiniz.", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

    }
}