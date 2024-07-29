using GraphQLDemo.Api.Model.DTOs;

namespace GraphQLDemo.Api;

public class ContractService : IContractService
{
    private readonly IContractRepository _contractRepository;
    public ContractService([Service] IContractRepository contractRepository)
    {
        _contractRepository = contractRepository;
    }

    public async Task<bool> AddContract(string contractNumber, Guid userId)
    {
        return await _contractRepository.AddContract(contractNumber, userId);
    }

    public async Task<ContractDto> GetContractById(Guid id)
    {
        var contract = await _contractRepository.GetContractById(id);
        return new ContractDto()
        {
            Id = contract.Id,
            ContractNumber = contract.ContractNumber,
            User = new UserDto()
            {
                Id = contract.User.Id,
                Email = contract.User.Email,
                Name = contract.User.Name,
            }
        };
    }

    public async Task<IEnumerable<ContractDto>> GetContract()
    {
        var contracts = await _contractRepository.GetContracts();
        return contracts.Select(contract =>
        {
            var contractDto = new ContractDto
            {
                Id = contract.Id,
                ContractNumber = contract.ContractNumber,
            };
            if (contract.User is not null)
            {
                contractDto.User = new UserDto()
                {
                    Id = contract.User.Id,
                    Email = contract.User.Email,
                    Name = contract.User.Name,
                };
            }
            return contractDto;
        }).ToList();
    }
}
