using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;

namespace SICS___Acesso_ao_Banco_de_Dados
{
    public class Connection
    {
        public static MySqlConnection con;

        public int openConnection()
        {
            try
            {
                con.Open();
            }

            catch (MySqlException d)
            {
                return 0;
            }

            if (con.State == System.Data.ConnectionState.Open)
            {
                return 1;
            }

            else
            {
                return 0;
            }
        }

        public static int closeConnection()
        {
            con.Close();
            if (con.State == System.Data.ConnectionState.Closed)
            {
                return 1;
            }

            else
            {
                return 0;
            }
        }

        public void setConnection(String[] attr)
        {
            con = new MySqlConnection("Server = " + attr[0] + ";Port = " + attr[1] + ";Database = " + attr[2] + "; Uid = " + attr[3] + "; Pwd = " + attr[4] + ";");
        }

        public static System.Data.ConnectionState getConnectionState()
        {
            if (con != null)
            {
                return con.State;
            }

            else
            {
                System.Data.ConnectionState cmd = new System.Data.ConnectionState();
                return cmd;
            }
        }


    }
}
