using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLDemo.Api.Model.DTOs
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public async Task<IEnumerable<ContractDto>> Contracts(IContractRepository contractRepository)
        {
            var contracts = await contractRepository.GetContractByUserId(Id);
            return contracts.Select(x => new ContractDto()
            {
                Id = x.Id,
                ContractNumber = x.ContractNumber,
            });
        }
    }
}