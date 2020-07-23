using FilmeWebApi.Contexts;
using FilmeWebApi.Entities;
using FilmeWebApi.Services.Repositories;
using System;

namespace FilmeWebApi.Services.UnitsOfWork
{
    public class MovieUnitOfWork : IMovieUnitOfWork
    {
        private readonly MoviesContext _context;

        public MovieUnitOfWork(MoviesContext context, IMovieRepository movies,
            IDirectorRepository director)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            Movies = movies ?? throw new ArgumentNullException(nameof(context));
            Directors = director ?? throw new ArgumentNullException(nameof(context));
        }

        public IMovieRepository Movies { get; }

        public IDirectorRepository Directors { get; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}