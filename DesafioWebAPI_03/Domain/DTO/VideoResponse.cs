using DesafioWebAPI_03.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace DesafioWebAPI_03.Domain.DTO
{
	public class VideoResponse
	{
		public VideoResponse(Video video)
		{
			IdVideo = video.IdVideo;
			Titulo = video.Titulo;
			URL = video.URL;
			IdadeMin = video.IdadeMin;
			IdResponsavel = video.IdResponsavel;
		}
		public int IdVideo { get; set; }
		public string Titulo { get; set; }
		public string URL { get; set; }
		public int? IdadeMin { get; set; }
		public int IdResponsavel { get; set; }
	}
}