﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmeWebApi.Entities
{
    public class User
    {
        [Key]
        public Guid ID { get; set; }

        [MaxLength(150)]
        public string Nume { get; set; }

        [MaxLength(150)]
        public string Prenume { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        
        public bool IsAdmin { get; set; }

        public bool? Deleted { get; set; }

    }
}
