using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SICS___WEB_2._0.Models.ViewModels
{
    public class AtualizaUsuarioViewModel
    {
        [Display(Name = "Matrícula Usuario")]
        public int id_usuario{ get; set; }
        [Required(ErrorMessage = "O campo nome não pode ser deixado em branco",AllowEmptyStrings = false)]
        [Display(Name = "Nome Completo")]
        public string nome { get; set; }
        
    }
}