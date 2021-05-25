using DesafioWebAPI_03.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioWebAPI_03.Domain.DTO
{
    public class CategoriaResponse
    {
		public CategoriaResponse(Categoria categoria)
		{
			IdResponsavel = categoria.IdCategoria;
			Nome = categoria.Nome;
		}

		public int IdResponsavel { get; set; }
		public string Nome { get; set; }
	}
}
