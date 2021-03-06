﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SICS___WEB_2._0.Models;

namespace SICS___WEB_2._0.Models.ViewModels
{

    public class CadastroReagenteViewModel
    {
        [Required(ErrorMessage = "Informe o Nome!", AllowEmptyStrings = false)]
        [MaxLength(100,ErrorMessage = "O nome deve ter até 100 caracteres!")]
        [MinLength(5, ErrorMessage = "O nome deve no mínimo 5 caracteres!")]
        [Display(Name = "Nome do Reagente")]
        public String Nome { get; set; }
        [Required(ErrorMessage = "Informe o CAS!", AllowEmptyStrings = false)]
        [Display(Name = "CAS")]
        public String CAS { get; set; }
        [Required(ErrorMessage = "Informe o Teor!", AllowEmptyStrings = false)]
        [Display(Name = "Teor")]
        public String Teor { get; set; }
        [Required(ErrorMessage = "Informe a Fórmula!", AllowEmptyStrings = false)]
        [Display(Name = "Fórmula")]
        public String Formula { get; set; }
        [Display(Name = "Grupo de Reagentes")]
        [Required(ErrorMessage = "Selecione um grupo!")]
        public String GrupoSelecionado { get; set; }
        public List<SelectListItem> Grupo { get; set; }
        [Display(Name = "Estoque Mínimo (g)")]
        [Required(ErrorMessage = "Campo obrigatório",AllowEmptyStrings = false)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "O valor do estoque mínimo deve ser númerico!")]
        [Range(100,999999999,ErrorMessage = "Número muito pequeno ou número inválido")]
        public decimal EstoqueMin { get; set; }
        [Display(Name = "Estoque Máximo(g)")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "O valor do estoque mínimo deve ser númerico!")]
        [Required(ErrorMessage = "Campo obrigatório",AllowEmptyStrings = false)]
        public decimal EstoqueMax { get; set; }
        [Display(Name = "Reagente Controlado?")]
        public bool Controlado { get; set; }
        [Display(Name = "Orgão Regulador")]
        public int OrgaoSelecionado { get; set; }
        public List <SelectListItem> listOrgao { get; set; }

    }
}