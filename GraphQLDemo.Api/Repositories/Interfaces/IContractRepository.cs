using GraphQLDemo.Api.Model.Entities;

namespace GraphQLDemo.Api;

public interface IContractRepository
{
    Task<bool> AddContract(Contract contract);
    Task<Contract> GetContractById(Guid id);
    Task<IEnumerable<Contract>> GetContractByUserId(Guid id);
    Task<IEnumerable<Contract>> GetContracts();
    Task<IEnumerable<Contract>> GetManyByIds(IReadOnlyList<Guid> userIdKeys);
}
