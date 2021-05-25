using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioWebAPI_03.DAL;
using DesafioWebAPI_03.Domain.DTO;
using DesafioWebAPI_03.Domain.Entity;
using DesafioWebAPI_03.Services.Base;
using Microsoft.EntityFrameworkCore;

namespace DesafioWebAPI_03.Services
{
    public class VideoService
    {
        private readonly AppDbContext _dbContext;
        public VideoService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }



        public ServiceResponse<VideoResponse> CadastrarNovo(VideoCreateRequest model)
        {
            var resultado = _dbContext.Responsaveis.FirstOrDefault(x => x.IdResponsavel == model.IdResponsavel);
            if (resultado == null) {
                return new ServiceResponse<VideoResponse>("Responsável não encontrado.");
            }

            var novoVideo = new Video()
            {
                Titulo = model.Titulo,
                URL = model.URL,
                IdadeMin = model.IdadeMin,
                IdResponsavel = model.IdResponsavel.Value
            };

            _dbContext.Add(novoVideo);
            _dbContext.SaveChanges();
            var retorno = new VideoResponse(novoVideo);
            return new ServiceResponse<VideoResponse>(retorno);
        }

        public ServiceResponse<Video> PesquisaPorId(int id)
        {
            var resultado = _dbContext.Videos.FirstOrDefault(x => x.IdVideo == id);
            if(resultado == null)
            {
                return new ServiceResponse<Video>("Video: " + id + " não encontrado");
            } else
            {
                return new ServiceResponse<Video>(resultado);
            }
        }

        public IEnumerable<VideoResponse> ListarTodos()
        {

            List<Video> retornoDoBanco = _dbContext.Videos.ToList();

            IEnumerable<VideoResponse> listaDeVideos = retornoDoBanco.Select(x => new VideoResponse(x));

            return listaDeVideos;
        }

        public ServiceResponse<Video> Editar(int id, VideoUpdateRequest model)
        {
            var resultado = _dbContext.Videos.FirstOrDefault(x => x.IdVideo == id);

            if (resultado == null) { 
                return new ServiceResponse<Video>("Video: " + id + " não encontrado");
            }
            resultado.URL = model.URL;
            _dbContext.Videos.Add(resultado).State = EntityState.Modified;
            _dbContext.SaveChanges();

            return new ServiceResponse<Video>(resultado);
        }

    }
}
