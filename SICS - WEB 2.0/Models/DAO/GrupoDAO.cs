﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using SICS___Acesso_ao_Banco_de_Dados;

namespace SICS___WEB_2._0.Models.DAO
{
    public class GrupoDAO
    {
        SICS___Acesso_ao_Banco_de_Dados.Operations op;

        public DataTable select()
        {
           op = new SICS___Acesso_ao_Banco_de_Dados.Operations();
           DataSet ds = op.setSelectQuery("controle_tipo_grupo", "*");
           DataTable ax = ds.Tables[0];

          
           return ax;
        }


        
    }
}