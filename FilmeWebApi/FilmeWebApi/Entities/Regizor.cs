using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmeWebApi.Entities
{
    public class Regizor
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Nume { get; set; }

        [MaxLength(150)]
        public string Prenume { get; set; }

        public bool? Deleted { get; set; }

    }
}
