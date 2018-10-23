using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SICS___WEB_2._0.Models;

namespace SICS___WEB_2._0.Controllers
{
    public class CadastroController : Controller
    {
        Models.DAO.GrupoDAO gDAO;
        Models.DAO.Connection con;

        [Authorize]
        public ActionResult Reagentes()
        {
            gDAO = new Models.DAO.GrupoDAO();
            con = new Models.DAO.Connection();

            if(con.statusconexao() != 1)
            {
                con.conecta();
            }
            var vmodel = new Models.ViewModels.CadastroReagenteViewModel();
            DataTable dt = gDAO.select();
            List<SelectListItem> ls = new List<SelectListItem>();
            foreach (DataRow item in dt.Rows)
            {
                SelectListItem sl = new SelectListItem();
                sl.Text = item["desc_grupo"].ToString();
                sl.Value = item["id_grupo"].ToString();
                ls.Add(sl);

            }

            vmodel.Grupo = new SelectList(ls);
           
        
            return View();
        }

        [Authorize]
        public ActionResult Frascos()
        {
            return View();
        }

        [Authorize]
        public ActionResult Fabricantes()
        {
            return View();
        }

        [Authorize]
        public ActionResult OrgaoControlador()
        {
            return View();
        }

        [Authorize]
        public ActionResult Usuario()
        {
            return View();
        }

        [Authorize]
        public ActionResult Solicitacoes()
        {
            return View();
        }
    }
}