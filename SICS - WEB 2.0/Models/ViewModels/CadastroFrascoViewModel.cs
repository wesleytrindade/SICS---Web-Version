using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace SICS___WEB_2._0.Models.ViewModels
{
    public class CadastroFrascoViewModel
    {
        public SelectList listaGrupo { get; set; }
        [Required]
        [Display(Name = "Lista de Reagentes")]
        public int selectedReagente { get; set; }
        public List<SelectListItem> listaReagente { get; set; }
        [Display(Name = "Lista de Fabricantes")]
        public int selectedFabricante { get; set; }
        public List<SelectListItem> listaFabricantes { get; set; }
        [Display(Name = "Número do Frasco")]
        public int num_frasco { get; set; }
        [Display(Name = "QTDE em Estoque(g)")]
        public decimal frasco_estoque { get; set; }
        [Required]
        [Display(Name = "QTDE do Frasco(g)")]
        [Range(100.00,99999.00,ErrorMessage = "O valor mínimo de cadastro é de 100g e o máximo é de 99999.00g!")]
        public decimal qtde_frasco { get; set; }
        [Display(Name = "Estoque Máximo(g)")]
        public decimal estoque_maximo { get; set; }
        [Required]
        [Display(Name = "Validade Reagente")]
        [DataType(DataType.DateTime,ErrorMessage = "Data Inválida!")]
        public DateTime validade { get; set; }
        [Required(ErrorMessage = "Preencha o campo!",AllowEmptyStrings = false)]
        [MinLength(5,ErrorMessage = "O campo deve rer no mínimo 5 caracteres")]
        [MaxLength(80,ErrorMessage = "O campo deve ter no máximo 80 caracteres")]
        [Display(Name = "Localização Reagente")]
        public String localizacao { get; set; }
        [Required(ErrorMessage ="Preencha o campo!",AllowEmptyStrings = false)]
        [MinLength(5, ErrorMessage = "O campo deve rer no mínimo 5 caracteres")]
        [Display(Name = "Lote Reagente")]
        public String lote { get; set; }


    }
}