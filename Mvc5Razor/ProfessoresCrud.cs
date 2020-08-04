using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc5RazorAutenticacao.Models
{
    public class ProfessoresCrud
    {
        private static IList<Professores> professores;
        /* interface IList<> Representa uma coleção não genérica de objetos que podem ser acessados separadamente por índice.
         *  A interface genérica IList<T> é um descendente da interface genérica ICollection<T> e é a interface base de todas as listas genéricas.
         *  Implements ICollection<T>  IEnumerable<T>  IEnumerable
         * 
         <classe List<> implementa a interface IList<> Representa uma lista fortemente tipada de objetos que podem ser
         acessados por índice. Fornece métodos para pesquisar, classificar e manipular listas.

         * IList<Professores> professores=> A variavel professores do tipo da interface IList<Professores>  faz referencia para um objeto 
         do tipo List<Professores>
         */



        public static IList<Professores> ListaProfessores()
        {
           professores = new List<Professores>();
            professores.Add(new Professores() { profCodigo = 1, profCurso = "Pyton", profNome = "Nery", profPreco = 20.00F });
            professores.Add(new Professores() { profCodigo = 2, profCurso = "React", profNome = "Marciano", profPreco = 30 });
            professores.Add(new Professores() { profCodigo = 3, profCurso = "JavaScript", profNome = "Sales", profPreco = 40 });

            return professores;
                                 
        }



    }
}