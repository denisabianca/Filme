using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace FilmeWebApi.Entities
{
    public class Filme
    {
        [Key] 
        public Guid Id { get; set; }
         
        [Required]
        [MaxLength(150)]
        public string Titlu  { get; set; }

        [MaxLength(2500)]
        public string Descrierea { get; set; }

        [MaxLength(150)]
        public int AnulAparitiei { get; set; }

        [Required]
        public Guid RegizorId { get; set; }

        [ForeignKey("Regizor")]
        public virtual Regizor Regizor { get; set; }

        public bool? Deleted { get; set; }
    }
}
