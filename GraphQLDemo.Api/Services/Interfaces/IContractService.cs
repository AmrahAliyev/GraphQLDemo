using GraphQLDemo.Api.Model.DTOs;

namespace GraphQLDemo.Api;

public interface IContractService
{
    Task<bool> AddContract(string contractNumber, Guid userId);
    Task<ContractDto> GetContractById(Guid id);
    Task<IEnumerable<ContractDto>> GetContract();
}
