using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace SICS___WEB_2._0.Models.ViewModels
{
    public class CadastroOrgaosViewModel
    {
        [Required(ErrorMessage = "Favor Preencher o campo do órgão regulador!")]
        public String OrgaoRegulador { get; set; }
    }
}