﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SICS___WEB_2._0.Models;

namespace SICS___WEB_2._0.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            ViewBag.Title="SICS - WEB";
            Models.DAO.Connection cm = new Models.DAO.Connection();
            cm.conecta();
            return View();
        }

        [Authorize]

        public ActionResult Erro(int id)
        {
            String ErrorMessage = "";

            switch(id)
            {
                case 1:
                    ErrorMessage = "Você não possui permissão para acessar essa página!";
                    break;
            }
            ViewBag.ErrorMessage = ErrorMessage;
            return View();
        }
    }
}