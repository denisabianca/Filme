using FilmeWebApi.Services.Repositories;
using System;

namespace FilmeWebApi.Services.UnitsOfWork
{
    public interface IUserUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }

        int Complete();
    }
}