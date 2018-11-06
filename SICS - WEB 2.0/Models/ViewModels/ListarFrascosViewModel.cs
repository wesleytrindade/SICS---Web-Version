using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SICS___WEB_2._0.Models;

namespace SICS___WEB_2._0.Models.ViewModels
{
    public class ListarFrascosViewModel
    {
        public String query { get; set; }
        public List<Frasco> listaFrascos { get; set; }
    }
}