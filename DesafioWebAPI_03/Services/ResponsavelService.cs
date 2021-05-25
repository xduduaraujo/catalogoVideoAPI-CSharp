using DesafioWebAPI_03.DAL;
using DesafioWebAPI_03.Domain.DTO;
using DesafioWebAPI_03.Domain.Entity;
using DesafioWebAPI_03.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioWebAPI_03.Services
{
    public class ResponsavelService
    {
			private readonly AppDbContext _dbContext;
			public ResponsavelService(AppDbContext dbContext)
			{
				_dbContext = dbContext;
			}
			public ServiceResponse<ResponsavelResponse> CadastrarNovo(ResponsavelCreateRequest model)
			{
				var nova = new Responsavel()
				{
					Nome = model.Nome
				};
				_dbContext.Add(nova);
				_dbContext.SaveChanges();
				var retorno = new ResponsavelResponse(nova);
				return new ServiceResponse<ResponsavelResponse>(retorno);
			
			}
			public ServiceResponse<Responsavel> PesquisaPorId(int id)
			{
				var resultado = _dbContext.Responsaveis.FirstOrDefault(x => x.IdResponsavel == id);
				if (resultado == null)
				{
					return new ServiceResponse<Responsavel>("Responsável: " + id + " não encontrado");
				}
				else
				{
					return new ServiceResponse<Responsavel>(resultado);
				}
			}
	}
}
