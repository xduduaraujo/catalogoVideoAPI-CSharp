using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioWebAPI_03.Domain.DTO
{
    public class VideoUpdateRequest
    {

        [Url(ErrorMessage = "O url é inválido.")]
        public string URL { get; set; }

    }
}
