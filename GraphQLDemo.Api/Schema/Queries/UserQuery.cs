using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLDemo.Api.Model.DTOs;
using GraphQLDemo.Api.Services;
using GraphQLDemo.Api.Services.Interfaces;

namespace GraphQLDemo.Api.Schema.Queries
{
    public class UserQuery
    {
        private readonly IUserService _userService;

        public UserQuery(IUserService userService)
        {
            _userService = userService;
        }

        public  async Task<UserDto> GetUser(Guid id)
        {
            return await _userService.GetUserById(id);
        }

        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            return await _userService.GetUsers();
        }
    }
}