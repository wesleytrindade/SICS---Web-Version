using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SICS___WEB_2._0.Models;
using SICS___WEB_2._0.Models.ViewModels;


namespace SICS___WEB_2._0.Controllers
{
    public class CadastroController : Controller
    {
        Models.DAO.GrupoDAO gDAO;
        Models.DAO.OrgaoDAO oDAO;
        Models.DAO.ReagenteDAO rDAO;
        Models.DAO.FrascosDAO frDAO;
        Models.DAO.FuncionarioDAO fDAO;
        Models.DAO.Connection con;

        [Authorize]
        public ActionResult Reagentes()
        {
            if (!(int.Parse(Session["Role"].ToString()) == 000))
            {
                gDAO = new Models.DAO.GrupoDAO();
                oDAO = new Models.DAO.OrgaoDAO();

                con = new Models.DAO.Connection();

                if (con.statusconexao() != 1)
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
                List<SelectListItem> la = new List<SelectListItem>();
                foreach (DataRow item in dp.Rows)
                {
                    SelectListItem gr = new SelectListItem();
                    gr.Value = item["id_orgao"].ToString();
                    gr.Text = item["desc_orgao"].ToString();
                    la.Add(gr);

                }
                vmodel.Grupo = ls;
                vmodel.listOrgao = la;



                return View(vmodel);
            }



            return RedirectToRoute(new { controller = "Home", action = "Erro" ,id = 1 });
        }

        [Authorize]
        public ActionResult Frascos()
        {
            var vmodel = new Models.ViewModels.CadastroFrascoViewModel();
            rDAO = new Models.DAO.ReagenteDAO();
            DataTable dt = rDAO.selectListReagente().Tables[0];

            List<SelectListItem> ls = new List<SelectListItem>();

            foreach(DataRow row in dt.Rows)
            {
                SelectListItem sl = new SelectListItem();
                sl.Value = row["id_tipo"].ToString();
                sl.Text = row["desc_tipo"].ToString();
                ls.Add(sl);
            }

            vmodel.listaReagente = ls;
            return View(vmodel);
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
            if (int.Parse(Session["Role"].ToString()) == 111)
            {
                List<Roles> rl = new List<Roles>();
                rl.Add(new Roles() { ID = 1, Descricao = "Administrador" });
                rl.Add(new Roles() { ID = 2, Descricao = "Coordenador de Laboratório" });
                rl.Add(new Roles() { ID = 3, Descricao = "Auxiliar de Docente" });
                rl.Add(new Roles() { ID = 4, Descricao = "Professor" });

                var vumodel = new Models.ViewModels.CadastroUsuariosViewModel();
                List<SelectListItem> li = new List<SelectListItem>();


                foreach (Roles it in rl)
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

            return RedirectToRoute(new { controller = "Home", action = "Erro", id = 1 });

        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Usuario(CadastroUsuariosViewModel vm)
        {
            if(!ModelState.IsValid)
            {
                return View(vm);
            }

            else
            {
                int role = 671;
                if(vm.SelectedRole <3)
                {
                    vm.Subject = "";

                    switch(vm.SelectedRole-1)
                    {
                        case 0:
                            role = 111;
                            break;
                        case 1:
                            role = 110;
                            break;

                        case 2:
                            role = 100;
                            break;

                    }
                }

                else
                {
                    role = 000;
                }


                String[] atributos = { vm.Matricula.ToString(), vm.Nome.ToString().ToUpper(),vm.Login,vm.Password.ToString(), role.ToString(), vm.Subject.ToString() };
                fDAO = new Models.DAO.FuncionarioDAO();
                if(fDAO.selectWhere(0, "matricula_funcionario = " + atributos[0]).Tables[0].Rows.Count == 0)
                {
                    if(fDAO.create(atributos, 3) == 1)
                    {
                        return RedirectToAction("Sucesso");
                    }
                }

                else
                {
                    return RedirectToAction("Usuarios", "Cadastro");
                }

                
               
            }

            return RedirectToAction("Erro","Cadastro");
        }

        [Authorize]
        public ActionResult Pedidos()
        { 
            return View();
        }

        [Authorize]
        public ActionResult Pedidos(int id_grupo)
        {
            return View();
        }

        [Authorize]

        public ActionResult Sucesso()
        {
            return View();
        }

      

        
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Frascos(CadastroFrascoViewModel cvm)
        {
            return View(cvm);
        }

        [Authorize]

        public ActionResult Fabricante()
        {
            return View();
        }


    }
}