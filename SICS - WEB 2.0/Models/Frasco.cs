using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SICS___WEB_2._0.Models
{
    public class Frasco
    {
        public int id_frasco { get; set; }
        public int id_reagente_fk{ get; set; }
        public DateTime validade { get; set; }
        public String lote { get; set; }
        public int fabricante { get; set; }
        public String localizacao { get; set; }

    }
}