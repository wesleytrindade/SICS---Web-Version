using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SICS___WEB_2._0.Models
{
    public class Estoque
    {
        [Required]
        [ForeignKeyAttribute("Reagente")]
        public int ID_Reagente_fk { get; set; }
        [Required]
        public int ID_Frasco { get; set; }
        [Required]
        public decimal frasco_qtde{ get; set; }

    }
}