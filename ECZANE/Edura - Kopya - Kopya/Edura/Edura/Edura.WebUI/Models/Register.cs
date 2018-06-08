using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Edura.WebUI.Models
{
    public class Register
    {
        [Required(ErrorMessage = "Ad alanı boş bırakılamaz.")]      
        public string Name { get; set; }

        [Required(ErrorMessage = "Kullanıcı adı alanı boş bırakılamaz.")]     
        public string Username { get; set; }
     

        [Required(ErrorMessage = "Soyadı alanı boş bırakılamaz.")]
        public string Surname { get; set; }



        [Required(ErrorMessage = "E-posta adresiniz beklenilen formatta değil.")]      
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Parola alanı boş bırakılamaz ve büyük/küçük harf, sayı ve işaretlerden oluşmalıdır.")]
        [UIHint("password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Parola tekrar alanı boş bırakılamaz ve büyük/küçük harf, sayı ve işaretlerden oluşmalıdır.")]  
        [UIHint("password")]
        [Compare("Password", ErrorMessage = "Girdiğiniz parolalar uyuşmuyor.")]
        public string RePassword { get; set; }
    }
}
