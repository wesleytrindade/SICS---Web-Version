using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;


namespace SICS___Acesso_ao_Banco_de_Dados
{
    public class Operations
    {
        private static String[] transactions = null;
        private static int comnumber = 0;
        private int key = 0;
        public static MySqlTransaction tt = null;
        public static MySqlCommand cmx = null;
        public readonly String[] tabelas = { "controle_estoque", "controle_fabricante", "controle_login", "controle_orgao", "controle_pedido_produtos", "controle_pedidos", "controle_professor", "controle_reagente", "controle_tipo", "controle_tipo_grupo", "controle_funcionario" };

        /*
         LISTA DE TABELAS BANCO SQL 

         0 = controle_estoque
         1 = controle_fabricante
         2 = controle_login
         3 = controle_orgao
         4 = controle_pedidos_produtos
         5 = controle_pedidos
         6 = controle_professor
         7 = controle_reagente
         8 = controle_tipo
         9 = controle_tipo_grupo
         10 = controle_funcionario


        */

        public readonly String[] camposInsert = { "id_reagente_fk,id_frasco,frasco_estoque,medida_estoque", "desc_fabricante,telefone_fabricante,endereco_fabricante", "login_login,pwd_login,perm_login,status_conta", "desc_orgao", "id_reagente,qtde_pedida,id_pedido", "id_funcionario,data_pedido,motivo_pedido,data_aula,local_aula,status_pedido", "matricula_professor,nome_professor,disc_professor,login_professor", "desc_reagente,val_reagente,lote_reagente,localizacao_reagente,fabricante_reagente", "desc_tipo,teor_tipo,formula_tipo,cas_tipo,controlado_tipo,orgaocontrolador_tipo,grupo_id,minimo_estoque,maximo_estoque", "desc_grupo", "matricula_funcionario,nome_funcionario,login_funcionario,foto_funcionario,disc_professor" };

        private DataSet selectDatabase(String[] attr, int op)
        {
            DataSet dts = new DataSet();
            String query;
            if (op == 0)
            {
                query = "Select " + attr[0] + " from " + attr[1] + ";";

            }

            else if (op == -15)
            {

                query = "Select " + attr[0] + " from " + attr[1] + " where " + attr[2] + " like " + "'" + attr[3] + "%';";
            }
            else
            {
                query = "Select " + attr[0] + " from " + attr[1] + " where " + attr[2] + ";";

            }

            try
            {

                MySqlDataAdapter dtr = new MySqlDataAdapter(query, Connection.con);
                dtr.Fill(dts);
            }

            catch (MySqlException st)
            {
               
            }

            return dts;
        }



        private int insertDatabase(String[] attr)
        {
            try
            {
                String comm = "Insert into " + attr[0] + "(" + attr[1] + ") values (" + attr[2] + ");";
                MySqlCommand cmd = new MySqlCommand(comm, Connection.con);
                cmd.ExecuteNonQuery();
            }

            catch (MySqlException vi)
            {
                
                return 0;
            }

            return 1;
        }

        private int updateDatabase(String[] attr)
        {
            try
            {
                String ca = "Update " + attr[0] + " set " + attr[1] + " where " + attr[2] + ";";
                MySqlCommand cmd = new MySqlCommand(ca, Connection.con);
                cmd.ExecuteNonQuery();
                return 1;
            }

            catch (MySqlException vi)
            {
                
                return 0;
            }

        }

        public int setInsertAttr(String table, String fields, String values)
        {
            String[] atb = new String[3];
            atb[0] = table;
            atb[1] = fields;
            atb[2] = values;
            return insertDatabase(atb);
        }

        public int setInsertAttr(String table, String fields, String values, int tra)
        {
            xe: if (transactions == null && tra > 0)
            {
                transactions = new String[tra];
                goto xe;
            }

            else if (tra <= 0)
            {
                return 3; //numero de transações inválido!
            }

            else
            {
                String comando = "Insert into " + table + "(" + fields + ")" + "values (" + values + ");";
                transactions[comnumber] = comando;

            }

            if (comnumber < transactions.Length - 1)
            {
                comnumber++;
            }

            else
            {
                return commitTransacaoSQL(transactions);
            }

            return 0;//adicionado porem falta elementos para concluir a transação
        }

        public DataSet setSelectQuery(String table, String fields)
        {
            String[] atb = new String[2];
            atb[1] = table;
            atb[0] = fields;
            return selectDatabase(atb, 0);
        }

        public DataSet setSelectQuery(String table, String fields, String condition)
        {
            String[] atb = new String[3];
            atb[1] = table;
            atb[0] = fields;
            atb[2] = condition;
            return selectDatabase(atb, 1);
        }

        public DataSet setSelectQuery(String table, String fields, String condition, String like)
        {
            String[] atb = new String[4];
            atb[1] = table;
            atb[0] = fields;
            atb[2] = condition;
            atb[3] = like;
            return selectDatabase(atb, -15);
        }

