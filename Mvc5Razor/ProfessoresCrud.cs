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
            professores.Add(professor);
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