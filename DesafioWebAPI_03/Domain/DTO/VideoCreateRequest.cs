using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioWebAPI_03.Domain.DTO
{
    public class VideoCreateRequest
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Insira um título.")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "Insira um link válido.")]
        [Url(ErrorMessage = "Insira um link válido.")]
        public string URL { get; set; }
        public int? IdadeMin { get; set; }
        [Required]
        public int? IdResponsavel { get; set; }
    }
}
