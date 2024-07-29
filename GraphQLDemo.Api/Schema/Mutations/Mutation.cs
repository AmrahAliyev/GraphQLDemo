using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLDemo.Api.Schema.Mutations
{
    public class Mutation
    {
        private readonly UserMutation _userMutation;
        private readonly ContractMutation _contractMutation;
        public Mutation(UserMutation userMutation, ContractMutation contractMutation)
        {
            _userMutation = userMutation;
            _contractMutation = contractMutation;
        }

        public async Task<bool> AddUser(string Name, string Email)
        {
            return await _userMutation.AddUser(Name, Email);
        }
        public async Task<bool> AddContract(string contractNumber, Guid userId)
        {
            return await _contractMutation.AddContract(contractNumber, userId);

        }
    }
}