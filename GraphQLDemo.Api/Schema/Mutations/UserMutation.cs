using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLDemo.Api.Repositories.Interfaces;

namespace GraphQLDemo.Api.Schema.Mutations
{
    public class UserMutation
    {
        private readonly IUserRepository _userRepository;

        public UserMutation(IUserRepository userService)
        {
            _userRepository = userService;
        }
        public async Task<bool> AddUser(string name, string email)
        {
           return await _userRepository.AddUser(name, email);
        }
    }
}