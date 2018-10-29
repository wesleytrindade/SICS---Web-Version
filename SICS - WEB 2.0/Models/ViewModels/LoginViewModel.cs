using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SICS___WEB_2._0.Models.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "Login")]
        [Required(ErrorMessage = "Preencha o campo de login!", AllowEmptyStrings = false)]
        public String Username { get; set; }
        [Display(Name = "Senha")]
        [Required(ErrorMessage = "Preencha o campo da senha!", AllowEmptyStrings = false)]
        public String Password { get; set; }
        [Display(Name = "Lembrar-me")]
        public bool Lembrar { get; set; }
        public bool invalidCredentials { get; set; }
        
    }
}