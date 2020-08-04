using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc5RazorAutenticacao.Models
{
    public class Professores
    {
        public int profCodigo { get; set; }
        public String profNome { get; set; }
        public String profCurso { get; set; }
        public float profPreco { get; set; } 
    }
}