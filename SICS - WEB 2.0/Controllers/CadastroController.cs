using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SICS___WEB_2._0.Controllers
{
    public class CadastroController : Controller
    {
        [Authorize]
        public ActionResult Reagentes()
        {
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