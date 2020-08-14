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

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Professores professor)
        {
            try
            {
                ProfessoresFactory.InstanciarProfessores().InserirProfessor(professor);
                return RedirectToAction("ListaProfessores"); 
            }
            catch
            {
                return View();
            }
            
          
        }



        public ActionResult ListaUm()
        {
            Professores professor = ProfessoresFactory.InstanciarProfessores().RetornarProfessores()[0];

                /*ProfessoresFactory.InstanciarProfessores() retorna uma instancia da classe ProfessoresCrud
                 com essa instancia podemos acessar os métodos dessa classe acessando assim o método RetornarProfessores()
                 que retorna a lista de Professores. Usando o Array [0] estou pegando apenas o 1° professor desta lista.*/



            ///Professores professor = ProfessoresCrud.RetornarProfessores()[0];
            // ProfessoresCrud.ListaProfessores()[0];  pegando o 1° professor da lista retornada
            return View(professor);
        }

        public ActionResult ListaProfessores()
        {
            var listaProfessores = ProfessoresFactory.InstanciarProfessores().RetornarProfessores(); 

           // var listaProfessores = ProfessoresCrud.RetornarProfessores();
                //ProfessoresCrud.ListaProfessores();
            return View(listaProfessores);
        }


    }
}