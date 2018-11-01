using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using SICS___Acesso_ao_Banco_de_Dados;

namespace SICS___WEB_2._0.Models.DAO
{
    public class FrascosDAO
    {
        SICS___Acesso_ao_Banco_de_Dados.Operations op;

        public FrascosDAO()
        {
            op = new SICS___Acesso_ao_Banco_de_Dados.Operations();
        }

       public int carregaNumFrascos(String id_reagente)
        {
            return op.maximo(id_reagente);
        }

        public String createFrasco(ViewModels.CadastroFrascoViewModel vm)
        {
           
        }
    }
}