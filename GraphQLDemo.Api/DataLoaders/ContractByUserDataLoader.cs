namespace GraphQLDemo.Api;

using GraphQLDemo.Api.Data;
using GraphQLDemo.Api.Model.Entities;
using GreenDonut;
using Microsoft.EntityFrameworkCore;

// DataLoader
public class ContractByUserDataLoader : BatchDataLoader<Guid, List<Contract>>
{
    private readonly IDbContextFactory<AppDbContext> _dbContextFactory;

    public ContractByUserDataLoader(IBatchScheduler batchScheduler, IDbContextFactory<AppDbContext> dbContextFactory)
        : base(batchScheduler)
    {
        _dbContextFactory = dbContextFactory;
    }

    protected override async Task<IReadOnlyDictionary<Guid, List<Contract>>> LoadBatchAsync(IReadOnlyList<Guid> keys, CancellationToken cancellationToken)
    {
        await using var dbContext = _dbContextFactory.CreateDbContext();
        var contracts = await dbContext.Contracts
            .Where(c => keys.Contains(c.UserId))
            .ToListAsync(cancellationToken);

        return contracts.GroupBy(c => c.UserId)
                        .ToDictionary(g => g.Key, g => g.ToList());
    }
}
