using GraphQLDemo.Api.Data;
using GraphQLDemo.Api.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraphQLDemo.Api;

public class ContractRepository : IContractRepository
{
    private readonly IDbContextFactory<AppDbContext> _dbContextFactory;

    public ContractRepository(IDbContextFactory<AppDbContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }

    public async Task<bool> AddContract(string contractNumber, Guid userId)
    {
        using var dbContext = _dbContextFactory.CreateDbContext();
        await dbContext.Contracts.AddAsync(new Contract()
        {
            Id = Guid.NewGuid(),
            ContractNumber = contractNumber,
            UserId = userId

        });
        return await dbContext.SaveChangesAsync() > 0; // Ensure to use SaveChangesAsync
    }

    public async Task<Contract> GetContractById(Guid id)
    {
        using var dbContext = _dbContextFactory.CreateDbContext();
        var contract = await dbContext.Contracts.FindAsync(id) ?? throw new KeyNotFoundException($"contract with ID {id} was not found.");
        return contract;
    }

    public async Task<IEnumerable<Contract>> GetContractByUserId(Guid id)
    {
        using var dbContext = _dbContextFactory.CreateDbContext();
        return await dbContext.Contracts.Where(x => x.UserId == id).ToListAsync();
    }

    public async Task<IEnumerable<Contract>> GetContracts()
    {
        using var dbContext = _dbContextFactory.CreateDbContext();
        // var data = await dbContext.Contracts.Include(x => x.User).ToListAsync();
        // return data;
        return await dbContext.Contracts.ToListAsync();
    }
}
