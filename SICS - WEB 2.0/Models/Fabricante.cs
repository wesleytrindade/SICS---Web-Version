using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SICS___WEB_2._0.Models
{
    public class Fabricante
    {
        [Key]
        public int  ID { get; set; }
        public String Name { get; set; }
        public String Phone  { get; set; }
        public String Address { get; set; }
    }
}