using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SICS___WEB_2._0.Models;

namespace SICS___WEB_2._0.Models.ViewModels
{
    public class ListarReagentesViewModel
    {
        public String query { get; set; }
        public List<Reagente> listaReagentes { get; set; }
    }
}