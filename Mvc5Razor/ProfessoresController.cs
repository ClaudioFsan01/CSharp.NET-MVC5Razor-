﻿using Mvc5RazorAutenticacao.Models;
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

            /*Melhorando o codigo utilizando o método construtor*/
        private ProfessoresCrud profCrud_;

        public ProfessoresController()
        {
            
                profCrud_ = ProfessoresFactory.InstanciarProfessores();
            
         
        }

        public ActionResult CreateProf()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateProf(Professores professor)
        {
            if (ModelState.IsValid)
            {
                /* ModelStateDictionary.IsValid Propriedade
                 * Obtém um valor que indica se há erros em qualquer um dos objetos de estado de modelo no dicionário.
                 * 
                 * ModelState - Obtém o objeto de dicionário de estado de modelo que contém o estado do modelo e da validação de associação de modelo.
                   IsValid- 
                 */
                profCrud_.InserirProfessor(professor);
                TempData["mensagem"] = "Professor inserido com sucesso !";
                return RedirectToAction("ListaProfessores");

            }
            else
            {
                return View();
            }
          

            /*
            try
            {
                //ProfessoresFactory.InstanciarProfessores().InserirProfessor(professor);

                profCrud_.InserirProfessor(professor);
                TempData["mensagem"] = "Professor inserido com sucesso !";
                return RedirectToAction("ListaProfessores"); 
            }
            catch
            {
                return View();
            }
            */

        }



        public ActionResult ListaUm()
        {
            // Professores professor = ProfessoresFactory.InstanciarProfessores().RetornarProfessores()[0];

            Professores professor = profCrud_.RetornarProfessores()[0];

                /*ProfessoresFactory.InstanciarProfessores() retorna uma instancia da classe ProfessoresCrud
                 com essa instancia podemos acessar os métodos dessa classe acessando assim o método RetornarProfessores()
                 que retorna a lista de Professores. Usando o Array [0] estou pegando apenas o 1° professor desta lista.*/



            ///Professores professor = ProfessoresCrud.RetornarProfessores()[0];
            // ProfessoresCrud.ListaProfessores()[0];  pegando o 1° professor da lista retornada
            return View(professor);
        }

        public ActionResult ListaProfessores()
        {
            // var listaProfessores = ProfessoresFactory.InstanciarProfessores().RetornarProfessores(); 
            var listaProfessores = profCrud_.RetornarProfessores();
           // var listaProfessores = ProfessoresCrud.RetornarProfessores();
           //ProfessoresCrud.ListaProfessores();
            return View(listaProfessores);
        }


        public ActionResult EditProf(int id)
        {
            try
            {
                var editarProfessor = profCrud_.RetornarProfessores().Where(prof => prof.profCodigo == id).FirstOrDefault();
                /*usando a instancia de ProfessoresCrud  profCrud_  para retornar a lista de professores e percorremos essa lista atraves 
                 da clausula where com uso de lambda retornamos o 1° professor cujo o codigo seja igual a id recebida no parametro.
                 FirstOrDefault() retorna o 1° elemento encontrado ou um valor padrão 
                 */ return View(editarProfessor);
            }
            catch
            {
               return RedirectToAction("ListaProfessores");
            }
        }

        [HttpPost]
        public ActionResult EditProf(Professores profEditado)
        {

            if (ModelState.IsValid)
            {
                profCrud_.EditarProfessor(profEditado);
                TempData["mensagem"] = "Professor editado com sucesso !";
                return RedirectToAction("ListaProfessores");

            }
            else
            {
                return View();
            }




            /*
            try
            {
               
                profCrud_.EditarProfessor(profEditado);
                TempData["mensagem"] = "Professor editado com sucesso !";
                return RedirectToAction("ListaProfessores");

                
                //editarProfessor.


            }
            catch
            {
                return View();
            }*/

        }

        public ActionResult DeleteProf(int id)
        {
            try
            {
              Professores professor = profCrud_.RetornarProfessores().Where(prof => prof.profCodigo == id).First();
                return View(professor);
            }
            catch
            {
                return RedirectToAction("ListaProfessores");
            }
           
        }

        /*
        [HttpPost]
        public ActionResult DeleteProf(Professores professor)
        {
            try
            {
                profCrud_.ExcluirProfessor(professor);
                TempData["mensagem"] = "Professor excluido com sucesso !";
                return RedirectToAction("ListaProfessores");

            }
            catch
            {
                return View("Delete");
            }
           
        }*/

        //[HttpPost, ActionName("DeleteProf")]
        public ActionResult DeleteProfSim(Professores professor)
        {
            try
            {
                profCrud_.ExcluirProfessor(professor);
                TempData["mensagem"] = "Professor excluido com sucesso !";
                return RedirectToAction("ListaProfessores");

            }
            catch
            {
                return View("Delete");
            }

        }



    }
}