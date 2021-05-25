using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DesafioWebAPI_03.Domain.Entity
{
    [Table("Categorias")]
    public class Categoria
    {
        [Key]
        public int IdCategoria { get; set; }
        [Required]
        [StringLength(255)]
        public string Nome { get; set; }
        public virtual ICollection<VideoCategoria> VideoCategorias { get; set; }
    }
}
