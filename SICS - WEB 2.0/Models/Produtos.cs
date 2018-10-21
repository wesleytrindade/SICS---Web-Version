using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SICS___WEB_2._0.Models
{
    public class Produtos
    {
        public int ID_Reagente { get; set; }
        public int ID_Pedido { get; set; }
        public float Qtde_Pedida { get; set; }
        public float Qtde_Utilizada { get; set; }
        public float SaldoEstoque { get; set; }
    }
}