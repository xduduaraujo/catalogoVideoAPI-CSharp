using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioWebAPI_03.Domain.DTO;
using DesafioWebAPI_03.Domain.Entity;
using DesafioWebAPI_03.Services;


namespace DesafioWebAPI_03.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoControllers : ControllerBase
    {
        private readonly VideoService _videoService;

        public VideoControllers(VideoService videoService)
        {
            this._videoService = videoService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] VideoCreateRequest postModel)
        {
            if (ModelState.IsValid)
            {
                var retorno = _videoService.CadastrarNovo(postModel);
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
        public IEnumerable<VideoResponse> Get()
        {
            return _videoService.ListarTodos();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var retorno = _videoService.PesquisaPorId(id);

            if (retorno.Sucesso)
            {
                return Ok(retorno.ObjetoRetorno);
            }
            else
            {
                return NotFound(retorno.Mensagem);
            }
        }
        [HttpPut("url/{id}")]
        public IActionResult Put(int id, [FromBody] VideoUpdateRequest putModel)
        {
            if (ModelState.IsValid)
            {
                var retorno = _videoService.Editar(id, putModel);
                if (!retorno.Sucesso)
                    return BadRequest(retorno.Mensagem);
                return Ok(retorno.ObjetoRetorno);
            }
            else
            {
                return BadRequest(ModelState);
            }

        }
    }
}