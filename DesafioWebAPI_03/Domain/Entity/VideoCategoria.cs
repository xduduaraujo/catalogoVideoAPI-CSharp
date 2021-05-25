using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DesafioWebAPI_03.Domain.Entity
{

    [Table("VideoCategorias")]
    public class VideoCategoria
    {
        [Key]
        public int IdVideoCategoria { get; set; }
        public int IdVideo { get; set; } 
        public int IdCategoria { get; set; }
        public virtual Video Video { get; set; }
        public virtual Categoria Categoria { get; set; }

    }

}
