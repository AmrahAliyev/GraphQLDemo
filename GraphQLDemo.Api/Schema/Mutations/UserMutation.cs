using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLDemo.Api.Services.Interfaces;

namespace GraphQLDemo.Api.Schema.Mutations
{
    public class UserMutation
    {
        private readonly IUserService _userService;

        public UserMutation([Service]IUserService userService)
        {
            _userService = userService;
        }
        public async Task<bool> AddUser(string name, string email)
        {
           return await _userService.AddUser(name, email);
        }
    }
}