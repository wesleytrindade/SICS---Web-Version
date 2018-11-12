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
        Models.DAO.FabricanteDAO faDAO;
        Models.DAO.FuncionarioDAO fDAO;
        Models.DAO.PedidosDAO pDAO;
        Models.DAO.Connection con;

        CadastroPedidosViewModel vumodelped;

        [Authorize]
        public ActionResult Reagentes()
        {

            if (Session.Count <= 0)
            {
                return RedirectToAction("Logout", "Auth");
            }

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

                vmodel.listOrgao = la;
                vmodel.Grupo = ls;
                return View(vmodel);
            }



            return RedirectToRoute(new { controller = "Home", action = "Erro", id = 1 });
        }

        [Authorize]
        [HttpPost]

        public ActionResult Reagentes(CadastroReagenteViewModel vm)
        {
            String cont = null;
            if (vm.Controlado == true)
            {
                cont = "Y";
            }

            else
            {
                cont = "N";
            }
            String[] atributos = { vm.Nome, vm.Teor, vm.Formula, vm.CAS, cont, vm.OrgaoSelecionado.ToString(), vm.GrupoSelecionado, vm.EstoqueMin.ToString(), vm.EstoqueMax.ToString() };
            rDAO = new Models.DAO.ReagenteDAO();
            if (rDAO.createReagente(atributos) == 1)
            {
                return RedirectToAction("Sucesso");
            }

            else
            {
                return RedirectToRoute(new { controller = "Home", action = "Erro", id = 2 });
            }

        }

        [Authorize]
        public ActionResult Frasco(int? selectedGrupo,int? selectedReagente)
        {
            if (Session.Count <= 0)
            {
                return RedirectToAction("Logout", "Auth");
            }

            
            var vmodel = new Models.ViewModels.CadastroFrascoViewModel();
            
            rDAO = new Models.DAO.ReagenteDAO();
            faDAO = new Models.DAO.FabricanteDAO();
            frDAO = new Models.DAO.FrascosDAO();
            gDAO = new Models.DAO.GrupoDAO();
            DataTable dt = new DataTable();
            DataTable db = faDAO.selectFabricantes().Tables[0];
            DataTable ds = gDAO.select();
            List<SelectListItem> lb = new List<SelectListItem>();
            List<SelectListItem> ls = new List<SelectListItem>();
            List<SelectListItem> lg = new List<SelectListItem>();

           

            if (!selectedGrupo.HasValue)
            {
                dt = rDAO.selectListReagente().Tables[0];
                SelectListItem dx = new SelectListItem();
                dx.Text = "Selecione um grupo";
                dx.Value = "0";
                dx.Selected = true;
                ViewBag.desativaReag = true;
                lg.Add(dx);
            }

            foreach (DataRow row in ds.Rows)
            {
                SelectListItem sl = new SelectListItem();
                if (int.Parse(row["id_grupo"].ToString()) == selectedGrupo)
                    sl.Selected = true;
                sl.Value = row["id_grupo"].ToString();
                sl.Text = row["desc_grupo"].ToString();
                lg.Add(sl);

            }


            if (selectedGrupo.HasValue)
            {
                dt = rDAO.selectListByGrupo(int.Parse(selectedGrupo.ToString())).Tables[0];
                foreach (DataRow row in dt.Rows)
                {
                    SelectListItem sl = new SelectListItem();
                    if (vmodel.selectedReagente != 0)
                    {
                        sl.Selected = true;
                    }
                    sl.Value = row["id_tipo"].ToString();
                    sl.Text = row["desc_tipo"].ToString();
                    ls.Add(sl);

                }

                if(dt.Rows.Count == 0)
                {
                    ViewBag.semReagentes = true;
                }

                else
                {
                    ViewBag.desativaReag = false;
                    ViewBag.semReagentes = false;
                    if(selectedGrupo.HasValue && !selectedReagente.HasValue)
                       selectedReagente = int.Parse(ls[0].Value);
                }
            }


            foreach (DataRow row in db.Rows)
            {
                SelectListItem dg = new SelectListItem();
                dg.Value = row["id_fabricante"].ToString();
                dg.Text = row["desc_fabricante"].ToString();
                lb.Add(dg);
            }

            if (selectedReagente.HasValue)
            {
                vmodel.frasco_estoque = Convert.ToDecimal(frDAO.getEstoque(selectedReagente.Value));
            }
           // vmodel.estoque_maximo = 
            vmodel.listaGrupo = lg;
            vmodel.listaReagente = ls;
            vmodel.listaFabricantes = lb;
            return View(vmodel);

        }
        
    

        

        [Authorize]
        public ActionResult Fabricante()
        {
            if (Session.Count <= 0)
            {
                return RedirectToAction("Logout", "Auth");
            }
            return View();
        }

        [Authorize]
        [HttpPost]

        public ActionResult Fabricante(CadastroFabricantesViewModel vf)
        {
            if(!ModelState.IsValid)
            {
                return View(vf);
            }

            faDAO = new Models.DAO.FabricanteDAO();

            if(faDAO.createFabricante(vf.NomeFabricante,vf.TelefoneFabricante,vf.EnderecoFabricante) == 1)
            {
                return RedirectToRoute(new { controller = "Cadastro", action = "Sucesso" });
            }

            else
            {
                return RedirectToRoute(new { controller = "Home", action = "Erro", id=2 });
            }
            
        }

        [Authorize]
        public ActionResult OrgaoControlador()
        {
            if (Session.Count <= 0)
            {
                return RedirectToAction("Logout", "Auth");
            }
            return View();
        }

        [Authorize]
        public ActionResult Usuario()
        {
            if (Session.Count <= 0)
            {
                return RedirectToAction("Logout", "Auth");
            }

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
                    return View(vm);
                }

                
               
            }

            return RedirectToRoute(new { controller = "Home", action = "Erro", id = 2 });
        }

        [Authorize]
        public ActionResult Pedidos(bool? addToList,int? selectedGrupo, int? selectedReagente, float? qtdereagente)
        {
           
            if (Session.Count <= 0)
            {
                return RedirectToAction("Logout", "Auth");
            }

            gDAO = new Models.DAO.GrupoDAO();
            rDAO = new Models.DAO.ReagenteDAO();

            if ((!addToList.HasValue)&&(!(selectedGrupo.HasValue) && !(selectedReagente.HasValue)) && !(qtdereagente.HasValue))
            {
                vumodelped = new Models.ViewModels.CadastroPedidosViewModel();
                vumodelped.selectedReagentes = new DataTable();
                vumodelped.selectedReagentes.Columns.Add("reagente_selecionado");
                vumodelped.selectedReagentes.Columns.Add("qtde_reagente");
            }
                List<SelectListItem> ls = new List<SelectListItem>();
                DataTable dx = gDAO.select();
                DataTable dt = rDAO.selectListReagente().Tables[0];

            if (!selectedGrupo.HasValue)
            {
                SelectListItem dp = new SelectListItem();
                dp.Text = "Selecione um grupo";
                dp.Value = "0";
                dp.Selected = true;
                ViewBag.desativaReag = true;
                ls.Add(dp);
            }

            foreach (DataRow item in dx.Rows)
                {
                    SelectListItem sl = new SelectListItem();
                    sl.Text = item["desc_grupo"].ToString();
                    sl.Value = item["id_grupo"].ToString();
                    ls.Add(sl);

                }

               if(addToList == true)
               {
                vumodelped.selectedReagentes.Rows.Add(selectedReagente, qtdereagente);
               }
                vumodelped.listGrupo = ls;
                return View(vumodelped);
        }


        [Authorize]

        public ActionResult Sucesso()
        {
            if (Session.Count <= 0)
            {
                return RedirectToAction("Logout", "Auth");
            }

            return View();
        }

      

        
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Frasco(CadastroFrascoViewModel cvm)
        {
            frDAO = new Models.DAO.FrascosDAO();

            if (!ModelState.IsValid)
            {
                return View(cvm);
            }

            else
            {
                if(frDAO.createFrasco(cvm) == 1)
                {
                    return RedirectToAction("Sucesso");
                }

                else
                {
                    return RedirectToRoute(new { controller = "Home", action = "Erro", id = 2 });
                }
            }
        }

       
       
    }
}