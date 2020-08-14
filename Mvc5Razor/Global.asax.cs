using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Mvc5RazorAutenticacao.Models;

namespace Mvc5RazorAutenticacao
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Application["CadastroProfessor"] = ProfessoresFactory.InstanciarProfessores();
        }
    }

    /*
     HttpApplication Class 
     Define os métodos, as propriedades e os eventos comuns a todos os objetos de aplicativo em um aplicativo ASP.NET. 
     Essa classe é a classe base para aplicativos definidos pelo usuário no arquivo Global.asax.

   Propriedade Application da classe  HttpApplication  -  Obtem o estado atual de um aplicativo    
     
     
     */
}
