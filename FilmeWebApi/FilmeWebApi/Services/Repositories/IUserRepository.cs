using FilmeWebApi.Entities;
using System.Collections.Generic;

namespace FilmeWebApi.Services.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        IEnumerable<User> GetAdminUsers();
    }
}