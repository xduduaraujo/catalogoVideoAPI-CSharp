using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioWebAPI_03.Domain.Entity
{
    [Table("Videos")]
    public class Video
    {
        [Key]
        public int IdVideo { get; set; }
        [StringLength(255)]
        public string Titulo { get; set; }
        [Url]
        public string URL { get; set; }
        public int? IdadeMin { get; set; } 
        public int IdResponsavel { get; set; }
        public virtual Responsavel Responsavel { get; set; }
        public virtual ICollection<VideoCategoria> VideoCategorias { get; set; }
    }
}
