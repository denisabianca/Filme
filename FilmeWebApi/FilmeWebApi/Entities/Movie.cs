using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace FilmeWebApi.Entities
{
    public class Movie
    {
        [Key] 
        public Guid Id { get; set; }
         
        [Required]
        [MaxLength(150)]
        public string Title  { get; set; }

        [MaxLength(2500)]
        public string Description { get; set; }

       // [MaxLength(150)]
        //public int Year { get; set; }

        [Required]
        public Guid DirectorId { get; set; }

        [ForeignKey("DirectorId")]
        public virtual Director Director { get; set; }

        public bool? Deleted { get; set; }
    }
}
