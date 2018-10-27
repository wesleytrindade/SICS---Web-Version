using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace SICS___WEB_2._0.Models
{
    public class Roles
    {
        [Key]
        public int ID { get; set; }
        public String Descricao { get; set; }
    }
}