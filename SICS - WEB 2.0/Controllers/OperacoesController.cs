using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SICS___WEB_2._0.Models;
using System.Data;

namespace SICS___WEB_2._0.Controllers
{
    public class OperacoesController : Controller
    {
        Models.DAO.ReagenteDAO rDAO;

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
                rg.grupo_reagente = Convert.ToInt32(dr["grupo_id"]);
                rg.orgao_controlador = Convert.ToInt32(dr["orgaocontrolador_tipo"]);
                if (dr["controlado_tipo"].ToString() == "Y")
                    rg.controlado = true;
                else
                    rg.controlado = false;
                if (dr["densidade_tipo"].ToString() != "")
                {
                    rg.densidade = float.Parse(dr["densidade_tipo"].ToString());
                }


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

        public ActionResult DetalhesModal()
        {
            return View();
        }
    }
}