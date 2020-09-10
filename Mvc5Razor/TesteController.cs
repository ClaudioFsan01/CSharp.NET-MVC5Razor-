using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5RazorAutenticacao.Controllers
{
    public class TesteController : Controller
    {
        // GET: Teste
        /* public ActionResult Index()
         {
             return View();
         }*/

            /*Este método é chamado quando uma solicitação corresponde a esse controlador mas nenhum método com o nome 
             * de ação especificado é encontrado no controlador */
        protected override void HandleUnknownAction(string actionName)
        {
            this.View(actionName).ExecuteResult(this.ControllerContext);

           // base.HandleUnknownAction(actionName);
        }
    }


    /*
     * Um método override fornece uma nova implementação de um membro herdado de uma classe base. 
     * O método que é substituído por uma declaração override é conhecido como o método base substituído. 
     * O método base substituído deve ter a mesma assinatura que o método override
     * 
     * A palavra-chave base é usada para acessar membros de classe base de dentro de uma classe derivada:
Chamar um método que foi substituído por outro método na classe base.
Especificar qual construtor de classe base deve ser chamado ao criar instâncias da classe derivada.
Um acesso de classe base é permitido somente em um construtor, em um método de instância ou em um acessador de propriedade de instância.
É um erro usar a palavra-chave base de dentro de um método estático.*/
}