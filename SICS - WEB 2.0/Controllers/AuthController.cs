using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using SICS___WEB_2._0.Models.ViewModels;
using SICS___WEB_2._0.Models.DAO;
using SICS___WEB_2._0.Models;

namespace SICS___WEB_2._0.Controllers
{
    

    public class AuthController : Controller
    {
        LoginDAO loginDAO;

        [AllowAnonymous]
        public ActionResult Login()
        {
            if (Session.Count>0)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        [AllowAnonymous]

        public ActionResult Login (LoginViewModel lg,string returnURl)
        {
            Connection ld = new Connection();
            loginDAO = new LoginDAO();
            ld.conecta();
            
            if(!ModelState.IsValid)
            {
                return View(lg);
            }

            else
            {
                Login lb = loginDAO.AutenticaUsuario(lg.Username, lg.Password);
                if (lb != null)
                {
                    FormsAuthentication.SetAuthCookie(lg.Username, false);
                    Funcionario ff = loginDAO.userInformation(lb.ID);
                    Session["Name"] = ff.Nome;
                    Session["Role"] = lb.Role;
                    if (Url.IsLocalUrl(returnURl))
                    {
                        return Redirect(returnURl);
                    }

                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }

                else
                {
                    lg.invalidCredentials = true;
                    return View(lg);
                }

                
            }
        
           
        }

        [Authorize]

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Login","Auth");
            
        }
    }
}