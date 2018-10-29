using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using SICS___Acesso_ao_Banco_de_Dados;

namespace SICS___WEB_2._0.Models.DAO
{
    public class FuncionarioDAO
    {
        Operations op;

        public DataSet selectWhere(int operation,String where)
        {
            op = new Operations();
            DataSet result = new DataSet();

            if(operation == 0)
            {
                result = op.setSelectQuery("controle_funcionario", "matricula_funcionario",where);
               
            }

            return result;
        }

        public int create(String [] values,int tra)
        {
            op = new Operations();
            String[] attrLogin = new String[3];
            String[] attrFunc = new String[3];

           for(int a=0; a<values.Length;a++)
            {
                values[a] = op.antiinject(values[a]);
                if(values[a] == "")
                {
                    return 3;
                }
            }

            attrLogin[0] = values[2]; //login
            attrLogin[1] = values[3]; //senha
            attrLogin[2] = values[4]; //permissao
            attrFunc[0] = values[0];//matricula
            attrFunc[1] = values[1];//nome
            attrFunc[2] = values[5]; //disciplina

            op.setInsertAttr("controle_login", op.camposInsert[2], "'" + attrLogin[0] + "',md5('" + attrLogin[1] + "'),'" + attrLogin[2] + "'", tra);
            op.setSelectQueryTransaction();
            return op.setInsertAttr("controle_funcionario", op.camposInsert[10], attrFunc[0] + ",'" + attrFunc[1] + "',@valor," + null + ",'" + attrFunc[2] + "'");





        }
    }
}