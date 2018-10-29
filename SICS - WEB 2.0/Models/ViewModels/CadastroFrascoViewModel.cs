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
        [Display(Name = "Número do Frasco")]
        public int num_frasco { get; set; }
        [Display(Name = "QTDE em Estoque(g)")]
        public decimal frasco_estoque { get; set; }
        [Required]
        [Display(Name = "QTDE do Frasco(g)")]
        public decimal qtde_frasco { get; set; }
        [Display(Name = "Estoque Máximo(g)")]
        public decimal estoque_maximo { get; set; }
    }
}