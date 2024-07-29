using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLDemo.Api.Data;
using GraphQLDemo.Api.Model.Entities;
using GraphQLDemo.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GraphQLDemo.Api.Repositories
{
    // UserRepository
    public class UserRepository : IUserRepository
    {
        private readonly IDbContextFactory<AppDbContext> _dbContextFactory;
        public UserRepository(IDbContextFactory<AppDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<bool> AddUser(string name, string email)
        {
            using var dbContext = _dbContextFactory.CreateDbContext();
            await dbContext.Users.AddAsync(new User
            {
                Id = Guid.NewGuid(),
                Name = name,
                Email = email
            });
            return await dbContext.SaveChangesAsync() > 0;
        }

        public async Task<User> GetUserById(Guid id)
        {
            using var dbContext = _dbContextFactory.CreateDbContext();

            var user = await dbContext.Users.FindAsync(id);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with ID {id} was not found.");
            }
            return user;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            using var dbContext = _dbContextFactory.CreateDbContext();
            return await dbContext.Users.Include(x => x.Contracts).ToListAsync();
        }

    }

}
