using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SICS___Acesso_ao_Banco_de_Dados;

namespace SICS___WEB_2._0.Models.DAO
{
    public class Connection
    {
        SICS___Acesso_ao_Banco_de_Dados.Connection conexao;

        public int conecta()
        {
            String[] attr = { "127.0.0.1", "3306", "controle", "root", "1234" };
            conexao = new SICS___Acesso_ao_Banco_de_Dados.Connection();
            conexao.setConnection(attr);
            return conexao.openConnection();

        }

        public int statusconexao()
        {
           if(SICS___Acesso_ao_Banco_de_Dados.Connection.getConnectionState() == System.Data.ConnectionState.Open)
            {
                return 1;
            }

           else
            {
                return 0;
            }
        }
        
        
    }
}