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

        public OrgaoDAO()
        {
            op = new SICS___Acesso_ao_Banco_de_Dados.Operations();
        }

        public DataTable select()
        {
            
            DataSet ds = op.setSelectQuery("controle_orgao", "*");
            DataTable ax = ds.Tables[0];

            return ax;
        }

        public int create(String NomeOrgao)
        {
            return op.setInsertAttr("controle_orgao", "desc_orgao", NomeOrgao);

        }
    }
}