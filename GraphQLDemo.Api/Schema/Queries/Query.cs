using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using GraphQLDemo.Api.Model.DTOs;
using GraphQLDemo.Api.Model.Entities;

namespace GraphQLDemo.Api.Schema.Queries
{
    public class Query
    {
        private readonly UserQuery _userQuery;
        private readonly ContractQuery _contractQuery;

        public Query(UserQuery userQuery, ContractQuery contractQuery)
        {
            _userQuery = userQuery;
            _contractQuery = contractQuery;
        }

        public async Task<User> GetUser(Guid id)
        {
            return await _userQuery.GetUser(id);
        }

        [GraphQLDescription("Bütün istifadəçiləri gətirir")]
        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            return await _userQuery.GetUsers();
        }


        public async Task<Contract> GetContract(Guid id)
        {
            return await _contractQuery.GetContract(id);
        }
        //[UsePaging]
        public async Task<IEnumerable<Contract>> GetContracts()
        {
            return await _contractQuery.GetContracts();
        }
    }
}