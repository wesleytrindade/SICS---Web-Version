using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using SICS___Acesso_ao_Banco_de_Dados;


namespace SICS___WEB_2._0.Models.DAO
{
    public class LoginDAO
    {
        SICS___Acesso_ao_Banco_de_Dados.Operations op;
      

        public Login AutenticaUsuario(String Username,String Password)
        {
            verificaConexao();
            op = new Operations();
            DataSet ds = op.setSelectQuery("controle_login", "*", "login_login = '" + Username + "' and pwd_login = md5('" + Password + "')");
            Login lg = new Login();
            if (ds.Tables[0].Rows.Count > 0)
            {
                lg.ID = int.Parse(ds.Tables[0].Rows[0]["id_login"].ToString());
                lg.Funcionario = int.Parse(ds.Tables[0].Rows[0]["perm_login"].ToString());
                return lg;
            }

            else
            {
                lg = null;
                return lg;
            }
        }

        public Funcionario userInformation(int id)
        {
            verificaConexao();
            op = new Operations();
            DataSet dx = op.setSelectQuery("controle_funcionario", "*", "login_funcionario = " + id);
            Funcionario fun = new Funcionario();
            fun.Matricula = int.Parse(dx.Tables[0].Rows[0]["matricula_funcionario"].ToString());
            fun.Nome = dx.Tables[0].Rows[0]["nome_funcionario"].ToString();
            fun.Disciplina = dx.Tables[0].Rows[0]["disc_professor"].ToString();
            fun.Login = int.Parse(dx.Tables[0].Rows[0]["login_funcionario"].ToString());
            return fun;
        }

        private void verificaConexao()
        {
            Connection cn = new Connection();
            
            if(cn.statusconexao()!=1)
            {
                cn.conecta();
            }

            
        }
    }
}