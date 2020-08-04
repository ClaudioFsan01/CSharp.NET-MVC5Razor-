using Mvc5RazorAutenticacao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5RazorAutenticacao.Controllers
{
    public class ProfessoresController : Controller
    {
        // GET: Professores
        public ActionResult ListaUm()
        {
            return View();
        }

        public ActionResult ListaProfessores()
        {
            var listaProfessores = ProfessoresCrud.ListaProfessores();
            return View(listaProfessores);
        }


    }
}