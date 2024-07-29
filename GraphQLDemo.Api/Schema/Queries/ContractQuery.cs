using GraphQLDemo.Api.Model.DTOs;

namespace GraphQLDemo.Api;

public class ContractQuery
{
         private readonly IContractService _contractService;

        public ContractQuery(IContractService userService)
        {
            _contractService = userService;
        }

        public  async Task<ContractDto> GetContract(Guid id)
        {
            return await _contractService.GetContractById(id);
        }

        public async Task<IEnumerable<ContractDto>> GetContracts()
        {
            return await _contractService.GetContract();
        }
}
