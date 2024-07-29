using GraphQLDemo.Api.Model.Entities;

namespace GraphQLDemo.Api;

public class ContractQuery
{
         private readonly IContractRepository _contractRepository;

        public ContractQuery(IContractRepository userService)
        {
            _contractRepository = userService;
        }

        public  async Task<Contract> GetContract(Guid id)
        {
            return await _contractRepository.GetContractById(id);
        }

        public async Task<IEnumerable<Contract>> GetContracts()
        {
            return await _contractRepository.GetContracts();
        }
}
