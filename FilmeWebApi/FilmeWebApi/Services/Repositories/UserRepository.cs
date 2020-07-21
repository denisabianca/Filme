using BooksWebApi.Services.Repositories;
using FilmeWebApi.Contexts;
using FilmeWebApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FilmeWebApi.Services.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly MoviesContext _context;

        public UserRepository(MoviesContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<User> GetAdminUsers()
        {
            return _context.Users
                .Where(u => u.IsAdmin && (u.Deleted == false || u.Deleted == null))
                .ToList();
        }
    }
}