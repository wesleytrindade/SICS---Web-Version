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
        Models.DAO.OrgaoDAO oDAO;
        Models.DAO.Connection con;

        [Authorize]
        public ActionResult Reagentes()
        {
            gDAO = new Models.DAO.GrupoDAO();
            oDAO = new Models.DAO.OrgaoDAO();
            
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

            DataTable dp = oDAO.select();
            List<Orgao> la = new List<Orgao>();
            foreach (DataRow item in dp.Rows)
            {
                Orgao gr = new Orgao();
                gr.ID = Convert.ToInt32(item["id_orgao"]);
                gr.Nome = item["desc_orgao"].ToString();
                la.Add(gr);

            }
            vmodel.Grupo = new SelectList(ls);
            vmodel._itemOrgao = new List<Orgao>();
            vmodel._itemOrgao = la;
            
           
        
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
            List<Roles> rl = new List<Roles>();
            rl.Add(new Roles() { ID = 1, Descricao = "Administrador" });
            rl.Add(new Roles() { ID = 2, Descricao = "Coordenador de Laboratório" });
            rl.Add(new Roles() { ID = 3, Descricao = "Auxiliar de Docente" });
            rl.Add(new Roles() { ID = 4, Descricao = "Professor" });

            var vumodel = new Models.ViewModels.CadastroUsuariosViewModel();
            List<SelectListItem> li = new List<SelectListItem>();
           

            foreach(Roles it in rl)
            {
                if (it.ID == 1)
                {
                    li.Add(new SelectListItem() { Value = it.ID.ToString(), Text = it.Descricao, Selected = true });
                }

                else
                {
                    li.Add(new SelectListItem() { Value = it.ID.ToString(), Text = it.Descricao, Selected = false });
                }
            }

            SelectList lx = new SelectList(li, "Value", "Text");
            vumodel.listRoles = lx;





            return View(vumodel);
        }

        [Authorize]
        public ActionResult Solicitacoes()
        {
            return View();
        }
    }
}