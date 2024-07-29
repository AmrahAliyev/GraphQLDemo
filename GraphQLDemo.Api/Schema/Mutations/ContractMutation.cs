namespace GraphQLDemo.Api;

public class ContractMutation
{
    private readonly IContractRepository _contractRepository;

    public ContractMutation(IContractRepository cotractService)
    {
        _contractRepository = cotractService;
    }
    public async Task<bool> AddContract(string contractNumber, Guid userId)
    {
        return await _contractRepository.AddContract(contractNumber, userId);
    }
}