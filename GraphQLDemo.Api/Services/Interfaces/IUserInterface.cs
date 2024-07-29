using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLDemo.Api.Model.DTOs;

namespace GraphQLDemo.Api.Services.Interfaces
{
    public interface IUserService
    {
        Task<bool> AddUser(string name, string email);
        Task<UserDto> GetUserById(Guid id);
        Task<IEnumerable<UserDto>> GetUsers();
         Task<IEnumerable<ContractDto>> GetContractsByUserId(Guid userId);
    }
}