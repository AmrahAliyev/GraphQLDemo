namespace GraphQLDemo.Api;

using GraphQLDemo.Api.Data;
using GraphQLDemo.Api.Model.Entities;
using GreenDonut;
using Microsoft.EntityFrameworkCore;

// DataLoader
public class ContractByUserDataLoader : BatchDataLoader<Guid, List<Contract>>
{
    private readonly IContractRepository _contractRepository;

    public ContractByUserDataLoader(IBatchScheduler batchScheduler,
    IContractRepository contractRepository,
    IDbContextFactory<AppDbContext> dbContextFactory)
        : base(batchScheduler)
    {
        _contractRepository = contractRepository;
    }

    protected override async Task<IReadOnlyDictionary<Guid, List<Contract>>> LoadBatchAsync(IReadOnlyList<Guid> keys, CancellationToken cancellationToken)
    {
        IEnumerable<Contract> contracts = await _contractRepository.GetManyByIds(keys);

        return contracts
        .GroupBy(x => x.UserId)
        .ToDictionary(g => g.Key, g => g.ToList());
    }
}