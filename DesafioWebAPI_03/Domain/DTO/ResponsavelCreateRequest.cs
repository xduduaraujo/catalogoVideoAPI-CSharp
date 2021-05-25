using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioWebAPI_03.Domain.DTO
{
    public class ResponsavelCreateRequest
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Insira o nome do responsável.")]
        public string Nome { get; set; }
    }
}
