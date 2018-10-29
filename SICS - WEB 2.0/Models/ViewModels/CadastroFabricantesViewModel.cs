using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SICS___WEB_2._0.Models;
using System.ComponentModel.DataAnnotations;

namespace SICS___WEB_2._0.Models.ViewModels
{
    public class CadastroFabricantesViewModel
    {
        [Display(Name = "Nome do Fabricante")]
        [Required(ErrorMessage = "Favor informar o nome do fabricante",AllowEmptyStrings = false)]
        public String NomeFabricante{ get; set; }
        [Display(Name = "Endereço Empresarial")]
        public String EnderecoFabricante { get; set; }
        [Display(Name = "Telefone")]
        [DataType(DataType.PhoneNumber)]
        public String TelefoneFabricante { get; set; }
    }
}