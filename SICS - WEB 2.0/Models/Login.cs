using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SICS___WEB_2._0.Models
{
    public class Login
    {
        [Key]
        public int ID { get; set; }
        public int Funcionario { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        public String Role { get; set; }
    }
}