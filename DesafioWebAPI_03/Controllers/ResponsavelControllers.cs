using DesafioWebAPI_03.Domain.DTO;
using DesafioWebAPI_03.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioWebAPI_03.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResponsavelControllers : ControllerBase
    {

        private readonly ResponsavelService _responsavelService;

        public ResponsavelControllers(ResponsavelService responsavelService)
        {
            this._responsavelService = responsavelService;
        }
        [HttpPost]
        public IActionResult Post([FromBody] ResponsavelCreateRequest postModel)
        {
            if (ModelState.IsValid)
            {
                var retorno = _responsavelService.CadastrarNovo(postModel);
                if (!retorno.Sucesso)
                {
                    return BadRequest(retorno.Mensagem);
                }
                else
                {
                    return Ok(retorno);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var retorno = _responsavelService.PesquisaPorId(id);

            if (retorno.Sucesso)
            {
                return Ok(retorno.ObjetoRetorno);
            }
            else
            {
                return NotFound(retorno.Mensagem);
            }
        }
    }
}
