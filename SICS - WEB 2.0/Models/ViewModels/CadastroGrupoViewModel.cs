using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SICS___WEB_2._0.Models.ViewModels
{
    public class CadastroGrupoViewModel
    {
        [Required(ErrorMessage = "Informar o nome do grupo!")]
        
        public String NomeGrupo { get; set; }
    }
}