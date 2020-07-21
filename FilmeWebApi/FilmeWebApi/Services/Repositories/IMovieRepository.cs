using FilmeWebApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmeWebApi.Services.Repositories
{
    public interface IMovieRepository : IRepository<Movie>
    {
        Movie GetMovieDetails(Guid movieId);
    }
}
