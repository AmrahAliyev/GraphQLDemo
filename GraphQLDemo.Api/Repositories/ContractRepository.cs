using GraphQLDemo.Api.Data;
using GraphQLDemo.Api.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraphQLDemo.Api;

public class ContractRepository : IContractRepository
{
    private readonly DbSet<Contract> _contract;
    private readonly IDbContextFactory<AppDbContext> _dbContextFactory;
    private readonly AppDbContext _dbContext;

    public ContractRepository(IDbContextFactory<AppDbContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
        _dbContext = _dbContextFactory.CreateDbContext();
        _contract = _dbContext.Set<Contract>();
    }

    public async Task<bool> AddContract(string contractNumber, Guid userId)
    {
        await _contract.AddAsync(new Contract()
        {
            Id = Guid.NewGuid(),
            ContractNumber = contractNumber,
            UserId = userId

        });
        return await _dbContext.SaveChangesAsync() > 0; // Ensure to use SaveChangesAsync
    }

    public async Task<Contract> GetContractById(Guid id)
    {
        var contract = await _contract.FindAsync(id) ?? throw new KeyNotFoundException($"contract with ID {id} was not found.");
        return contract;
    }

    public async Task<IEnumerable<Contract>> GetContracts()
    {
        return await _contract.ToListAsync();
    }
}
