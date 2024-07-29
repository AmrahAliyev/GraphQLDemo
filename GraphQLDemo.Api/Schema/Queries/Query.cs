using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLDemo.Api.Model.DTOs;

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

        public async Task<UserDto> GetUser(Guid id)
        {
            return await _userQuery.GetUser(id);
        }

        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            return await _userQuery.GetUsers();
        }


        public async Task<ContractDto> GetContract(Guid id)
        {
            return await _contractQuery.GetContract(id);
        }

        public async Task<IEnumerable<ContractDto>> GetContracts()
        {
            return await _contractQuery.GetContracts();
        }
    }
}