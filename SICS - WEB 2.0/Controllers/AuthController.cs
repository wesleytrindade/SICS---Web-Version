using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using SICS___WEB_2._0.ViewModels;

namespace SICS___WEB_2._0.Controllers
{
    public class AuthController : Controller
    {
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]

        public ActionResult Login (LoginViewModel lg,string returnURl)
        {
            if(!ModelState.IsValid)
            {
                return View(lg);
            }

            else
            {
                FormsAuthentication.SetAuthCookie(lg.Username, false);
                if(Url.IsLocalUrl(returnURl))
                {
                   return Redirect(returnURl);
                }

                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }

           
        }
    }
}