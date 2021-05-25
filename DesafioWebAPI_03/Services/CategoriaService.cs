using DesafioWebAPI_03.DAL;
using DesafioWebAPI_03.Domain.DTO;
using DesafioWebAPI_03.Domain.Entity;
using DesafioWebAPI_03.Services.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioWebAPI_03.Services
{
	public class CategoriaService
	{
		private readonly AppDbContext _dbContext;
		public CategoriaService(AppDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public ServiceResponse<Categoria> CadastrarNovo(CategoriaCreateRequest model)
		{
			var nova = new Categoria()
			{
				Nome = model.Nome
			};
			_dbContext.Add(nova);
			_dbContext.SaveChanges();
			return new ServiceResponse<Categoria>(nova);
		}

		public IEnumerable<CategoriaResponse> ListarTodos()
		{
			List<Categoria> retornoDoBanco = _dbContext.Categorias.ToList();

			IEnumerable<CategoriaResponse> listaDeCategorias = retornoDoBanco.Select(x => new CategoriaResponse(x));

			return listaDeCategorias;
		}
	}
}
