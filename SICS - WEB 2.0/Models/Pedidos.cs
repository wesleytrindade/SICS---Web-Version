using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace SICS___WEB_2._0.Models
{
    public class Pedido
    {
        public int ID { get; set; }
        public int revisor { get; set; }
        public int status { get; set; }
        public int solicitante { get; set; }
        public int aprovacao { get; set; }
        public DateTime data{ get; set; }
        public DateTime baixa { get; set; }
        public DateTime confirmacao { get; set; }
        public DateTime revisao { get; set; }
        public String motivopedido { get; set; }
        public String motivorecusa { get; set; }
        public String localaula { get; set; }

    }
}