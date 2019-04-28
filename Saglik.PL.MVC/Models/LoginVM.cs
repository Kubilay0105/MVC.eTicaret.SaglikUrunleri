using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Saglik.PL.MVC.Models
{
    public class LoginVM
    {
        [Required]
        [Display(Name = "Kullanıcı Adı")]
        public string Username { get; set; }
        [Display(Name = "Şifre")]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string returnUrl { get; set; }
    }
}