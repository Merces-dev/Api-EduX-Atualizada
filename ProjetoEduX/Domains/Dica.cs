using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProjetoEduX.Domains
{
    public partial class Dica
    {
        public Dica()
        {
           
        }

        public Guid IdDica { get; set; }
        public string Texto { get; set; }
        public Guid IdUsuario { get; set; }

        public string Titulo { get; set; }



        [NotMapped]
      
        public IFormFile Imagem { get; set; }

        public string UrlImagem { get; set; }
   
        public virtual Usuario IdUsuarioNavigation { get; set; }
       
    }
}
