using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using SICS___Acesso_ao_Banco_de_Dados;

namespace SICS___WEB_2._0.Models.DAO
{
    public class PedidosDAO
    {
        Operations op;

        public PedidosDAO()
        {
            op = new Operations();
        }

        public DataSet selectList()
        {
            DataSet db = new DataSet();
            return op.setSelectQuery("controle_tipo_grupo,controle_tipo", "*");
            

        }

        public DataSet selectList(int id)
        {
            DataSet dx = new DataSet();
            return op.setSelectQuery("controle_tipo_grupo", "*","id_grupo = "+id);
        }

        
        
    }
}