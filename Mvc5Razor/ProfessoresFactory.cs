using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace Mvc5RazorAutenticacao.Models
{//Design Pattern / Padrão de Projeto 

    public class ProfessoresFactory
    {
        /*Quando essa classe ProfessoresFactory for executada o método InstanciarProfessores() do tipo 
         ProfessoresCrud será executado criando assim uma instancia da classe ProfessoresCrud() retornando esse objeto, logo o construtor 
         da classe ProfessoresCrud() será executado criando uma lista de Professores. Isso tambem evita a necessitade de  
         instanciar a classe ProfessoresCrud em outra classe para criar a lista de professores.*/

            

        public static ProfessoresCrud InstanciarProfessores()
        {
           
             if (HttpContext.Current.Application["CadastroProfessor"] == null)
             {
              return new ProfessoresCrud();
             }
            else
            {
                return (ProfessoresCrud)HttpContext.Current.Application["CadastroProfessor"];

                /*Para obter o valor , você deve usar o mesmo índice e efetuar a coersão(Cast) do valor de Object HttpApplicationState para o objeto ProfessoresCrud*/
            }


            /* A classe HttpContext encapsula todas as informações específicas de HTTP sobre uma solicitação HTTP individual.            
              A propriedade Current Obtém ou define o objeto HttpContext para a atual solicitação HTTP.

              OBS : Para cada usuario é gerado um objeto HttpContext.

             A propriedade Application da classe  HttpApplication  -  Obtem o estado atual de um aplicativo  

             A propriedade Application Obtém o objeto  HttpApplicationState para a solicitação HTTP atual.
                         
            O objeto Application existe durante o tempo de vida da aplicação, ou seja, a partir do momento que a primeira requisição for recebida até o momento que a
            aplicação é parada.
            
            Esses objetos fornecem uma coleção baseada em chaves para armazenamento de dados durante o tempo de vida do objeto. Como não há persistência para esses
            objetos você deve armazenar somente dados temporários, se você precisar armazenar os dados por um período maior de tempo deverá usar um banco de dados ou 
            talvez um objeto Profile.
             */


        }


    }
}