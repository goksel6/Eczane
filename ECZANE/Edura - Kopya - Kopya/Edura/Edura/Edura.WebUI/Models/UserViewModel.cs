using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Edura.WebUI.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "E-mail alanı boş bırakılamaz.")]
        [EmailAddress(ErrorMessage ="Geçerli bir e-mail adresi giriniz.")]
        public string Email { get; set; }

 
   
  
        [Required(ErrorMessage = "Parola alanı boş bırakılamaz ve büyük/küçük harf, sayı ve işaretlerden oluşmalıdır.")]
        [UIHint("password")]
        public string Password { get; set; }
    }
}
