using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Mvc5RazorAutenticacao.Models
{
    /*O namespace System.ComponentModel.DataAnnotations fornece classes de atributos usadas para definir metadados para 
     * controles de dados do ASP.NET e ASP.NET MVC.
     * 
     * DisplayAttribute.Name Propriedade
     * Obtém ou define um valor usado para exibição na interface do usuário. 
     * 
     * Atributo Required especifica que o valor de dados de uma campo é obrigatorio .
                
         */

    [MetadataType(typeof(Professores))]

    /*O MetadataTypeAttribute atributo permite associar uma classe a uma classe parcial de modelo de dados. Nessa classe associada, 
     * você fornece informações de metadados adicionais que não estão no modelo de dados.*/

    public class Professores
    {/* HiddenInputAttribute Class  Representa um atributo usado para indicar se uma propriedade ou valor de campo deve ser processado
        como um elemento de entrada oculto.
        Propriedade DisplayValue - Obtém ou define um valor que indica se deve ser exibido o valor do elemento de entrada oculto.
         
         */

        [Display(Name="Codigo ")]
        [HiddenInput(DisplayValue = false)]
        public int profCodigo { get; set; }

        [Display(Name ="Nome do Professor")]
        [Required(ErrorMessage ="Campo nome é obrigatório !")]
        public String profNome { get; set; }

        [Display(Name ="Curso Ministrado")]
        [Required(ErrorMessage ="Campo curso é obrigatório !")]
        public String profCurso { get; set; }

        [Display(Name ="Preço")]
        [Required(ErrorMessage ="Campo preço é obrigatório !")]
        [Range(1,1000, ErrorMessage ="Valor minimo R$ 1 e maximo R$ 2000")]
        public float profPreco { get; set; } 

        [Range(16,50,ErrorMessage ="Inserir Idade entre 16 e 50 anos !")]
        [DisplayFormat(DataFormatString ="dd/mm/yyyy")]
        public String idade { get; set; }

        [DataType(DataType.Password, ErrorMessage ="Senha Invalida !")]
        public String senha { get; set; }
    }
}