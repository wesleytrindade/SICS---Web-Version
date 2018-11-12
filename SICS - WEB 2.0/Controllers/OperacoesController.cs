using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SICS___WEB_2._0.Models;
using SICS___WEB_2._0.Models.ViewModels;
using System.Data;

namespace SICS___WEB_2._0.Controllers
{
    public class OperacoesController : Controller
    {
        Models.DAO.ReagenteDAO rDAO;
        Models.DAO.OrgaoDAO oDAO;

        [Authorize]
        public ActionResult Baixa()
        {
            return View();
        }

        [Authorize]
        public ActionResult ConfirmarBaixa()
        {
            return View();
        }

        [Authorize]
        public ActionResult ListarReagentes()
        {
            if (Session.Count <= 0)
            {
                return RedirectToAction("Logout", "Auth");
            }

            var vm = new Models.ViewModels.ListarReagentesViewModel();
           
            rDAO = new Models.DAO.ReagenteDAO();
            DataTable ds = rDAO.selectListReagente().Tables[0];
            List<Reagente> list = new List<Reagente>();
            
            foreach(DataRow dr in ds.Rows)
            {
                Reagente rg = new Reagente();
                rg.ID = Convert.ToInt32(dr["id_tipo"]);
                rg.Nome = dr["desc_tipo"].ToString();
                rg.CAS = dr["cas_tipo"].ToString();
                rg.formula = dr["formula_tipo"].ToString();
                rg.Teor = dr["teor_tipo"].ToString();
                //rg.grupo_reagente = Convert.ToInt32(dr["grupo_id"]);
                //rg.orgao_controlador = Convert.ToInt32(dr["orgaocontrolador_tipo"]);
                //rg.controlado = dr["controlado_tipo"].ToString();
                //if (dr["densidade_tipo"].ToString() != "")
                //{
                //    rg.densidade = float.Parse(dr["densidade_tipo"].ToString());
                //}


                list.Add(rg);

            }

            vm.listaReagentes = list;

            return View(vm);
        }
        [Authorize]
        public ActionResult ListarSolicitacoes()
        {
            return View();
        }

        [Authorize]
        public ActionResult ConfirmarSolicitacao()
        {
            return View();
        }

        [Authorize]
        public ActionResult NegarSolicitacao()
        {
            return View();
        }

        [Authorize]

        public ActionResult DetalhesModal(int? id)
        {
            Models.Reagente rm = new Reagente();
            rDAO = new Models.DAO.ReagenteDAO();
            

            if (id.HasValue)
            {
                DataTable du = rDAO.selectReagentebyId(id.Value).Tables[0];

                if(du.Rows.Count>0)
                {
                    
                    rm.ID = Convert.ToInt32(du.Rows[0]["id_tipo"]);
                    rm.Nome = du.Rows[0]["desc_tipo"].ToString();
                    rm.Teor = du.Rows[0]["teor_tipo"].ToString();
                    rm.CAS = du.Rows[0]["cas_tipo"].ToString();
                    rm.formula = du.Rows[0]["formula_tipo"].ToString();
                    rm.controlado = du.Rows[0]["controlado_tipo"].ToString();
                    rm.estoqueminimo= Convert.ToDecimal(du.Rows[0]["minimo_estoque"]);
                    rm.estoquemaximo = Convert.ToDecimal(du.Rows[0]["maximo_estoque"]);
                    ViewBag.Grupo = du.Rows[0]["desc_grupo"];

                    return View(rm);
                }
            }
            
            return View();
        }

        [Authorize]

        public ActionResult AtualizaUsuario()
        {
            return View();
        }

        [Authorize]

        public ActionResult AtualizaUsuarioModal(int? id)
        {
            return View();
        }

        [Authorize]
        [HttpPost]

        public ActionResult AtualizaUsuarioModal(AtualizaUsuarioViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            else
            {
                return View(vm);
            }
        }
    }
}