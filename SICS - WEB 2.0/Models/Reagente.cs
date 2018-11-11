using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SICS___WEB_2._0.Models
{
    public class Reagente
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "Nome")]
        public string Nome { get; set; }
        [Display(Name = "CAS")]
        public string CAS { get; set; }
        [Display(Name = "Teor")]
        public string Teor { get; set; }
        [Display(Name = "Fórmula")]
        public string formula { get; set; }
        [Display(Name = "Controlado")]
        public String controlado { get; set; }
        public decimal estoqueminimo { get; set; }
        public decimal estoquemaximo { get; set; }
        public int grupo_reagente { get; set; }
        public int orgao_controlador { get; set; }
        public float densidade { get; set; }
    }
}