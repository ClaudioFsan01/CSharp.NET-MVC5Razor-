using Mvc5RazorAutenticacao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;

namespace Mvc5RazorAutenticacao.Controllers
{
    public class CursosController : Controller
    {
        SampleDatabaseEntities1 tabelaCursos = new SampleDatabaseEntities1();
        // GET: Cursos
        public ActionResult Lista()
        {
            return View(tabelaCursos.Cursos.ToList());
            //ToList() Cria um List<T> de um IEnumerable<T>.
            //Nesse caso será retornado uma lista do tipo Cursos
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Cursos curso)
        {
            try
            {
                tabelaCursos.Cursos.Add(curso); /*adicionando a entidade curso atraves do método Add() na coleção 
                de cursos acessada na propriedade Cursos ( DbSet<Cursos> Cursos). */

                tabelaCursos.SaveChanges(); // Salva as mudanças na base de dados

               return RedirectToAction("Lista"); // redireciona para view especificada no parametro
            }
            catch 
            {
                return View();
            }          
            
        }

        public ActionResult Edit(int id)
        {
            try
            {
                var cursoEditado = buscaCurso(id);
                return View(cursoEditado); // enviando o curso que será editado para a pagina Edit.cshtml
            }
            catch
            {
                return RedirectToAction("Lista");
            }
            
        }

        /*  [HttpPost] Representa um atributo que restringe o método de ação Edit(Cursos curso) afim de que 
                    o metodo trate apenas das solicitações HTTP POST*/
        [HttpPost]
        public ActionResult Edit(Cursos curso) // sobrecarga
        {
            try
            {
               
                tabelaCursos.Entry(curso).State = System.Data.Entity.EntityState.Modified;
                tabelaCursos.SaveChanges();
                

                /*
                 *  https://docs.microsoft.com/pt-br/ef/ef6/saving/change-tracking/entity-state
                 * método Entry(object)
                 Obtém um objeto DbEntityEntry para a entidade fornecida, fornecendo acesso a informações sobre a entidade e a capacidade de executar ações na entidade.

                State ´obtem ou define o status da entidade

                System.Data.Entity.EntityState.Modified :
                Modified: a entidade está sendo rastreada pelo contexto e existe no banco de dados e alguns ou todos os seus valores de propriedade foram modificados   
                
                OBS : As entidades modificadas são atualizadas no banco de dados e ficam inalteradas quando o SaveChanges retorna.
                 
                 */

                /*
                 Alterando o estado de uma entidade rastreada

                Você pode alterar o estado de uma entidade que já está sendo rastreada definindo a propriedade State em sua entrada. Por exemplo:                 
                 */

                /*
                tabelaCursos.Cursos.Attach(curso);
                tabelaCursos.Entry(curso).State = System.Data.Entity.EntityState.Unchanged;
                tabelaCursos.SaveChanges();
                */
                /*
                 * Codigo acima para as situações em que a entidade já tiver sido modificada anteriormente e desejamos 
                 * altera la novamente. 
                 
                 */

                /*
                 Observe que chamar adicionar ou anexar para uma entidade que já está acompanhada também pode ser usado para alterar o 
                 estado da entidade. Por exemplo, chamar attach para uma entidade que está atualmente no estado adicionado alterará seu 
                 estado para inalterado.
                 
                EntityState.Unchanged = status da entidade inalterado
                método Attach() = anexar
                 
                 */


                return RedirectToAction("Lista"); 
            }
            catch
            {
                return View();
            }

        }

        public ActionResult Delete(int id)
        {
            var excluirCurso = buscaCurso(id);
            return View(excluirCurso);
        }

        [HttpPost]
        public ActionResult Delete(int id, Cursos curso)
        {
            try
            {
                ///tabelaCursos.Cursos.Remove(curso);
                var excluirCurso = buscaCurso(id);
                tabelaCursos.Entry(excluirCurso).State = System.Data.Entity.EntityState.Deleted;
                tabelaCursos.SaveChanges();
                return RedirectToAction("Lista");
            }
            catch
            {
                return View();
            }
           
        }

        public ActionResult Details(int id)
        {
            var cursodetalhado = buscaCurso(id);
            return View(cursodetalhado);

            /*
             Cláusula from :
             Uma expressão de consulta deve começar com uma cláusula from . Além disso, uma expressão de consulta
           pode conter subconsultas, que também começam com uma cláusula from . A cláusula from especifica o
           seguinte:
            A fonte de dados na qual a consulta ou subconsulta será executada.
          Uma variável de intervalo local que representa cada elemento na sequência de origem(fonte de dados).
             
             A variável de intervalo e a fonte de dados são fortemente tipadas. A fonte de dados referenciada na cláusula
             from deve ter um tipo de IEnumerable, IEnumerable<T> ou um tipo derivado, por exemplo, IQueryable<T>.
             
             No exemplo à cima, a propriedade Cursos ,do tipo ( DbSet<Cursos> Cursos) que retorna uma coleção de entidades,
             acessada atraves da instancia sdb da classe SampleDatabaseEntities1  é a fonte de dados e cat é a variável de 
             intervalo.   
             
            clausula where : Filtra uma sequencia de valores com base em um predicado

            Cláusula select :Em uma expressão de consulta, a cláusula select especifica o tipo de valores que serão produzidos quando
              a consulta é executada. O resultado é baseado na avaliação de todas as cláusulas anteriores e em quaisquer
             expressões na cláusula select em si. Uma expressão de consulta deve terminar com uma cláusula select
            ou uma cláusula group.           
             
             
             */
        }

        public Cursos buscaCurso(int id)
        {
            var curso = (from cat in tabelaCursos.Cursos where cat.curCodigo == id select cat).First();
            return curso;
        }
    }
}