using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SICS___Acesso_ao_Banco_de_Dados;
using System.Data;

namespace SICS___WEB_2._0.Models.DAO
{
    public class FabricanteDAO
    {
        SICS___Acesso_ao_Banco_de_Dados.Operations op;
        public FabricanteDAO()
        {
            op = new Operations();
        }
        public DataSet selectFabricantes()
        {
            return op.setSelectQuery("controle_fabricante", "*");
        }

        public DataSet selectFabricantes(int id)
        {
            return op.setSelectQuery("controle_fabricante", "*","id_fabricante = "+id);
        }

        public int createFabricante(String name,String phone,String address)
        {
            return op.setInsertAttr("controle_fabricante", op.camposInsert[1], "'" + name + "','" + phone + "'," + "'" + address + "'");
        }
    }
}