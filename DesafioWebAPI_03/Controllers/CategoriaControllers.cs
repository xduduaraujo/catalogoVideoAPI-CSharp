using DesafioWebAPI_03.Domain.DTO;
using DesafioWebAPI_03.Services;
using DesafioWebAPI_03.Services.Base;
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
    public class CategoriaControllers : ControllerBase
    {
        private readonly CategoriaService _categoriaService;

        public CategoriaControllers(CategoriaService categoriaService)
        {
            this._categoriaService = categoriaService;
        }
        [HttpPost]
        public IActionResult Post([FromBody] CategoriaCreateRequest postModel)
        {
            if (ModelState.IsValid)
            {
                var retorno = _categoriaService.CadastrarNovo(postModel);
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
        [HttpGet]
        public IEnumerable<CategoriaResponse> Get()
        {
            return _categoriaService.ListarTodos();
        }


    }
}
