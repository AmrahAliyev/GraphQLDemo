using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLDemo.Api.Model.DTOs;
using GraphQLDemo.Api.Model.Entities;
using GraphQLDemo.Api.Repositories.Interfaces;

namespace GraphQLDemo.Api.Schema.Queries
{
    public class UserQuery
    {
        private readonly IUserRepository _userRepository;

        public UserQuery(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetUser(Guid id)
        {
            return await _userRepository.GetUserById(id);
        }

        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            IEnumerable<User> users = await _userRepository.GetUsers();
            return users.Select(x =>
                new UserDto()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Email = x.Email
                }
            );
        }
    }
}