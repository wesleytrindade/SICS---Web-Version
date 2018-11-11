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

        public int createFrasco(ViewModels.CadastroFrascoViewModel vm)
        {
            op.setInsertAttr("controle_reagente", op.camposInsert[7], vm.selectedReagente.ToString() + ",'" + vm.validade.ToString() + "','" + vm.lote + "','" + vm.localizacao + "'," + vm.selectedFabricante, 3);
            op.setSelectQueryTransaction();
            return op.setInsertAttr("controle_estoque", op.camposInsert[0], "@valor," + vm.num_frasco + "," + vm.qtde_frasco);
            //desc_reagente,val_reagente,lote_reagente,localizacao_reagente,fabricante_reagente
            //op.camposInsert[0]
        }

        public DataSet selectFrasco()
        {
           return  op.setSelectQuery("controle_reagente", "*");
        }
    }
}