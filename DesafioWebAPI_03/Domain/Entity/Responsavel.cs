using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioWebAPI_03.Domain.Entity
{
    [Table("Responsaveis")]
    public class Responsavel
    {
        [Key]
        public int IdResponsavel { get; set; }
        [StringLength(255)]
        public string Nome { get; set; }
        public virtual ICollection<Video> Videos { get; set; }
    }
 
}
