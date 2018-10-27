using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace SICS___WEB_2._0.Models.DAO
{
    public class OrgaoDAO
    {
        SICS___Acesso_ao_Banco_de_Dados.Operations op;

        public DataTable select()
        {
            op = new SICS___Acesso_ao_Banco_de_Dados.Operations();
            DataSet ds = op.setSelectQuery("controle_orgao", "*");
            DataTable ax = ds.Tables[0];

            return ax;
        }
    }
}