using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SICS___WEB_2._0.Models;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Data;

namespace SICS___WEB_2._0.Models.ViewModels
{
    public class CadastroPedidosViewModel
    {
        public List<SelectListItem> listGrupo { get; set; }
        [Required]
        [Display(Name ="Grupo de Substâncias")]
        public int selectlistGrupoID { get; set; }
        [Required]
        [Display(Name = "Reagente")]
        public List<SelectListItem> listReagentes { get; set; }
        public DataTable selectedReagentes { get; set; }
        [Required(ErrorMessage = "Preencha a Data/hora da aula!",AllowEmptyStrings = false)]
        [Display(Name = "Data/Hora da Aula")]
        [DataType(DataType.DateTime)]
        public DateTime dataHoraAula { get; set; }
        [Required]
        [Display(Name = "Sala de Aula")]
        public int selectedClass { get; set;}
        [Display(Name = "Observações e Materiais de aula")]
        [DataType(DataType.MultilineText)]
        public String observacoes { get; set; }
    }
}