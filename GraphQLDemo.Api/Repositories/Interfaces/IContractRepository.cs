using GraphQLDemo.Api.Model.Entities;

namespace GraphQLDemo.Api;

public interface IContractRepository
{
    Task<bool> AddContract(string contractNumber, Guid userId);
    Task<Contract> GetContractById(Guid id);
    Task<IEnumerable<Contract>> GetContractByUserId(Guid id);
    Task<IEnumerable<Contract>> GetContracts();
}
