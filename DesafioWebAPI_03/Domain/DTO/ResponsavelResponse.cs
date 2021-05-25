using DesafioWebAPI_03.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioWebAPI_03.Domain.DTO
{
    public class ResponsavelResponse
    {
		public ResponsavelResponse(Responsavel responsavel)
		{
			IdResponsavel = responsavel.IdResponsavel;
			Nome = responsavel.Nome;
		}

		public int IdResponsavel { get; set; }
		public string Nome { get; set; }
	}
}

