using FilmeWebApi.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmeWebApi.Services.UnitsOfWork
{
    public interface IMovieUnitOfWork : IDisposable
    {
        IMovieRepository Movies { get; }

        IDirectorRepository Directors { get; }

        int Complete();
    }
}
