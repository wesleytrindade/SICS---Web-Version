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

        public DataSet [] select()
        {
            DataSet [] dx = new DataSet[3];
            dx[0] = op.setSelectQuery("controle_tipo,controle_reagente", "controle_tipo.desc_tipo,controle_tipo.teor_tipo", "controle_tipo.id_tipo = controle_reagente.desc_reagente");
            return dx;
            
        }
    }
}