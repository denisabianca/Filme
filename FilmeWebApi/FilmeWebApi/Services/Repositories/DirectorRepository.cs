using BooksWebApi.Services.Repositories;
using FilmeWebApi.Contexts;
using FilmeWebApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmeWebApi.Services.Repositories
{
    public class DirectorRepository : Repository<Director>, IDirectorRepository
    {
        private readonly MoviesContext _context;

        public DirectorRepository(MoviesContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
    }
}