        public void setSelectQueryTransaction()
        {

            transactions[comnumber] = "select last_insert_id();";
            comnumber++;
        }

        public void setSelectQueryTransaction(String query)
        {
            transactions[comnumber] = query;
            comnumber++;
        }

        public List<String> getSelectData(DataSet ds)
        {
            String acumulador = "";
            List<String> linha = new List<string>();
            int a = ds.Tables[0].Columns.Count;
            int b = ds.Tables[0].Rows.Count;

            for (int x = 0; x < b; x++)
            {
                for (int y = 0; y < a; y++)
                {
                    acumulador += "|" + ds.Tables[0].Rows[x][y].ToString() + "|";
                }

                linha.Add(acumulador);
                acumulador = "";
            }



            return linha;
        }

        public int setUpdateAttr(String table, String set, String where)
        {
            String[] attr = new String[3];
            attr[0] = table;
            attr[1] = set;
            attr[2] = where;
            return updateDatabase(attr);
        }



        //FUNÇÃO ANTI-SQL INJECT: FONTE http://fabiocabral.gabx.com.br/2013/03/c-funcao-contra-sql-injection-injecao.html

        public string antiinject(string str)
        {
            //Função simples para evitar ataques de injeção SQL
            if (str == string.Empty || str == "")
                return str;

            string sValue = str;

            //Valores a serem substituidos
            sValue = sValue.Replace("'", "''");
            sValue = sValue.Replace("--", " ");
            sValue = sValue.Replace("/*", " ");
            sValue = sValue.Replace("*/", " ");
            sValue = sValue.Replace(" or ", "");
            sValue = sValue.Replace(" and ", "");
            sValue = sValue.Replace("update", "");
            sValue = sValue.Replace("-shutdown", "");
            sValue = sValue.Replace("--", "");
            sValue = sValue.Replace("'or'1'='1'", "");
            sValue = sValue.Replace("insert", "");
            sValue = sValue.Replace("drop", "");
            sValue = sValue.Replace("delete", "");
            sValue = sValue.Replace("xp_", "");
            sValue = sValue.Replace("sp_", "");
            sValue = sValue.Replace("select", "");
            sValue = sValue.Replace("1 union select", "");

            //Retorna o valor com as devidas alterações
            return sValue;

        }

        public int maximo(String id_reagente)
        {
            MySqlCommand cmd = new MySqlCommand("Select max(id_frasco) from controle_estoque,controle_reagente where controle_estoque.id_reagente_fk = controle_reagente.id_reagente and controle_reagente.desc_reagente =  " + id_reagente + ";", Connection.con);
            MySqlDataReader dtr = cmd.ExecuteReader();
            List<String> vs = new List<string>();

            while (dtr.Read())

            {
                vs.Add(dtr[0].ToString());
            }



            dtr.Close();

            if (vs[0] != "")
            {
                int a = int.Parse(vs[0]);
                return a + 1;
            }

            else
            {
                return 1;
            }
        }

        private int commitTransacaoSQL(String[] commands)
        {
            MySqlTransaction tr;
            tr = Connection.con.BeginTransaction();
            MySqlCommand cmd = Connection.con.CreateCommand();
            cmd.Connection = Connection.con;
            cmd.Transaction = tr;

            try
            {
                for (int a = 0; a < commands.Length; a++)
                {
                    cmd.CommandText = commands[a];
                    if (a == 1)
                    {
                        MySqlDataReader dx = cmd.ExecuteReader();
                        while (dx.Read())
                        {
                            key = int.Parse(dx.GetString(0));
                        }
                        dx.Close();

                    }



                    else
                    {
                        String com = commands[a];
                        if (com.Contains("@valor"))
                        {
                            if (cmd.Parameters.Count == 0)
                                cmd.Parameters.AddWithValue("@valor", key);
                        }

                        cmd.ExecuteNonQuery();
                    }
                }

                tr.Commit();
                transactions = null;
                comnumber = 0;
                return 1;// transacao efetuada com sucesso
            }

            catch (MySqlException cx)
            {
                tr.Rollback();//ocorreu um erro
                transactions = null;
                comnumber = 0;
                return 0;
            }

        }

        public DataTable gridTransacoes(String command, int op)
        {
            DataTable dr = null;

            if (tt == null)
            {
                tt = Connection.con.BeginTransaction();
                cmx = Connection.con.CreateCommand();
                cmx.Transaction = tt;

            }

            try
            {
                switch (op)
                {
                    case 1:
                        cmx.CommandText = command; //insert e delete
                        cmx.ExecuteNonQuery();
                        break;

                    case 2:
                        cmx.CommandText = command;
                        DataSet di = new DataSet();
                        MySqlDataAdapter da = new MySqlDataAdapter(cmx.ToString(), Connection.con);
                        da.Fill(di);
                        dr = di.Tables[0];
                        break;

                    case 3:
                        tt.Commit();
                        break;
                }

                return dr;
            }

            catch (MySqlException x)
            {
                tt.Rollback();
                return dr;
            }

        }
    }
}







