using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLDemo.Api.Model.Entities;

namespace GraphQLDemo.Api.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> AddUser(string name, string email);
        Task<User> GetUserById(Guid id);
        Task<IEnumerable<User>> GetUsers();
    }
}