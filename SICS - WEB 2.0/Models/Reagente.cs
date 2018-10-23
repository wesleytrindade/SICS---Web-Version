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
        public string Nome { get; set; }
        public string CAS { get; set; }
        public string Teor { get; set; }
        public string formula { get; set; }
        public bool controlado { get; set; }
        public int grupo_reagente { get; set; }
        public int orgao_controlador { get; set; }
        public float densidade { get; set; }
    }
}