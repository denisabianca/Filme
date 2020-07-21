using BooksWebApi.Services.Repositories;
using FilmeWebApi.Contexts;
using FilmeWebApi.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace FilmeWebApi.Services.Repositories
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        private readonly MoviesContext _context;

        public MovieRepository(MoviesContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Movie GetMovieDetails(Guid movieId)
        {
            return _context.Movies
                .Where(b => b.Id == movieId && (b.Deleted == false || b.Deleted == null))
                .Include(b => b.Director)
                .FirstOrDefault();
        }
    }
}