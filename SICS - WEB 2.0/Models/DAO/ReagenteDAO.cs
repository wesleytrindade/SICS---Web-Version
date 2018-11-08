using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using SICS___Acesso_ao_Banco_de_Dados;

namespace SICS___WEB_2._0.Models.DAO
{
    public class ReagenteDAO
    {
        SICS___Acesso_ao_Banco_de_Dados.Operations op;

        public ReagenteDAO()
        {
            op = new SICS___Acesso_ao_Banco_de_Dados.Operations();
        }

        public DataSet selectListReagente()
        {
            DataSet dx = new DataSet();
            dx = op.setSelectQuery("controle_tipo","*");
            return dx;

        }

        public DataSet selectListByGrupo(int id_grupo)
        {
            DataSet dx = new DataSet();
            dx = op.setSelectQuery("controle_tipo", "*","grupo_id = "+id_grupo);
            return dx;
        }

      

        public int createReagente(String [] attr)
        {
            String name = attr[0];
            String teor = attr[1];
            String formula = attr[2];
            String cas = attr[3];
            String controlado = attr[4];
            String orgaoregulador = attr[5];
            int grupoid = int.Parse(attr[6]);
            decimal estoquemin = Decimal.Parse(attr[7]);
            decimal estoquemax = Decimal.Parse(attr[8]);
            return op.setInsertAttr("controle_tipo", op.camposInsert[8], "'" + name + "','" + teor + "','" + formula + "','" + cas + "','" + controlado + "'," + orgaoregulador + "," + grupoid + "," + estoquemin + "," + estoquemax);


        }
    }
}