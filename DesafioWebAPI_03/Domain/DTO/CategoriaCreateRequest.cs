using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioWebAPI_03.Domain.DTO
{
    public class CategoriaCreateRequest
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Insira o nome da categoria.")]
        public string Nome { get; set; }
    }
}
