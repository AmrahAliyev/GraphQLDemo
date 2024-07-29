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
    public class UserRepository : IUserRepository
    {
        private readonly DbSet<User> _user;
        private readonly DbSet<Contract> _contract;
        private readonly AppDbContext _dbContext;
        private readonly IDbContextFactory<AppDbContext> _dbContextFactory;

        public UserRepository(IDbContextFactory<AppDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
            _dbContext = _dbContextFactory.CreateDbContext();
            _user = _dbContext.Set<User>();
            _contract = _dbContext.Set<Contract>();
        }

        public async Task<bool> AddUser(string name, string email)
        {
            await _user.AddAsync(new User
            {
                Id = Guid.NewGuid(),
                Name = name,
                Email = email
            });
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<User> GetUserById(Guid id)
        {
            var user = await _user.FindAsync(id);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with ID {id} was not found.");
            }
            return user;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _user.ToListAsync();
        }

        public async Task<IEnumerable<Contract>> GetContractsByUserId(Guid userId)
        {
            return await _contract.Where(c => c.UserId == userId).ToListAsync();
        }
    }

}
