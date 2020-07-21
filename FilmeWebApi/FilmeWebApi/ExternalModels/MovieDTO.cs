using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmeWebApi.ExternalModels
{
    public class MovieDTO
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public Guid AuthorId { get; set; }

        public DirectorDTO Author { get; set; }
    }
}
