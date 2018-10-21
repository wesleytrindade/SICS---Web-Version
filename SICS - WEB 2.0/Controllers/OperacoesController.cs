using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SICS___WEB_2._0.Controllers
{
    public class OperacoesController : Controller
    {
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
    }
}