using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc5RazorAutenticacao.Models
{
    public class ProfessoresCrud
    {
        private static IList<Professores> professores; 
        /* interface IList<T> Representa uma coleção genérica de objetos que podem ser acessados separadamente por índice.
         *  A interface genérica IList<T> é um descendente da interface genérica ICollection<T> e é a interface base de todas as listas genéricas.
         *  Implements ICollection<T>  IEnumerable<T>  IEnumerable
         * 
         <classe List<> implementa a interface IList<> Representa uma lista fortemente tipada de objetos que podem ser
         acessados por índice. Fornece métodos para pesquisar, classificar e manipular listas.

         * IList<Professores> professores=> A variavel professores do tipo da interface IList<Professores>  faz referencia para um objeto 
         do tipo List<Professores>
         */


       /*
        public static IList<Professores> ListaProfessores() método comum
        {
           professores = new List<Professores>();
            professores.Add(new Professores() { profCodigo = 1, profNome = "Nery", profCurso = "Pyton", profPreco = 20.00F });
            professores.Add(new Professores() { profCodigo = 2, profNome = "Marciano", profCurso = "React", profPreco = 30 });
            professores.Add(new Professores() { profCodigo = 3,  profNome = "Sales", profCurso = "JavaScript", profPreco = 40 });

            return professores;
                                 
        }
        */

       
        /*
         Ao invés de usarmos um método comum para criar uma lista usaremos um construtor
         */

        public void InserirProfessor(Professores professor)
        {
           /* Professores ultimoProfessor = professores.OrderBy(prof => prof.profCodigo).Last(); 
            * Nesse caso ordenaria a lista em ordem crescente e retornaria o ultimo elemento
            */

            Professores ultimoProfessor  = professores.OrderByDescending(prof => prof.profCodigo).First();
            professor.profCodigo = ultimoProfessor.profCodigo;
            professor.profCodigo++;
            professores.Add(professor);



            /*OrderByDescending(prof => prof.profCodigo) classifica os elementos de uma sequencia em ordem decrescente
             de acordo com uma chave. Nesse caso a chave é o codigo.

            First() retorna o primeiro elemento dessa sequencia que nesse caso será o ultimo elemento da lista

             
             */
        }

        public void EditarProfessor(Professores professor)
        {
           

             professores.Where(prof => prof.profCodigo == professor.profCodigo).First().profNome = professor.profNome;
             professores.Where(prof => prof.profCodigo == professor.profCodigo).First().profCurso = professor.profCurso;
            professores.Where(prof => prof.profCodigo == professor.profCodigo).First().profPreco = professor.profPreco;

            //professores.Remove(removerProf);
            //professores.Add(professor);
            // professores.OrderBy(prof => prof.profCodigo);

        }

        public void ExcluirProfessor(Professores professor)
        {
           
            professores.Remove(professores.Where(prof => prof.profCodigo==professor.profCodigo).First());
        }

        public ProfessoresCrud()
        {
            professores = new List<Professores>();

            professores.Add(new Professores() { profCodigo = 1, profNome = "Guanabara", profCurso = "Html", profPreco = 20.00F });
            professores.Add(new Professores() { profCodigo = 2, profNome = "Marciano", profCurso = "React", profPreco = 30 });
            professores.Add(new Professores() { profCodigo = 3, profNome = "Sales", profCurso = "C#", profPreco = 40 });
            professores.Add(new Professores() { profCodigo = 4, profNome = "Renato", profCurso = "JavaScript", profPreco = 50 });

        }

        public IList<Professores> RetornarProfessores()
        {
            return professores;

            /*Esse método que era estatico foi alterado para pode ser acessado atraves
           da instancia na classe ProfessoresController */
        }




    }
}